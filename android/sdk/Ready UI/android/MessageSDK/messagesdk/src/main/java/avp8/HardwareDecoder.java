package avp8;

import android.media.MediaCodec;
import android.media.MediaCodecInfo;
import android.media.MediaFormat;
import android.os.Build;

import java.nio.ByteBuffer;
import java.util.ArrayList;

import fm.Holder;
import fm.Log;

public class HardwareDecoder implements avp8.IDecoder
{
	public String codecName;
	
    private static String mimeType = "video/x-vnd.on2.vp8";
    private static int[] colorFormats = new int[] { MediaCodecInfo.CodecCapabilities.COLOR_FormatYUV420Planar };
    private boolean criticalFailure = false;

    private MediaCodec codec;
    private int currentWidth;
    private int currentHeight;
    private int currentStride;
    private int currentSliceHeight;
    private int currentColorFormat;
    private boolean needsKeyFrame;

    public static MediaCodecInfo getCodecInfo()
    {
    	return HardwareDecoder.getCodecInfo(new ArrayList<String>());
    }
    
    public static MediaCodecInfo getCodecInfo(ArrayList<String> codecBlacklist)
    {
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.KITKAT)
        {
            Log.info("Android 4.4 or higher is required to use hardware VP8 decoding.");
            return null;
        }
        
        MediaCodecInfo[] decoderInfos = avp8.HardwareUtility.getDecoderInfos(mimeType);
        if (decoderInfos.length == 0)
        {
            Log.info("No hardware VP8 decoders were found.");
            return null;
        }
        
        decoderInfos = avp8.HardwareUtility.filterCodecInfos(decoderInfos, mimeType, colorFormats);
        if (decoderInfos.length == 0)
        {
            Log.info("No hardware VP8 decoders were found with a supported color format.");
            return null;
        }

        boolean blacklisted = false;
        MediaCodecInfo decoderInfo = null;
        for (int i = 0; i < decoderInfos.length; i++)
        {
        	for (int j = codecBlacklist.size()-1; j >= 0; j--)
        	{
	        	if (codecBlacklist.get(j).equalsIgnoreCase(decoderInfos[i].getName()))
	        	{
	        		blacklisted = true;
	        	}
        	}
        	
        	if (!blacklisted)
        	{
        		decoderInfo = decoderInfos[i];
        		break;
        	}
        	
        	blacklisted = false;
        }
        
        return decoderInfo;
    }
    
    public HardwareDecoder()
    {
        currentWidth = 320;
        currentHeight = 240;
        currentStride = 0;
        currentSliceHeight = 0;
        currentColorFormat = colorFormats[0];
    }

    private void initCodec() throws Exception
    {
        MediaFormat format = MediaFormat.createVideoFormat(mimeType, currentWidth, currentHeight);
        format.setInteger(MediaFormat.KEY_COLOR_FORMAT, currentColorFormat);

        codecName = getCodecInfo().getName();
        codec = MediaCodec.createByCodecName(codecName);
        codec.configure(format, null, null, 0);
        codec.start();
    }
    
    public byte[] decode(byte[] encodedFrame, Holder<Integer> width, Holder<Integer> height)
    {
        try 
        {
	    	if (codec == null)
	    	{
	    		initCodec();
	    	}
		    	
	        ByteBuffer[] inputBuffers = codec.getInputBuffers();
	
	        int inputBufferIndex = codec.dequeueInputBuffer(-1);
	        if (inputBufferIndex >= 0)
	        {
	            ByteBuffer inputBuffer = inputBuffers[inputBufferIndex];
	            inputBuffer.clear();
	            inputBuffer.put(encodedFrame);
	            codec.queueInputBuffer(inputBufferIndex, 0, encodedFrame.length, 0, 0);
	        }
	        
	        return getFrame(encodedFrame, width, height, 0);
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
	        
	        Log.error("Hardware decode failed for " + mimeType + "\n" + e.getMessage());
        }
        
        return null;
    }
    
    private byte[] getFrame(byte[] encodedFrame, Holder<Integer> width, Holder<Integer> height, int iteration)
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

            byte[] frame = new byte[(int)(currentWidth * currentHeight * 1.5)];
            
            int frameOffset = 0;
            int stride = currentStride > 0 ? currentStride : (int)(bufferInfo.size / (1.5 * currentWidth));
            int sliceHeight = currentSliceHeight > 0 ? currentSliceHeight : currentHeight;
            int padding = stride - currentWidth;
            
            if (padding == 0)
            {
            	outputBuffer.get(frame);
            }
            else
            {
            	// Strip padding
	            for (int i = 0; i < currentHeight; i++) // Y
	            {
	                outputBuffer.get(frame, frameOffset, currentWidth);
	                frameOffset += currentWidth;
	                outputBuffer.position(outputBuffer.position() + padding);
	            }
	            
	            outputBuffer.position(outputBuffer.position() + ((sliceHeight - currentHeight) * stride));
	            
	            for (int i = 0; i < currentHeight/2; i++) // U
	            {
	                outputBuffer.get(frame, frameOffset, currentWidth/2);
	                frameOffset += currentWidth/2;
	                outputBuffer.position(outputBuffer.position() + padding);
	            }
	            	            
	            for (int i = 0; i < currentHeight/2; i++) // V
	            {
	                outputBuffer.get(frame, frameOffset, currentWidth/2);
	                frameOffset += currentWidth/2;
	                outputBuffer.position(outputBuffer.position() + padding);
	            }
            }     
	         
            codec.releaseOutputBuffer(outputBufferIndex, false);
            
            width.setValue(currentWidth);
            height.setValue(currentHeight);
            return frame;
        }
        else if (outputBufferIndex == MediaCodec.INFO_OUTPUT_BUFFERS_CHANGED)
        {
            return getFrame(encodedFrame, width, height, 0);
        }
        else if (outputBufferIndex == MediaCodec.INFO_OUTPUT_FORMAT_CHANGED)
        {
            MediaFormat outputFormat = codec.getOutputFormat();
            currentWidth = outputFormat.getInteger(MediaFormat.KEY_WIDTH);
            currentHeight = outputFormat.getInteger(MediaFormat.KEY_HEIGHT);
            currentStride = outputFormat.getInteger("stride");
            currentSliceHeight = outputFormat.getInteger("slice-height");
            currentColorFormat = outputFormat.getInteger(MediaFormat.KEY_COLOR_FORMAT);
            return getFrame(encodedFrame, width, height, 0);
        }
        else if (outputBufferIndex == MediaCodec.INFO_TRY_AGAIN_LATER)
        {
            return getFrame(encodedFrame, width, height, iteration + 1);
        }
        return null;
    }
    
    public void setNeedsKeyFrame()
    {
        needsKeyFrame = true;
    }
    
    public boolean getNeedsKeyFrame()
    {
        return needsKeyFrame;
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
        codec.stop();
        codec.release();
    }
}
