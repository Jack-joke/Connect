package avp8;

import android.annotation.SuppressLint;
import android.media.MediaCodec;
import android.media.MediaCodecInfo;
import android.media.MediaFormat;
import android.os.Build;
import android.os.Bundle;

import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.Arrays;

import fm.Binary;
import fm.Log;

public class HardwareEncoder implements IEncoder
{
	public String codecName;
	
    private static String mimeType = "video/x-vnd.on2.vp8";
    private static int nv21FourccFormat = 825382478;
    private static int[] colorFormats = new int[] { MediaCodecInfo.CodecCapabilities.COLOR_FormatYUV420Planar };
    private boolean criticalFailure = false;

    private int bitrate;
    private double quality;
    private MediaCodec codec;
    private byte[] rotateFrame;
    private int currentWidth;
    private int currentHeight;
    private int currentBitrate;
    
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
        // not currently supported by MediaCodec API
        return quality;
    }
    
    public void setQuality(double quality)
    {
        // not currently supported by MediaCodec API
        this.quality = (quality < 0.0 ? 0.0 : (quality > 1.0 ? 1.0 : quality));
    }
    
	public HardwareEncoder()
	{        
        setBitrate(320);
        setQuality(0.5);
    }

	public static MediaCodecInfo getCodecInfo()
	{
		return HardwareEncoder.getCodecInfo(new ArrayList<String>());
	}
	
    public static MediaCodecInfo getCodecInfo(ArrayList<String> codecBlacklist)
    {
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.KITKAT)
        {
            Log.info("Android 4.4 or higher is required to use hardware VP8 encoding.");
            return null;
        }
        
        MediaCodecInfo[] encoderInfos = HardwareUtility.getEncoderInfos(mimeType);
        if (encoderInfos.length == 0)
        {
            Log.info("No hardware VP8 encoders were found.");
            return null;
        }
        
        encoderInfos = HardwareUtility.filterCodecInfos(encoderInfos, mimeType, colorFormats);
        if (encoderInfos.length == 0)
        {
            Log.info("No hardware VP8 encoders were found with a supported color format.");
            return null;
        }

		// Get the first codec that's not blacklisted
        boolean blacklisted = false;
        MediaCodecInfo encoderInfo = null;
        for (int i = 0; i < encoderInfos.length; i++)
        {
        	for (int j = codecBlacklist.size()-1; j >= 0; j--)
        	{
	        	if (codecBlacklist.get(j).equalsIgnoreCase(encoderInfos[i].getName()))
	        	{
	        		blacklisted = true;
	        	}
        	}
        	
        	if (!blacklisted)
        	{
        		encoderInfo = encoderInfos[i];
        		break;
        	}
        	
        	blacklisted = false;
        }

        return encoderInfo;
    }

    private void initCodec(int width, int height) throws Exception
    {
    	codecName = getCodecInfo().getName();
    	
        codec = MediaCodec.createByCodecName(codecName);
        
        MediaFormat format = MediaFormat.createVideoFormat(mimeType, width, height);
        
        format.setInteger(MediaFormat.KEY_BIT_RATE, bitrate * 1024);
        format.setInteger(MediaFormat.KEY_COLOR_FORMAT, colorFormats[0]);
        format.setInteger(MediaFormat.KEY_FRAME_RATE, 30);
        format.setInteger(MediaFormat.KEY_I_FRAME_INTERVAL, 1800); // i frame every minute
        format.setInteger("stride", width);
        format.setInteger("slice-height", height);
        
        currentWidth = width;
        currentHeight = height;
        currentBitrate = bitrate;
        
        codec.configure(format, null, null, MediaCodec.CONFIGURE_FLAG_ENCODE);
        codec.start();
    }
    
    public byte[] encode(int width, int height, byte[] frame, long fourcc, int rotation)
    {        
    	return encode(width, height, frame, fourcc, rotation, width);
    }
    
    public byte[] encode(int width, int height, byte[] frame, long fourcc, int rotation, int stride)
    {	
    	try
    	{
	    	if (fourcc == nv21FourccFormat)
	    	{
	        	if (rotateFrame == null || rotateFrame.length != frame.length)
	        	{
	        		rotateFrame = new byte[frame.length];
	        	}
	        	int pixelCount = width * height;
	
		    	// Y
		    	if (rotation == 0)
		    	{
			        rotateFrame = Arrays.copyOf(frame, frame.length);
		    	}
		    	else
		    	{
		    		Binary.transform(frame, rotateFrame, width, height, stride, rotation);
		    	}
	
		    	// UV
		        Binary.deinterleaveTransform(frame, pixelCount, rotateFrame, pixelCount, (width/2), (height/2), (stride/2), rotation, true);
                //Binary.deinterleaveTransform(frame, rotateFrame, (width/2), (height/2), (stride/2), rotation, pixelCount, true);
		        
		        frame = rotateFrame;
		        
		        if (rotation == 90 || rotation == 270)
		        {
		        	int temp = width;
		        	width = height;
		        	height = temp;
		        }
	    	}
	    	else 
	    	{
	    		Log.error("Unsupported image fourcc");
	    		return null;
	    	}
	    	
	        if (codec != null && (width != currentWidth || height != currentHeight || bitrate != currentBitrate))
	        {
	            codec.stop();
	            codec.release();
	            codec = null;
	        }
	        
	        if (codec == null)
	        {
	            initCodec(width, height);
	        }
	
	        ByteBuffer[] inputBuffers = codec.getInputBuffers();
	
	        int inputBufferIndex = codec.dequeueInputBuffer(-1);
	        if (inputBufferIndex < 0)
	        {
	            Log.error("Could not dequeue input buffer for hardware VP8 encoding.");
	            return null;
	        }
	 
	        ByteBuffer inputBuffer = inputBuffers[inputBufferIndex];
	
	        inputBuffer.position(0);
	        inputBuffer.limit(frame.length);
	        inputBuffer.put(frame);
	        
	        codec.queueInputBuffer(inputBufferIndex, 0, frame.length, 0, 0);
	        
	        return getEncodedFrame(0);
	    }
	    catch (Exception e)
	    {
	    	if (codec != null)
	    	{
		    	// Something went wrong. Possibly hardware.
		    	// Tear down the encoder and try again on the next frame.
		        codec.stop();
		        codec.release();
		        codec = null;
	    	}
	        criticalFailure = true;
	        
	        Log.error("Hardware encode failed for " + mimeType + " " + codecName + " \n" + e.getMessage());
	    }
    	
    	return null;
    }
    
    private byte[] getEncodedFrame(int iteration)
    {
        if (iteration >= 30)
        {
            return null;
        }
        
        ByteBuffer[] outputBuffers = codec.getOutputBuffers();
        
        MediaCodec.BufferInfo bufferInfo = new MediaCodec.BufferInfo();
        int outputBufferIndex = codec.dequeueOutputBuffer(bufferInfo, 0);
        if (outputBufferIndex >= 0)
        {
            ByteBuffer outputBuffer = outputBuffers[outputBufferIndex];
            if (bufferInfo.size == 0)
            {
                return null;
            }

            outputBuffer.position(bufferInfo.offset);
            outputBuffer.limit(bufferInfo.offset + bufferInfo.size);
            
            byte[] encodedFrame = new byte[bufferInfo.size];
            outputBuffer.get(encodedFrame);
            codec.releaseOutputBuffer(outputBufferIndex, false);
            return encodedFrame;
        }
        else if (outputBufferIndex == MediaCodec.INFO_OUTPUT_BUFFERS_CHANGED)
        {
            return getEncodedFrame(0);
        }
        else if (outputBufferIndex == MediaCodec.INFO_OUTPUT_FORMAT_CHANGED)
        {
            return getEncodedFrame(0);
        }
        else if (outputBufferIndex == MediaCodec.INFO_TRY_AGAIN_LATER)
        {
            return getEncodedFrame(iteration + 1);
        }
        return null;
    }

    @SuppressLint({ "InlinedApi", "NewApi" })
    public void forceKeyframe()
    {
        if (codec != null)
        {
            Bundle b = new Bundle();
            b.putInt(MediaCodec.PARAMETER_KEY_REQUEST_SYNC_FRAME, 0);
            codec.setParameters(b);
        }
    }

    public boolean hadCriticalFailure()
    {
    	return criticalFailure;
    }

    public String getCodecName()
    {
    	return codecName;
    }
    
    public void destroy()
    {
        if (codec != null)
        {
            codec.stop();
            codec.release();
            codec = null;
        }
    }
}
