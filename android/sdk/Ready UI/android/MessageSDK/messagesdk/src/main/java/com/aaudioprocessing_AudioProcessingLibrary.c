#include "aaudioprocessing_AudioProcessingLibrary.h"

#include <stdlib.h>
#include <stdio.h>
#include <stdint.h>
#include <string.h>

#include <android/log.h>

#define printf(...) __android_log_print(ANDROID_LOG_DEBUG, "fm", __VA_ARGS__);

#include "../include/audio_processing/aecm/echo_control_mobile.h"
#include "../include/common_audio/resampler.h"

using namespace webrtc;

typedef struct
{
    int clockRate;
    int channels;
    int internalClockRate;
    int samplesPerBlock;
    int tailLength;

    void *aec;
    
    jbyteArray echoDataMono;
    jbyteArray inputDataMono;
    jbyteArray outputData;
    
    Resampler *echoResampler;
    Resampler *inputResampler;
    Resampler *outputResampler;

    jbyteArray echoDataResampled;
    jbyteArray inputDataResampled;
    jbyteArray outputDataResampled;
} AcousticEchoCanceller;

JNIEXPORT jlong JNICALL Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerCreate
  (JNIEnv *env, jclass obj, jint clockRate, jint channels, jint tailLength)
{
    AcousticEchoCanceller *aec = (AcousticEchoCanceller *)malloc(sizeof* aec);
    
    aec->clockRate = clockRate;
    aec->channels = channels;
    aec->tailLength = tailLength;
    aec->echoDataMono = NULL;
    aec->inputDataMono = NULL;
    aec->outputData = NULL;
    aec->echoDataResampled = NULL;
    aec->inputDataResampled = NULL;
    aec->outputDataResampled = NULL;
    
    if (aec->clockRate == 16000 || aec->clockRate == 8000)
    {
        aec->internalClockRate = clockRate;
    }
    else if (aec->clockRate > 16000)
    {
        aec->internalClockRate = 16000;
    }
    else if (aec->clockRate > 8000)
    {
        aec->internalClockRate = 8000;
    }
    else
    {
        printf("Unsupported clock rate.");
        return 0;
    }
    aec->samplesPerBlock = aec->internalClockRate / 100; // 10ms
    
    if (WebRtcAecm_Create(&(aec->aec)))
    {
        printf("Could not create acoustic echo canceller.");
        return 0;
    }
    
    if (WebRtcAecm_Init(aec->aec, aec->internalClockRate))
    {
        printf("Could not initialize acoustic echo canceller.");
        return 0;
    }
    
    if (aec->clockRate != aec->internalClockRate)
    {
        aec->echoResampler = new Resampler(aec->clockRate, aec->internalClockRate, kResamplerSynchronous);
        aec->inputResampler = new Resampler(aec->clockRate, aec->internalClockRate, kResamplerSynchronous);
        aec->outputResampler = new Resampler(aec->internalClockRate, aec->clockRate, kResamplerSynchronous);
    }
    else
    {
        aec->echoResampler = NULL;
        aec->inputResampler = NULL;
        aec->outputResampler = NULL;
    }
    return (intptr_t)aec;
}

JNIEXPORT void JNICALL Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerDestroy
  (JNIEnv *env, jclass obj, jlong state)
{
    AcousticEchoCanceller *aec = (AcousticEchoCanceller *)(intptr_t)state;
    
    if (aec->aec)
    {
        if (WebRtcAecm_Free(aec->aec))
        {
            printf("Could not free acoustic echo canceller.");
        }
    }

    if (aec->echoResampler)
    {
        free(aec->echoResampler);
        aec->echoResampler = NULL;
    }

    if (aec->inputResampler)
    {
        free(aec->inputResampler);
        aec->inputResampler = NULL;
    }

    if (aec->outputResampler)
    {
        free(aec->outputResampler);
        aec->outputResampler = NULL;
    }
    
    if (aec->echoDataMono)
    {
        env->DeleteGlobalRef(aec->echoDataMono);
        aec->echoDataMono = NULL;
    }
    
    if (aec->echoDataResampled)
    {
        env->DeleteGlobalRef(aec->echoDataResampled);
        aec->echoDataResampled = NULL;
    }
    
    if (aec->inputDataMono)
    {
        env->DeleteGlobalRef(aec->inputDataMono);
        aec->inputDataMono = NULL;
    }
    
    if (aec->inputDataResampled)
    {
        env->DeleteGlobalRef(aec->inputDataResampled);
        aec->inputDataResampled = NULL;
    }
    
    if (aec->outputData)
    {
        env->DeleteGlobalRef(aec->outputData);
        aec->outputData = NULL;
    }
    
    if (aec->outputDataResampled)
    {
        env->DeleteGlobalRef(aec->outputDataResampled);
        aec->outputDataResampled = NULL;
    }
}

void acousticEchoCancellerRenderCleanup(JNIEnv *env, jbyteArray echoData, unsigned char *echo_data, jbyteArray echoDataMono, unsigned char *echo_data_mono, jbyteArray echoDataResampled, unsigned char *echo_data_resampled)
{
    if (echo_data)
    {
        env->ReleaseByteArrayElements(echoData, (jbyte *)echo_data, JNI_ABORT); // JNI_ABORT is correct
    }
    if (echo_data_mono)
    {
        env->ReleaseByteArrayElements(echoDataMono, (jbyte *)echo_data_mono, JNI_ABORT); // JNI_ABORT is correct
    }
    if (echo_data_resampled)
    {
        env->ReleaseByteArrayElements(echoDataResampled, (jbyte *)echo_data_resampled, JNI_ABORT); // JNI_ABORT is correct
    }
}

JNIEXPORT void JNICALL Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerRender
  (JNIEnv *env, jclass obj, jlong state, jbyteArray echoData, jint echoIndex, jint echoLength)
{
    AcousticEchoCanceller *aec = (AcousticEchoCanceller *)(intptr_t)state;
    
    int sampleCount = echoLength / sizeof(short);
    
    unsigned char *echo_data_release = NULL;
    unsigned char *echo_data_mono_release = NULL;
    unsigned char *echo_data_resampled_release = NULL;
    
    echo_data_release = (unsigned char *)env->GetByteArrayElements(echoData, NULL);
    unsigned char *echo_data = echo_data_release + echoIndex;
    short *echo_data_shorts = (short *)echo_data;
    
    // downsample echo to mono
    if (aec->channels == 2)
    {
        sampleCount /= 2;

        if (aec->echoDataMono == NULL || env->GetArrayLength(aec->echoDataMono) != echoLength / 2)
        {
            if (aec->echoDataMono)
            {
                env->DeleteGlobalRef(aec->echoDataMono);
            }
            aec->echoDataMono = (jbyteArray)env->NewGlobalRef(env->NewByteArray(echoLength / 2));
        }

        echo_data_mono_release = (unsigned char *)env->GetByteArrayElements(aec->echoDataMono, NULL);
        unsigned char *echo_data_mono = echo_data_mono_release;
        short *echo_data_mono_shorts = (short *)echo_data_mono;

        for (int i = 0, j = 0; i < sampleCount; i++, j+=2)
        {
            echo_data_mono_shorts[i] = (short)(((int)echo_data_shorts[j+0] + (int)echo_data_shorts[j+1]) / 2);
        }

        echo_data_shorts = echo_data_mono_shorts;
    }

    // downsample echo clock rate if needed
    if (aec->echoResampler)
    {
        int resampleCount = sampleCount * aec->internalClockRate / aec->clockRate;
        if (aec->echoDataResampled == NULL || env->GetArrayLength(aec->echoDataResampled) != resampleCount * sizeof(short))
        {
            if (aec->echoDataResampled)
            {
                env->DeleteGlobalRef(aec->echoDataResampled);
            }
            aec->echoDataResampled = (jbyteArray)env->NewGlobalRef(env->NewByteArray(resampleCount * sizeof(short)));
        }

        echo_data_resampled_release = (unsigned char *)env->GetByteArrayElements(aec->echoDataResampled, NULL);
        unsigned char *echo_data_resampled = echo_data_resampled_release;
        short *echo_data_resampled_shorts = (short *)echo_data_resampled;

        if (aec->echoResampler->Push(echo_data_shorts, sampleCount, echo_data_resampled_shorts, resampleCount, sampleCount))
        {
            printf("Could not downsample echo clock rate for acoustic echo canceller.");
            acousticEchoCancellerRenderCleanup(env, echoData, echo_data_release, aec->echoDataMono, echo_data_mono_release, aec->echoDataResampled, echo_data_resampled_release);
            return;
        }
        echo_data_shorts = echo_data_resampled_shorts;
    }

    // buffer echo data
    for (int i = 0; i < sampleCount; i += aec->samplesPerBlock)
    {
        const short *in = echo_data_shorts + i;
        if (WebRtcAecm_BufferFarend(aec->aec, in, aec->samplesPerBlock))
        {
            printf("Could not render echo data to acoustic echo canceller.");
            acousticEchoCancellerRenderCleanup(env, echoData, echo_data_release, aec->echoDataMono, echo_data_mono_release, aec->echoDataResampled, echo_data_resampled_release);
            return;
        }
    }
    
    acousticEchoCancellerRenderCleanup(env, echoData, echo_data_release, aec->echoDataMono, echo_data_mono_release, aec->echoDataResampled, echo_data_resampled_release);
}

void acousticEchoCancellerCaptureCleanup(JNIEnv *env, jbyteArray inputData, unsigned char *input_data, jbyteArray inputDataMono, unsigned char *input_data_mono, jbyteArray inputDataResampled, unsigned char *input_data_resampled, jbyteArray outputData, unsigned char *output_data, jbyteArray outputDataResampled, unsigned char *output_data_resampled)
{
    if (input_data)
    {
        env->ReleaseByteArrayElements(inputData, (jbyte *)input_data, JNI_ABORT); // JNI_ABORT is correct
    }
    if (input_data_mono)
    {
        env->ReleaseByteArrayElements(inputDataMono, (jbyte *)input_data_mono, JNI_ABORT); // JNI_ABORT is correct
    }
    if (input_data_resampled)
    {
        env->ReleaseByteArrayElements(inputDataResampled, (jbyte *)input_data_resampled, JNI_ABORT); // JNI_ABORT is correct
    }
    if (output_data)
    {
        env->ReleaseByteArrayElements(outputData, (jbyte *)output_data, 0); // 0 is correct
    }
    if (output_data_resampled)
    {
        env->ReleaseByteArrayElements(outputDataResampled, (jbyte *)output_data_resampled, JNI_ABORT); // JNI_ABORT is correct
    }
}

JNIEXPORT jbyteArray JNICALL Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerCapture
  (JNIEnv *env, jclass obj, jlong state, jbyteArray inputData, jint inputIndex, jint inputLength)
{
    AcousticEchoCanceller *aec = (AcousticEchoCanceller *)(intptr_t)state;
    
    int sampleCount = inputLength / 2;

    if (aec->outputData == NULL || env->GetArrayLength(aec->outputData) != inputLength)
    {
        if (aec->outputData)
        {
            env->DeleteGlobalRef(aec->outputData);
        }
        aec->outputData = (jbyteArray)env->NewGlobalRef(env->NewByteArray(inputLength));
    }
    
    unsigned char *input_data_release = NULL;
    unsigned char *input_data_mono_release = NULL;
    unsigned char *input_data_resampled_release = NULL;
    unsigned char *output_data_release = NULL;
    unsigned char *output_data_resampled_release = NULL;
    
    input_data_release = (unsigned char *)env->GetByteArrayElements(inputData, NULL);
    unsigned char *input_data = input_data_release + inputIndex;
    short *input_data_shorts = (short *)input_data;
    
    output_data_release = (unsigned char *)env->GetByteArrayElements(aec->outputData, NULL);
    unsigned char *output_data = output_data_release;
    short *output_data_shorts = (short *)output_data;
    
    // downsample input to mono
    if (aec->channels == 2)
    {
        sampleCount /= 2;

        if (aec->inputDataMono == NULL || env->GetArrayLength(aec->inputDataMono) != inputLength / 2)
        {
            if (aec->inputDataMono)
            {
                env->DeleteGlobalRef(aec->inputDataMono);
            }
            aec->inputDataMono = (jbyteArray)env->NewGlobalRef(env->NewByteArray(inputLength / 2));
        }

        input_data_mono_release = (unsigned char *)env->GetByteArrayElements(aec->inputDataMono, NULL);
        unsigned char *input_data_mono = input_data_mono_release;
        short *input_data_mono_shorts = (short *)input_data_mono;

        for (int i = 0, j = 0; i < sampleCount; i++, j+=2)
        {
            input_data_mono_shorts[i] = (short)(((int)input_data_shorts[j+0] + (int)input_data_shorts[j+1]) / 2);
        }

        input_data_shorts = input_data_mono_shorts;
    }
    
    // downsample input clock rate if needed
    if (aec->inputResampler)
    {
        int resampleCount = sampleCount * aec->internalClockRate / aec->clockRate;
        if (aec->inputDataResampled == NULL || env->GetArrayLength(aec->inputDataResampled) != resampleCount * sizeof(short))
        {
            if (aec->inputDataResampled)
            {
                env->DeleteGlobalRef(aec->inputDataResampled);
            }
            aec->inputDataResampled = (jbyteArray)env->NewGlobalRef(env->NewByteArray(resampleCount * sizeof(short)));
        }

        input_data_resampled_release = (unsigned char *)env->GetByteArrayElements(aec->inputDataResampled, NULL);
        unsigned char *input_data_resampled = input_data_resampled_release;
        short *input_data_resampled_shorts = (short *)input_data_resampled;

        if (aec->inputResampler->Push(input_data_shorts, sampleCount, input_data_resampled_shorts, resampleCount, sampleCount))
        {
            printf("Could not downsample input clock rate for acoustic echo canceller.");
            acousticEchoCancellerCaptureCleanup(env, inputData, input_data_release, aec->inputDataMono, input_data_mono_release, aec->inputDataResampled, input_data_resampled_release, aec->outputData, output_data_release, aec->outputDataResampled, output_data_resampled_release);
            return 0;
        }
        input_data_shorts = input_data_resampled_shorts;
    }

    // process input data
    for (int i = 0; i < sampleCount; i += aec->samplesPerBlock)
    {
        const short *in = input_data_shorts + i;
        short *out = output_data_shorts + i;
        if (WebRtcAecm_Process(aec->aec, in, NULL, out, aec->samplesPerBlock, aec->tailLength))
        {
            printf("Could not process input data for acoustic echo canceller.");
            acousticEchoCancellerCaptureCleanup(env, inputData, input_data_release, aec->inputDataMono, input_data_mono_release, aec->inputDataResampled, input_data_resampled_release, aec->outputData, output_data_release, aec->outputDataResampled, output_data_resampled_release);
            return 0;
        }
    }
    
    // upsample output clock rate if needed
    if (aec->outputResampler)
    {
        int resampleCount = sampleCount * aec->clockRate / aec->internalClockRate;
        if (aec->outputDataResampled == NULL || env->GetArrayLength(aec->outputDataResampled) != resampleCount * sizeof(short))
        {
            if (aec->outputDataResampled)
            {
                env->DeleteGlobalRef(aec->outputDataResampled);
            }
            aec->outputDataResampled = (jbyteArray)env->NewGlobalRef(env->NewByteArray(resampleCount * sizeof(short)));
        }

        output_data_resampled_release = (unsigned char *)env->GetByteArrayElements(aec->outputDataResampled, NULL);
        unsigned char *output_data_resampled = output_data_resampled_release;
        short *output_data_resampled_shorts = (short *)output_data_resampled;

        if (aec->outputResampler->Push(output_data_shorts, sampleCount, output_data_resampled_shorts, resampleCount, sampleCount))
        {
            printf("Could not upsample output clock rate for acoustic echo canceller.");
            acousticEchoCancellerCaptureCleanup(env, inputData, input_data_release, aec->inputDataMono, input_data_mono_release, aec->inputDataResampled, input_data_resampled_release, aec->outputData, output_data_release, aec->outputDataResampled, output_data_resampled_release);
            return 0;
        }

        memcpy(output_data, output_data_resampled, resampleCount * sizeof(short));
    }
    
    // upsample output to stereo
    if (aec->channels == 2)
    {
        for (int i = sampleCount - 1, j = (sampleCount * 2) - 1; i >= 0; i--, j-=2)
        {
            output_data_shorts[j-0] = output_data_shorts[i];
            output_data_shorts[j-1] = output_data_shorts[i];
        }
    }

    acousticEchoCancellerCaptureCleanup(env, inputData, input_data_release, aec->inputDataMono, input_data_mono_release, aec->inputDataResampled, input_data_resampled_release, aec->outputData, output_data_release, aec->outputDataResampled, output_data_resampled_release);
    return aec->outputData;
}