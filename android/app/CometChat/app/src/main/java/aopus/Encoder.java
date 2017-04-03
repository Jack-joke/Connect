package aopus;

public class Encoder
{
    private long state;
    
    public int getBitrate()
    {
        return OpusLibrary.encoderGetBitrate(state);
    }
    
    public void setBitrate(int bitrate)
    {
        OpusLibrary.encoderSetBitrate(state, bitrate);
    }
    
    public double getQuality()
    {
        return OpusLibrary.encoderGetQuality(state);
    }
    
    public void setQuality(double quality)
    {
        OpusLibrary.encoderSetQuality(state, quality);
    }
	
	public Encoder(int clockRate, int channels, int packetTime)
	{
		try
		{
	        state = OpusLibrary.encoderCreate(clockRate, channels, packetTime);
		}
		catch (Exception ex)
		{
			ex.printStackTrace();
		}
	}
    
    public void activateFEC(int packetLossPercent)
    {
        OpusLibrary.encoderActivateFEC(state, packetLossPercent);
    }
    
    public void deactivateFEC()
    {
        OpusLibrary.encoderDeactivateFEC(state);
    }

    public void destroy()
    {
        try
        {
            OpusLibrary.encoderDestroy(state);
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }
    
    public byte[] encode(byte[] data, int index, int length)
    {
        return OpusLibrary.encoderEncode(state, data, index, length);
    }
}