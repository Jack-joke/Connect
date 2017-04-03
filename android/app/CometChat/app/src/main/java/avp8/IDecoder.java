package avp8;

import fm.*;

public interface IDecoder
{
    public boolean hadCriticalFailure();
    public String getCodecName();
    public byte[] decode(byte[] encodedFrame, Holder<Integer> width, Holder<Integer> height);
    public void setNeedsKeyFrame();
    public boolean getNeedsKeyFrame();
    public void destroy();
}