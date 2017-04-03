package aopus;

import java.util.Locale;

import fm.Log;
import fm.MathAssistant;
import fm.icelink.RTCPPacket;
import fm.icelink.RTCPReportBlock;
import fm.icelink.RTCPReportPacket;
import fm.icelink.RTPPacket;
import fm.icelink.webrtc.AudioBuffer;
import fm.icelink.webrtc.AudioCodec;
import fm.icelink.webrtc.BasicAudioPadep;
import fm.icelink.webrtc.LinkExtensions;

public class OpusCodec extends AudioCodec {

    private BasicAudioPadep _padep;
    private Encoder _encoder;
    private Decoder _decoder;
    
    private aopus.OpusEchoCanceller _echoCanceller;
    public aopus.OpusEchoCanceller getEchoCanceller()
    {
        return _echoCanceller;
    }
    public void setEchoCanceller(aopus.OpusEchoCanceller echoCanceller)
    {
        _echoCanceller = echoCanceller;
    }
    
    private int _percentLossToTriggerFEC;
    public int getPercentLossToTriggerFEC()
    {
        return _percentLossToTriggerFEC;
    }
    public void setPercentLossToTriggerFEC(int percentLossToTriggerFEC)
    {
        _percentLossToTriggerFEC = percentLossToTriggerFEC;
    }
    
    private boolean _disableFEC;
    public boolean getDisableFEC()
    {
        return _disableFEC;
    }
    public void setDisableFEC(boolean disableFEC)
    {
        _disableFEC = disableFEC;
    }
    
    private boolean _fecActive;
    
    public OpusCodec()
    {
        this(null);
    }

    public OpusCodec(aopus.OpusEchoCanceller echoCanceller)
    {
        super(20);
        
        _disableFEC = false;
        _percentLossToTriggerFEC = 5;
        
        _echoCanceller = echoCanceller;
        _padep = new BasicAudioPadep();
    }

    /// <summary>
    /// Encodes a frame.
    /// </summary>
    /// <param name="frame">The frame.</param>
    /// <returns></returns>
    public byte[] encode(AudioBuffer frame)
    {
        if (_encoder == null)
        {
            _encoder = new Encoder(getClockRate(), getChannels(), getPacketTime());
            _encoder.setQuality(1.0);
            _encoder.setBitrate(125);
        }
        
        byte[] data; int index; int length;
        aopus.OpusEchoCanceller echoCanceller = getEchoCanceller();
        if (echoCanceller == null)
        {
            data = frame.getData();
            index = frame.getIndex();
            length = frame.getLength();
        }
        else
        {
            data = echoCanceller.capture(frame);
            index = 0;
            length = data.length;
        } 
        
        return _encoder.encode(data, index, length);
    }

    private int _currentRTPSequenceNumber = -1;
    private int _lastRTPSequenceNumber = -1;

    /// <summary>
    /// Decodes an encoded frame.
    /// </summary>
    /// <param name="encodedFrame">The encoded frame.</param>
    /// <returns></returns>
    public AudioBuffer decode(byte[] encodedFrame)
    {
        if (_decoder == null)
        {
            _decoder = new Decoder(getClockRate(), getChannels(), getPacketTime());
            LinkExtensions.getRemoteStream(getLink()).setDisablePLC(true);
        }

        if (_lastRTPSequenceNumber == -1)
        {
            _lastRTPSequenceNumber = _currentRTPSequenceNumber;
            return decodeNormal(encodedFrame);
        }
        else
        {
            int sequenceNumberDelta = RTPPacket.getSequenceNumberDelta(_currentRTPSequenceNumber, _lastRTPSequenceNumber);
            _lastRTPSequenceNumber = _currentRTPSequenceNumber;

            int missingPacketCount = sequenceNumberDelta - 1;
            AudioBuffer[] previousFrames = new AudioBuffer[missingPacketCount];

            int plcFrameCount = (missingPacketCount > 1) ? missingPacketCount - 1 : 0;
            if (plcFrameCount > 0)
            {
                Log.info(String.format(Locale.getDefault(), "Adding %d frames of loss concealment to incoming audio stream. Packet sequence violated.", plcFrameCount));
                for (int i = 0; i < plcFrameCount; i++)
                {
                    previousFrames[i] = decodePLC();
                }
            }

            int fecFrameCount = (missingPacketCount > 0) ? 1 : 0;
            if (fecFrameCount > 0)
            {
                AudioBuffer fecFrame = decodeFEC(encodedFrame);
                int fecFrameIndex = missingPacketCount - 1;
                if (fecFrame == null)
                {
                    previousFrames[fecFrameIndex] = decodePLC();
                }
                else
                {
                    previousFrames[fecFrameIndex] = fecFrame;
                }
            }
            
            AudioBuffer frame = decodeNormal(encodedFrame);
            frame.setPreviousBuffers(previousFrames);
            return frame;
        }
    }

    private AudioBuffer decodePLC()
    {
        return decode(null, false);
    }

    private AudioBuffer decodeFEC(byte[] encodedFrame)
    {
        return decode(encodedFrame, true);
    }

    private AudioBuffer decodeNormal(byte[] encodedFrame)
    {
        return decode(encodedFrame, false);
    }

    private AudioBuffer decode(byte[] encodedFrame, boolean fec)
    {
        byte[] data = _decoder.decode(encodedFrame, fec);
        if (data == null)
        {
            return null;
        }

        AudioBuffer frame = new AudioBuffer(data, 0, data.length);
        aopus.OpusEchoCanceller echoCanceller = getEchoCanceller();
        if (echoCanceller != null)
        {
            echoCanceller.render(getPeerId(), frame);
        }
        return frame;
    }

    /// <summary>
    /// Packetizes an encoded frame.
    /// </summary>
    /// <param name="encodedFrame">The encoded frame.</param>
    /// <returns></returns>
    public RTPPacket[] packetize(byte[] encodedFrame)
    {
        return _padep.packetize(encodedFrame, getClockRate(), getPacketTime(), getResetTimestamp());
    }

    /// <summary>
    /// Depacketizes a packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    public byte[] depacketize(RTPPacket packet)
    {
        _currentRTPSequenceNumber = packet.getSequenceNumber();
        
        return _padep.depacketize(packet);
    }

    private int _lossyCount = 0;
    private int _losslessCount = 0;

    private int _minimumReportsBeforeFEC = 1;
    private long _reportsReceived = 0;

    /// <summary>
    /// Processes RTCP packets.
    /// </summary>
    /// <param name="packets">The packets to process.</param>
    public void processRTCP(RTCPPacket[] packets)
    {
        if (_encoder != null)
        {
            for (RTCPPacket packet : packets)
            {
                if (packet instanceof RTCPReportPacket)
                {
                    _reportsReceived++;

                    RTCPReportPacket report = (RTCPReportPacket)packet;
                    for (RTCPReportBlock block : report.getReportBlocks())
                    {
                        Log.debug(String.format(Locale.getDefault(), "Opus report: %.2f %% packet loss (%d cumulative packets lost)", block.getPercentLost() * 100, block.getCumulativeNumberOfPacketsLost()));
                        if (block.getPercentLost() > 0)
                        {
                            _losslessCount = 0;
                            _lossyCount++;
                            if (_lossyCount > 5 && _encoder.getQuality() > 0.0)
                            {
                                _lossyCount = 0;
                                _encoder.setQuality(MathAssistant.max(0.0, _encoder.getQuality() - 0.1));
                                Log.info(String.format(Locale.getDefault(), "Decreasing Opus encoder quality to %.2f %%.", _encoder.getQuality() * 100));
                            }
                        }
                        else
                        {
                            _lossyCount = 0;
                            _losslessCount++;
                            if (_losslessCount > 5 && _encoder.getQuality() < 1.0)
                            {
                                _losslessCount = 0;
                                _encoder.setQuality(MathAssistant.min(1.0, _encoder.getQuality() + 0.1));
                                Log.info(String.format(Locale.getDefault(), "Increasing Opus encoder quality to %.2f %%.", _encoder.getQuality() * 100));
                            }
                        }

                        if (!_disableFEC && !_fecActive && _reportsReceived > _minimumReportsBeforeFEC)
                        {
                            if ((block.getPercentLost() * 100) > _percentLossToTriggerFEC)
                            {
                                Log.info("Activating FEC for Opus audio stream.");
                                _encoder.activateFEC(_percentLossToTriggerFEC);
                                _fecActive = true;
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Destroys the codec.
    /// </summary>
    public void destroy()
    {
        if (_encoder != null)
        {
            _encoder.destroy();
            _encoder = null;
        }

        if (_decoder != null)
        {
            _decoder.destroy();
            _decoder = null;
        }
    }
}
