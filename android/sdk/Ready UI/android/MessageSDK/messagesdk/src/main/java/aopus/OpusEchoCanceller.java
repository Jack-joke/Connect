package aopus;

import android.os.Build;

import java.util.Locale;

import aaudioprocessing.AcousticEchoCanceller;
import fm.BitAssistant;
import fm.SingleAction;
import fm.icelink.webrtc.AudioBuffer;
import fm.icelink.webrtc.AudioMixer;

public class OpusEchoCanceller
{
    private static boolean x86 = false;
    private static boolean arm64 = false;
    static
    {
        if (Build.CPU_ABI.toLowerCase(Locale.getDefault()).contains("x86"))
        {
            x86 = true;
        }
        if (Build.CPU_ABI.toLowerCase(Locale.getDefault()).contains("arm64"))
        {
            arm64 = true;
        }
    }
    
    private AcousticEchoCanceller _acousticEchoCanceller;
    public AcousticEchoCanceller getAcousticEchoCanceller()
    {
        return _acousticEchoCanceller;
    }
    public void setAcousticEchoCanceller(AcousticEchoCanceller acousticEchoCanceller)
    {
        _acousticEchoCanceller = acousticEchoCanceller;
    }
    
    private AudioMixer _audioMixer;
    public AudioMixer getAudioMixer()
    {
        return _audioMixer;
    }
    public void setAudioMixer(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }
    
    private boolean enabled;
    
    public OpusEchoCanceller(int clockRate, int channels)
    {
        enabled = !x86 && !arm64;
        if (enabled)
        {
            _acousticEchoCanceller = new AcousticEchoCanceller(clockRate, channels, 300);
            _audioMixer = new AudioMixer(clockRate, channels, 20);
            _audioMixer.addOnFrame(new SingleAction<AudioBuffer>() { public void invoke(AudioBuffer frame) { onAudioMixerFrame(frame); } });
        }
    }

    public void start()
    {
        if (enabled)
        {
            _audioMixer.start();
        }
    }

    public void stop()
    {
        if (enabled)
        {
            _audioMixer.stop();
        }
    }

    public byte[] capture(AudioBuffer input)
    {
        if (enabled)
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
        if (enabled)
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
    }

    private void onAudioMixerFrame(AudioBuffer echoMixed)
    {
        if (enabled)
        {
            _acousticEchoCanceller.render(echoMixed.getData(), echoMixed.getIndex(), echoMixed.getLength());
        }
    }
}