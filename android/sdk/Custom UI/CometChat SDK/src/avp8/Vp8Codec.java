package avp8;

import java.util.Locale;
import java.util.ArrayList;

import fm.*;
import fm.icelink.*;
import fm.icelink.webrtc.*;

public class Vp8Codec extends VideoCodec
{
    private Vp8Padep padep;
    private IEncoder encoder;
    private IDecoder decoder;
    private boolean preferHardwareEncoder = false;
    private boolean preferHardwareDecoder = false;
	private ArrayList<String> encoderBlacklist = new ArrayList<String>();
	private ArrayList<String> decoderBlacklist = new ArrayList<String>();

    public Vp8Codec()
    {
        padep = new Vp8Padep();
        
        // Blacklist some encoder/decoders
        encoderBlacklist.add(new String("OMX.google.vp8.encoder"));
        decoderBlacklist.add(new String("OMX.google.vp8.decoder"));
    }

    /// <summary>
    /// Encodes a frame.
    /// </summary>
    /// <param name="videoBuffer">The video buffer.</param>
    /// <returns></returns>
    public byte[] encode(VideoBuffer videoBuffer)
    {
        if (encoder == null || encoder.hadCriticalFailure())
        {
        	if (encoder != null)
        	{
        		// If there was a hardware failure, blacklist this
        		// codec and try a new one (or fallback to libvpx).
        		encoderBlacklist.add(encoder.getCodecName());
        		encoder.destroy();
        		encoder = null;
        	}
        	
            if (preferHardwareEncoder && HardwareEncoder.getCodecInfo(encoderBlacklist) != null)
            {
            	encoder = new HardwareEncoder();
            }
            
            if (encoder == null)
            {
                encoder = new Encoder();
                encoder.setQuality(0.5);
                encoder.setBitrate(320);
                //encoder.setScale(1.0);
            }
        }

        // frame -> vp8        
        return encoder.encode(videoBuffer.getWidth(), videoBuffer.getHeight(), videoBuffer.getPlane().getData(), videoBuffer.getFourCC(), videoBuffer.getRotate(), videoBuffer.getPlane().getStride());
    }

    /// <summary>
    /// Decodes an encoded frame.
    /// </summary>
    /// <param name="encodedFrame">The encoded frame.</param>
    /// <returns></returns>
    public VideoBuffer decode(byte[] encodedFrame)
    {
        if (decoder == null || decoder.hadCriticalFailure())
        {
        	if (decoder != null)
        	{
        		// There was a critical error with this codec, 
    			// blacklist it and try a new one.
        		decoderBlacklist.add(decoder.getCodecName());
        		decoder.destroy();
        		decoder = null;
        	}
        	
            if (preferHardwareDecoder && HardwareDecoder.getCodecInfo(decoderBlacklist) != null)
            {
            	decoder = new HardwareDecoder();
            }

            if (decoder == null)
            {
                decoder = new Decoder();
            }
        }

        if (padep.getSequenceNumberingViolated())
        {
            decoder.setNeedsKeyFrame();
            return null;
        }

        // vp8 -> frame
        Holder<Integer> width = new Holder<Integer>(null);
        Holder<Integer> height = new Holder<Integer>(null);
        byte[] frame = decoder.decode(encodedFrame, width, height);
        if (frame == null)
        {
            return null;
        }
        try
        {
            return new VideoBuffer(width.getValue(), height.getValue(), new VideoPlane(frame, width.getValue()), VideoFormat.I420);
        }
        catch (Exception ex)
        { 
            Log.error("Could not convert decoded image to video buffer.", ex);
            return null;
        }
    }

    /// <summary>
    /// Gets whether the decoder needs a keyframe. This
    /// is checked after every failed Decode operation.
    /// </summary>
    /// <returns></returns>
    public boolean decoderNeedsKeyFrame()
    {
        if (decoder == null)
        {
            return false;
        }
        return decoder.getNeedsKeyFrame();
    }

    /// <summary>
    /// Packetizes an encoded frame.
    /// </summary>
    /// <param name="encodedFrame">The encoded frame.</param>
    /// <returns></returns>
    public RTPPacket[] packetize(byte[] encodedFrame)
    {
        return padep.packetize(encodedFrame, getClockRate());
    }

    /// <summary>
    /// Depacketizes a packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    public byte[] depacketize(RTPPacket packet)
    {
        return padep.depacketize(packet);
    }
    
    private int lossyCount;
    private int losslessCount;

    /// <summary>
    /// Processes RTCP packets.
    /// </summary>
    /// <param name="packets">The packets to process.</param>
    public void processRTCP(RTCPPacket[] packets)
    {
        if (encoder != null)
        {
            for (int i = 0; i < packets.length; i++)
            {
                RTCPPacket packet = packets[i];
                if (packet instanceof RTCPPliPacket)
                {
                    encoder.forceKeyframe();
                }
                else if (packet instanceof RTCPReportPacket)
                {
                    RTCPReportPacket report = (RTCPReportPacket)packet;
                    for (RTCPReportBlock block : report.getReportBlocks())
                    {
                        fm.Log.debug(String.format(Locale.getDefault(), "VP8 report: %d%% packet loss (%d cumulative packets lost)", (int)(block.getPercentLost() * 100), block.getCumulativeNumberOfPacketsLost()));
                        if (block.getPercentLost() > 0)
                        {
                            losslessCount = 0;
                            lossyCount++;
                            if (lossyCount > 5 && (encoder.getQuality() > 0.0 || encoder.getBitrate() > 64 /* || encoder.getScale() > 0.2 */))
                            {
                                lossyCount = 0;
                                if (encoder.getQuality() > 0.0)
                                {
                                    encoder.setQuality(Math.max(0.0, encoder.getQuality() - 0.1));
                                    fm.Log.info(String.format(Locale.getDefault(), "Decreasing VP8 encoder quality to %d%%.", (int)(encoder.getQuality() * 100)));
                                }
                                if (encoder.getBitrate() > 64)
                                {
                                    encoder.setBitrate(Math.max(64, encoder.getBitrate() - 64));
                                    fm.Log.info(String.format(Locale.getDefault(), "Decreasing VP8 encoder bitrate to %d.", encoder.getBitrate()));
                                }
                                /*if (encoder.getScale() > 0.2)
                                {
                                    encoder.setScale(Math.max(0.2, encoder.getScale() - 0.2));
                                    fm.Log.info(String.format(Locale.getDefault(), "Decreasing VP8 encoder scale to %d%%.", (int)(encoder.getScale() * 100)));
                                }*/
                            }
                        }
                        else
                        {
                            lossyCount = 0;
                            losslessCount++;
                            if (losslessCount > 5 && (encoder.getQuality() < 1.0 || encoder.getBitrate() < 640 /* || encoder.getScale() < 1.0 */))
                            {
                                losslessCount = 0;
                                if (encoder.getQuality() < 1.0)
                                {
                                    encoder.setQuality(Math.min(1.0, encoder.getQuality() + 0.1));
                                    fm.Log.info(String.format(Locale.getDefault(), "Increasing VP8 encoder quality to %d%%.", (int)(encoder.getQuality() * 100)));
                                }
                                if (encoder.getBitrate() < 640)
                                {
                                    encoder.setBitrate(Math.min(640, encoder.getBitrate() + 64));
                                    fm.Log.info(String.format(Locale.getDefault(), "Increasing VP8 encoder bitrate to %d.", encoder.getBitrate()));
                                }
                                /*if (encoder.getScale() < 1.0)
                                {
                                    encoder.setScale(Math.min(1.0, encoder.getScale() + 0.2));
                                    fm.Log.info(String.format(Locale.getDefault(), "Increasing VP8 encoder scale to %d%%.", (int)(encoder.getScale() * 100)));
                                }*/
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
        if (encoder != null)
        {
            encoder.destroy();
            encoder = null;
        }

        if (decoder != null)
        {
            decoder.destroy();
            decoder = null;
        }
    }
}
