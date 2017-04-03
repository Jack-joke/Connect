package aopus;

import android.annotation.SuppressLint;
import android.os.Build;

import java.util.Locale;

import aaudioprocessing.*;
import fm.*;
import fm.icelink.webrtc.*;

public class OpusEchoCanceller
{
    private static boolean x86 = false;
    private static boolean arm64 = false;
    static
    {
        if (getCpuAbi().toLowerCase(Locale.getDefault()).contains("x86"))
        {
            x86 = true;
        }
        if (getCpuAbi().toLowerCase(Locale.getDefault()).contains("arm64"))
        {
            arm64 = true;
        }
    }
    
    @SuppressLint("NewApi")
	@SuppressWarnings("deprecation")
	private static String getCpuAbi()
    {
    	if (Build.VERSION.SDK_INT < Build.VERSION_CODES.LOLLIPOP)
        {
        	return Build.CPU_ABI;
        }
        else
        {
        	return Build.SUPPORTED_ABIS[0];
        }
    }
    
    public static boolean isSupported()
    {
    	return !x86 && !arm64;
    }
    
    private AcousticEchoCanceller _acousticEchoCanceller;
    private AudioMixer _audioMixer;
    
    public OpusEchoCanceller(int clockRate, int channels)
    {
    	this(clockRate, channels, false);
    }
    
    public OpusEchoCanceller(int clockRate, int channels, boolean useMixer)
    {
        if (isSupported())
        {
            _acousticEchoCanceller = new AcousticEchoCanceller(clockRate, channels, 150);
            if (useMixer)
            {
	            _audioMixer = new AudioMixer(clockRate, channels, 20);
	            _audioMixer.addOnFrame(new SingleAction<AudioBuffer>() { public void invoke(AudioBuffer frame) { onAudioMixerFrame(frame); } });
            }
        }
    }

    public void start()
    {
        if (isSupported() && _audioMixer != null)
        {
            _audioMixer.start();
        }
    }

    public void stop()
    {
        if (isSupported() && _audioMixer != null)
        {
            _audioMixer.stop();
        }
    }

    public byte[] capture(AudioBuffer input)
    {
        if (isSupported())
        {
            return _acousticEchoCanceller.capture(input.getData(), input.getIndex(), input.getLength());
        }
        else
        {
            return BitAssistant.subArray(input.getData(), input.getIndex(), input.getLength());
        }
    }

    public void render(String peerId, AudioBuffer echo)
    {
        if (isSupported())
        {
        	if (_audioMixer != null)
        	{
	            try
	            {
	                _audioMixer.addSourceFrame(peerId, new AudioBuffer(echo.getData(), echo.getIndex(), echo.getLength()));
	            }
	            catch (Exception ex)
	            {
	                ex.printStackTrace();
	            }
        	}
        	else
        	{
        		_acousticEchoCanceller.render(echo.getData(), echo.getIndex(), echo.getLength());
        	}
        }
    }

    private void onAudioMixerFrame(AudioBuffer echoMixed)
    {
        if (isSupported())
        {
            _acousticEchoCanceller.render(echoMixed.getData(), echoMixed.getIndex(), echoMixed.getLength());
        }
    }
}