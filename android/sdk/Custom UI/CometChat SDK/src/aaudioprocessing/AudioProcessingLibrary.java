package aaudioprocessing;

public class AudioProcessingLibrary
{
    static
    {
        System.loadLibrary("audioprocessing");
        System.loadLibrary("audioprocessingJNI");
    }
    
    public static native long   acousticEchoCancellerCreate(int clockRate, int channels, int tailLength);
    public static native void   acousticEchoCancellerDestroy(long state);
    public static native void   acousticEchoCancellerRender(long state, byte[] echoData, int echoIndex, int echoLength);
    public static native byte[] acousticEchoCancellerCapture(long state, byte[] inputData, int inputIndex, int inputLength);
}
