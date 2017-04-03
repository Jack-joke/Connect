#include "aopus_OpusLibrary.h"

#include <stdlib.h>
#include <stdio.h>
#include <stdint.h>
#include <string.h>

#include <android/log.h>

#define printf(...) __android_log_print(ANDROID_LOG_DEBUG, "fm", __VA_ARGS__);

#include "../include/opus/opus.h"

typedef struct
{
    OpusEncoder   *enc;
    int            frameSizePerChannel;
    int            maxEncodedDataBytesLength;
    unsigned char *encodedDataBytes;
	int            bitrate;
	double         quality;
	int            complexity;
} Encoder;

JNIEXPORT jint JNICALL Java_aopus_OpusLibrary_encoderGetBitrate
  (JNIEnv *env, jclass obj, jlong state)
{
    Encoder *encoder = (Encoder *)(intptr_t)state;

    return encoder->bitrate;
}

JNIEXPORT void JNICALL Java_aopus_OpusLibrary_encoderSetBitrate
  (JNIEnv *env, jclass obj, jlong state, jint value)
{
    Encoder *encoder = (Encoder *)(intptr_t)state;

	int lowerBound = 1;
	int upperBound = 500;
	encoder->bitrate = (value < lowerBound ? lowerBound : (value > upperBound ? upperBound : value));
	opus_encoder_ctl(encoder->enc, OPUS_SET_BITRATE(encoder->bitrate * 1024));
}

JNIEXPORT jdouble JNICALL Java_aopus_OpusLibrary_encoderGetQuality
  (JNIEnv *env, jclass obj, jlong state)
{
    Encoder *encoder = (Encoder *)(intptr_t)state;

    return encoder->quality;
}

JNIEXPORT void JNICALL Java_aopus_OpusLibrary_encoderSetQuality
  (JNIEnv *env, jclass obj, jlong state, jdouble value)
{
    Encoder *encoder = (Encoder *)(intptr_t)state;

	encoder->quality = (value < 0.0 ? 0.0 : (value > 1.0 ? 1.0 : value));

	int lowerBound = 0;
	int upperBound = 10;
	encoder->complexity = lowerBound + (int)(encoder->quality * (upperBound - lowerBound));
	opus_encoder_ctl(encoder->enc, OPUS_SET_COMPLEXITY(encoder->complexity));
}

JNIEXPORT jlong JNICALL Java_aopus_OpusLibrary_encoderCreate
  (JNIEnv *env, jclass obj, jint clockRate, jint channels, jint packetTime)
{
    Encoder *encoder = (Encoder *)malloc(sizeof* encoder);
    
    encoder->frameSizePerChannel = (clockRate * packetTime) / 1000;
    encoder->maxEncodedDataBytesLength = 4000;
    encoder->encodedDataBytes = (unsigned char *)malloc(encoder->maxEncodedDataBytesLength);

    // initialize encoder
    int error;
    encoder->enc = opus_encoder_create(clockRate, channels, OPUS_APPLICATION_VOIP, &error);
    if (error != OPUS_OK)
    {
        printf("Could not initialize Opus encoder. %s", opus_strerror(error));
        return 0;
    }

	opus_encoder_ctl(encoder->enc, OPUS_SET_SIGNAL(OPUS_SIGNAL_VOICE));

	Java_aopus_OpusLibrary_encoderSetBitrate(env, obj, (intptr_t)encoder, 125);
	Java_aopus_OpusLibrary_encoderSetQuality(env, obj, (intptr_t)encoder, 1.0);

    return (intptr_t)encoder;
}

JNIEXPORT void JNICALL Java_aopus_OpusLibrary_encoderActivateFEC
  (JNIEnv *env, jclass obj, jlong state, jint packetLossPercent)
{
    Encoder *encoder = (Encoder *)(intptr_t)state;

	opus_encoder_ctl(encoder->enc, OPUS_SET_INBAND_FEC(1));
	opus_encoder_ctl(encoder->enc, OPUS_SET_PACKET_LOSS_PERC(packetLossPercent));
}

JNIEXPORT void JNICALL Java_aopus_OpusLibrary_encoderDeactivateFEC
  (JNIEnv *env, jclass obj, jlong state)
{
    Encoder *encoder = (Encoder *)(intptr_t)state;

	opus_encoder_ctl(encoder->enc, OPUS_SET_INBAND_FEC(0));
	opus_encoder_ctl(encoder->enc, OPUS_SET_PACKET_LOSS_PERC(0));
}

JNIEXPORT void JNICALL Java_aopus_OpusLibrary_encoderDestroy
  (JNIEnv *env, jclass obj, jlong state)
{
    Encoder *encoder = (Encoder *)(intptr_t)state;
    
    if (encoder->enc)
    {
        opus_encoder_destroy(encoder->enc);
        encoder->enc = NULL;
    }

    if (encoder->encodedDataBytes)
    {
        free(encoder->encodedDataBytes);
        encoder->encodedDataBytes = NULL;
    }
    
    free(encoder);
}

JNIEXPORT jbyteArray JNICALL Java_aopus_OpusLibrary_encoderEncode
  (JNIEnv *env, jclass obj, jlong state, jbyteArray data, jint index, jint length)
{
    Encoder *encoder = (Encoder *)(intptr_t)state;
    
    // pin data from managed space
    unsigned char *dataBytes = (unsigned char *)env->GetByteArrayElements(data, NULL);

    int encodedLength = opus_encode(encoder->enc, (opus_int16 *)(dataBytes + index), encoder->frameSizePerChannel, encoder->encodedDataBytes, encoder->maxEncodedDataBytesLength);
    env->ReleaseByteArrayElements(data, (jbyte *)dataBytes, JNI_ABORT); // JNI_ABORT is correct
    if (encodedLength > 0)
    {
        // copy encoded frame to managed space
        jbyteArray encodedData = env->NewByteArray(encodedLength);
        env->SetByteArrayRegion(encodedData, 0, encodedLength, (jbyte *)encoder->encodedDataBytes);
        return encodedData;
    }
    
    return NULL;
}

typedef struct
{
    OpusDecoder *dec;
    int          frameSizePerChannel;
    int          maxDataLength;
    jbyteArray   data;
    jbyteArray   fecData;
    int          channels;
} Decoder;

JNIEXPORT jlong JNICALL Java_aopus_OpusLibrary_decoderCreate
  (JNIEnv *env, jclass obj, jint clockRate, jint channels, jint packetTime)
{
    Decoder *decoder = (Decoder *)malloc(sizeof* decoder);
    
    decoder->frameSizePerChannel = (clockRate * packetTime) / 1000;
    decoder->maxDataLength = clockRate * channels * sizeof(short) * packetTime / 1000;
    
    decoder->data = (jbyteArray)env->NewGlobalRef(env->NewByteArray(decoder->maxDataLength));
    decoder->fecData = (jbyteArray)env->NewGlobalRef(env->NewByteArray(decoder->maxDataLength));

    decoder->channels = channels;

    // initialize decoder
    int error;
    decoder->dec = opus_decoder_create(clockRate, channels, &error);
    if (error != OPUS_OK)
    {
        printf("Could not initialize Opus decoder. %s", opus_strerror(error));
        return 0;
    }
    return (intptr_t)decoder;
}

JNIEXPORT void JNICALL Java_aopus_OpusLibrary_decoderDestroy
  (JNIEnv *env, jclass obj, jlong state)
{
    Decoder *decoder = (Decoder *)(intptr_t)state;
    
    if (decoder->dec)
    {
        opus_decoder_destroy(decoder->dec);
        decoder->dec = NULL;
    }

    if (decoder->data)
    {
        env->DeleteGlobalRef(decoder->data);
        decoder->data = NULL;
    }

    if (decoder->fecData)
    {
        env->DeleteGlobalRef(decoder->fecData);
        decoder->fecData = NULL;
    }
    
    free(decoder);
}

JNIEXPORT jbyteArray JNICALL Java_aopus_OpusLibrary_decoderDecode
  (JNIEnv *env, jclass obj, jlong state, jbyteArray encodedData)
{
	return Java_aopus_OpusLibrary_decoderDecode2(env, obj, state, encodedData, JNI_FALSE);
}

JNIEXPORT jbyteArray JNICALL Java_aopus_OpusLibrary_decoderDecode2
  (JNIEnv *env, jclass obj, jlong state, jbyteArray encodedData, jboolean fec)
{
    Decoder *decoder = (Decoder *)(intptr_t)state;

	if (encodedData == NULL)
	{
        jbyteArray plcData = env->NewByteArray(decoder->maxDataLength);
	    unsigned char *plcDataBytes = (unsigned char *)env->GetByteArrayElements(plcData, NULL);

		int numSamplesDecoded = opus_decode(decoder->dec, 0, 0, (opus_int16 *)plcDataBytes, decoder->frameSizePerChannel, fec ? 1 : 0);
        
        env->ReleaseByteArrayElements(plcData, (jbyte *)plcDataBytes, 0); // 0 is correct
        
		if (numSamplesDecoded > 0)
		{
			return plcData;
		}
        
        env->DeleteLocalRef(plcData);
	}
	else
	{
	    int encodedLength = env->GetArrayLength(encodedData);
	    unsigned char *encodedDataBytes = (unsigned char *)env->GetByteArrayElements(encodedData, NULL);

	    // pin data from managed space
	    jbyteArray data = (fec ? decoder->fecData : decoder->data);
	    unsigned char *dataBytes = (unsigned char *)env->GetByteArrayElements(data, NULL);

		int numSamplesDecoded = opus_decode(decoder->dec, encodedDataBytes, (opus_int32)encodedLength, (opus_int16 *)dataBytes, decoder->frameSizePerChannel, fec ? 1 : 0);

	    env->ReleaseByteArrayElements(encodedData, (jbyte *)encodedDataBytes, JNI_ABORT); // JNI_ABORT is correct
	    env->ReleaseByteArrayElements(data, (jbyte *)dataBytes, 0); // 0 is correct

		if (numSamplesDecoded > 0)
		{
			return data;
		}
	}

	return NULL;
}
