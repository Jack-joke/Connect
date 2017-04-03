package avp8;

public interface IEncoder
{
    public boolean hadCriticalFailure();
    public String getCodecName();
	public int getBitrate();
    public void setBitrate(int bitrate);
    public double getQuality();
    public void setQuality(double quality);
    public byte[] encode(int width, int height, byte[] frame, long fourcc, int rotation);
    public byte[] encode(int width, int height, byte[] frame, long fourcc, int rotation, int stride);
    public void forceKeyframe();
    public void destroy();
}
