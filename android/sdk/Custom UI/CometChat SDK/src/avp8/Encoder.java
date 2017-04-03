package avp8;

import com.google.libvpx.*;

import fm.*;

public class Encoder implements IEncoder
{
    private LibVpxEnc codec;
    private LibVpxEncConfig config;
	private int frame_cnt;
	private int maxFramerate;
	private boolean sendKeyFrame;
    private int bitrate;
    private double quality;
    private int maxQuantizer;
    
    public int getBitrate()
    {
        return bitrate;
    }
    
    public void setBitrate(int bitrate)
    {
        this.bitrate = bitrate;
    }
    
    public double getQuality()
    {
        return quality;
    }
    
    public void setQuality(double quality)
    {
        this.quality = (quality < 0.0 ? 0.0 : (quality > 1.0 ? 1.0 : quality));
        
        int lowerBound = 31;
        int upperBound = 63;
        this.maxQuantizer = lowerBound + (int)((1.0 - this.quality) * (upperBound - lowerBound));
    }
	
	public Encoder()
	{
        frame_cnt = 0;
        maxFramerate = 30;
        
        setQuality(0.5);
        setBitrate(320);
        //setScale(1.0);
    }

	public byte[] encode(int width, int height, byte[] frame, long fourcc, int rotation)
	{
		return encode(width, height, frame, fourcc, rotation, width);
	}
	
	public byte[] encode(int width, int height, byte[] frame, long fourcc, int rotation, int stride)
	{
        try
        {
            if (rotation % 180 != 0)
            {
        		int tmp = width;
                width = height;
                height = tmp;
            }
            
            if (codec != null && (width != config.getWidth() || height != config.getHeight() || bitrate != config.getRCTargetBitrate() || maxQuantizer != config.getRCMaxQuantizer()))
            {
                if (codec != null)
                {
                    codec.close();
                    codec = null;
                }
                
                if (config != null)
                {
                    config.close();
                    config = null;
                }
            }
            
            if (codec == null)
            {
                // define configuration options
                config = new LibVpxEncConfig(width, height);
                config.setTimebase(1, 30);
                config.setRCTargetBitrate(bitrate);
                config.setRCEndUsage(1); // vpx_rc_mode.VPX_CBR
                //config.setKFMode(1); // vpx_kf_mode.VPX_KF_AUTO
                config.setKFMinDist((int)config.getTimebase().den() * 60); // 1 per min @ 30fps
                config.setKFMaxDist((int)config.getTimebase().den() * 60); // 1 per min @ 30fps
                config.setErrorResilient(1);
                config.setLagInFrames(0);
                config.setPass(0); // vpx_enc_pass.VPX_RC_ONE_PASS
                config.setRCMinQuantizer(0);
                config.setRCMaxQuantizer(maxQuantizer);
                config.setProfile(0);
    
                // initialize encoder
                codec = new LibVpxEnc(config);

                // additional tuning
                int VP8_ONE_TOKENPARTITION = 0;
                codec.setStaticThreshold(1);
                codec.setCpuUsed(-12); // only on mobile
                codec.setTokenPartitions(VP8_ONE_TOKENPARTITION);
                codec.setNoiseSensitivity(0);
                codec.setMaxIntraBitratePct(Math.min(300, (int)(config.getRCBufOptimalSz() * 0.5f * maxFramerate / 10)));
            }
            
    	    // set flags
    	    long flag = 0;
    	    if (sendKeyFrame)
    	    {
    	        flag |= (1<<0); // VPX_EFLAG_FORCE_KF;
    	        sendKeyFrame = false;
    	    }
    	    
            // encode
            long deadline = 1; // VPX_DL_REALTIME
            long duration = 90000 / maxFramerate;
            byte[] buffer = codec.convertByteEncodeFrame(
                    frame, frame_cnt, duration, flag, deadline, fourcc, rotation);

            frame_cnt++;

            // get frame
            return buffer;
        }
        catch (Exception ex)
        {
            Log.error("Could not encode frame.", ex);
        }

		return null;
	}
	
	public void forceKeyframe()
	{
		sendKeyFrame = true; 
	}

	public boolean hadCriticalFailure() 
	{
		// This software codec cannot have a "critical" failure.
		return false;
	}

	public String getCodecName() 
	{
		return "JNI.libvpx.encoder";
	}
	
    public void destroy()
	{
		try
		{
		    if (codec != null)
		    {
		        codec.close();
		        codec = null;
		    }
		    
		    if (config != null)
		    {
		        config.close();
		        config = null;
		    }
		}
		catch (Exception ex) { }
	}
}