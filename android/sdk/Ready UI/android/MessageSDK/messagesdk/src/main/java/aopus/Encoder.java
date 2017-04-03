package aopus;

public class Encoder
{
    private long state;
    
    public int getBitrate()
    {
        return aopus.OpusLibrary.encoderGetBitrate(state);
    }
    
    public void setBitrate(int bitrate)
    {
        aopus.OpusLibrary.encoderSetBitrate(state, bitrate);
    }
    
    public double getQuality()
    {
        return aopus.OpusLibrary.encoderGetQuality(state);
    }
    
    public void setQuality(double quality)
    {
        aopus.OpusLibrary.encoderSetQuality(state, quality);
    }
	
	public Encoder(int clockRate, int channels, int packetTime)
	{
		try
		{
	        state = aopus.OpusLibrary.encoderCreate(clockRate, channels, packetTime);
		}
		catch (Exception ex)
		{
			ex.printStackTrace();
		}
	}
    
    public void activateFEC(int packetLossPercent)
    {
        aopus.OpusLibrary.encoderActivateFEC(state, packetLossPercent);
    }
    
    public void deactivateFEC()
    {
        aopus.OpusLibrary.encoderDeactivateFEC(state);
    }

    public void destroy()
    {
        try
        {
            aopus.OpusLibrary.encoderDestroy(state);
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }
    
    public byte[] encode(byte[] data, int index, int length)
    {
        return aopus.OpusLibrary.encoderEncode(state, data, index, length);
    }
}