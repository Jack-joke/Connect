package avp8;

import android.annotation.SuppressLint;
import android.media.MediaCodecInfo;
import android.media.MediaCodecList;

import java.util.ArrayList;
import java.util.List;

import fm.Log;

@SuppressLint("NewApi")
public class HardwareUtility
{
    public static MediaCodecInfo[] getEncoderInfos(String mimeType)
    {
        return getCodecInfos(mimeType, true);
    }
    
    public static MediaCodecInfo[] getDecoderInfos(String mimeType)
    {
        return getCodecInfos(mimeType, false);
    }

    public static void logAvailableCodecs()
    {
    	int numCodecs = MediaCodecList.getCodecCount();
    	MediaCodecInfo codecInfo = null;

    	// Log Encoders
    	for (int i = 0; i < numCodecs && codecInfo == null; i++) 
    	{
    	   MediaCodecInfo info = MediaCodecList.getCodecInfoAt(i);
    	   if (info.isEncoder()) 
    	   {
	    	   String[] types = info.getSupportedTypes();
	    	   for (String s : types) 
	    	   {
	    	      Log.info("Available Encoder: mime: " + s + " decoder: " + info.getName());
	    	   }
	    	}
    	}

    	// Log Decoders
    	for (int i = 0; i < numCodecs && codecInfo == null; i++) 
    	{
    	   MediaCodecInfo info = MediaCodecList.getCodecInfoAt(i);
    	   if (info.isEncoder()) 
    	   {
    	      continue;
    	   }
    	   String[] types = info.getSupportedTypes();
    	   for (String s : types) 
    	   {
    	      Log.info("Available Decoder: mime: " + s + " decoder: " + info.getName());
    	   }
    	}
    }
    
    private static MediaCodecInfo[] getCodecInfos(String mimeType, boolean encoders)
    {
        List<MediaCodecInfo> codecInfos = new ArrayList<MediaCodecInfo>();
        for (int i = 0; i < MediaCodecList.getCodecCount(); i++)
        {
            MediaCodecInfo codecInfo = MediaCodecList.getCodecInfoAt(i);
            if (codecInfo.isEncoder() == encoders)
            {
                for (String supportedType : codecInfo.getSupportedTypes())
                {
                    if (supportedType.equalsIgnoreCase(mimeType))
                    {
                        codecInfos.add(codecInfo);
                        break;
                    }
                }
            }
        }
        return codecInfos.toArray(new MediaCodecInfo[codecInfos.size()]);
    }
    
    public static MediaCodecInfo[] filterCodecInfos(MediaCodecInfo[] codecInfos, String mimeType, int[] colorFormats)
    {
        List<MediaCodecInfo> filteredCodecInfos = new ArrayList<MediaCodecInfo>();
        for (int colorFormat : colorFormats)
        {
            for (MediaCodecInfo codecInfo : codecInfos)
            {
                for (int cf : codecInfo.getCapabilitiesForType(mimeType).colorFormats)
                {
                    if (cf == colorFormat)
                    {
                        filteredCodecInfos.add(codecInfo);
                        break;
                    }
                }
            }
            if (filteredCodecInfos.size() > 0)
            {
                return filteredCodecInfos.toArray(new MediaCodecInfo[filteredCodecInfos.size()]);
            }
        }
        return new MediaCodecInfo[0];
    }
}
