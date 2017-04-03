package fm.android.conference.webrtc;


import fm.SingleAction;
import fm.icelink.webrtc.GetMediaArgs;
import fm.icelink.webrtc.GetMediaFailureArgs;
import fm.icelink.webrtc.GetMediaSuccessArgs;
import fm.icelink.webrtc.LayoutScale;
import fm.icelink.webrtc.LocalMediaStream;
import fm.icelink.webrtc.UserMedia;

public class LocalMedia {

	private LocalMediaStream localStream;

	public LocalMediaStream getLocalStream() {
		return localStream;
	}

	private Object localVideoControl;

	public Object getLocalVideoControl() {
		return localVideoControl;
	}

	private Exception lastStartException = null;

	public Exception getLastStartException() {
		return lastStartException;
	}

	public void start(final SingleAction<Exception> callback, boolean video, boolean audio) {
		try {
			// Get a reference to the local media streams.
			UserMedia.getMedia(new GetMediaArgs(audio, video) {
                {
                    setVideoWidth(320);         // optional
                    setVideoHeight(240);       // optional
                    setVideoFrameRate(15); // optional
                    setDefaultVideoPreviewScale(LayoutScale.Contain); // optional
                    setDefaultVideoScale(LayoutScale.Contain);        // optional

                    setOnSuccess(new SingleAction<GetMediaSuccessArgs>() {
                        @Override
                        public void invoke(GetMediaSuccessArgs e) {
                            // Keep a reference to the local media
                            // and video preview control.
                            localStream = e.getLocalStream();
                            localVideoControl = e.getLocalVideoControl();
                            callback.invoke(null);
                        }
                    });
                    setOnFailure(new SingleAction<GetMediaFailureArgs>() {
                        @Override
                        public void invoke(GetMediaFailureArgs e) {
                            lastStartException = e.getException();
                            callback.invoke(e.getException());
                        }
                    });
                }
            });
		} catch (Exception ex) {
			lastStartException = ex;
			callback.invoke(ex);
		}
	}

	private Exception lastStopException = null;

	public Exception getLastStopException() {
		return lastStopException;
	}

	public void stop(final SingleAction<Exception> callback) {
		try {
			// Release our reference to the local media streams.
			if (localStream != null) {
				localStream.stop();
			}
			callback.invoke(null);
		} catch (Exception ex) {
			lastStopException = ex;
			callback.invoke(null);
		}
	}

	public void switchCamera() {
		if (localStream != null) {
			localStream.useNextVideoDevice();
		}
	}
}
