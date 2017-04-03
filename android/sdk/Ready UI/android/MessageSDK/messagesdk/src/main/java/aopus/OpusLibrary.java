package aopus;

public class OpusLibrary
{
    static
    {
        System.loadLibrary("opus");
        System.loadLibrary("opusJNI");
    }

    public static native int    encoderGetBitrate(long state);
    public static native void   encoderSetBitrate(long state, int bitrate);
    public static native double encoderGetQuality(long state);
    public static native void   encoderSetQuality(long state, double quality);
    public static native long   encoderCreate(int clockRate, int channels, int packetTime);
    public static native void   encoderActivateFEC(long state, int packetLossPercent);
    public static native void   encoderDeactivateFEC(long state);
    public static native void   encoderDestroy(long state);
    public static native byte[] encoderEncode(long state, byte[] data, int index, int length);
    
    public static native long   decoderCreate(int clockRate, int channels, int packetTime);
    public static native void   decoderDestroy(long state);
    public static native byte[] decoderDecode(long state, byte[] encodedData);
    public static native byte[] decoderDecode2(long state, byte[] encodedData, boolean fec);
}
