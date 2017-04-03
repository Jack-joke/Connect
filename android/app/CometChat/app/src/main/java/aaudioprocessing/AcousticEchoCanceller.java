package aaudioprocessing;

public class AcousticEchoCanceller
{
    private long state;
    
    public AcousticEchoCanceller(int clockRate, int channels, int tailLength)
    {
        try
        {
            state = AudioProcessingLibrary.acousticEchoCancellerCreate(clockRate, channels, tailLength);
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }
    
    public void dispose()
    {
        try
        {
            AudioProcessingLibrary.acousticEchoCancellerDestroy(state);
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }
    
    protected void finalize()
    {
        dispose();
    }

    public void render(byte[] echoData, int echoIndex, int echoLength)
    {
        AudioProcessingLibrary.acousticEchoCancellerRender(state, echoData, echoIndex, echoLength);
    }

    public byte[] capture(byte[] inputData, int inputIndex, int inputLength)
    {
        return AudioProcessingLibrary.acousticEchoCancellerCapture(state, inputData, inputIndex, inputLength);
    }
}
