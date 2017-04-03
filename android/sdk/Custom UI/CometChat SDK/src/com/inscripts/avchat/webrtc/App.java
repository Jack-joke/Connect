package com.inscripts.avchat.webrtc;

import org.json.JSONObject;

import android.view.View;
import android.view.ViewGroup;
import aopus.OpusCodec;
import aopus.OpusEchoCanceller;
import avp8.Vp8Codec;

import com.inscripts.callbacks.Callbacks;

import fm.EmptyFunction;
import fm.Log;
import fm.SingleAction;
import fm.icelink.Certificate;
import fm.icelink.Conference;
import fm.icelink.Link;
import fm.icelink.LinkDownArgs;
import fm.icelink.LinkInitArgs;
import fm.icelink.LinkUpArgs;
import fm.icelink.Stream;
import fm.icelink.StreamLinkDownArgs;
import fm.icelink.StreamLinkInitArgs;
import fm.icelink.webrtc.AndroidLayoutManager;
import fm.icelink.webrtc.AudioCodec;
import fm.icelink.webrtc.AudioStream;
import fm.icelink.webrtc.LinkExtensions;
import fm.icelink.webrtc.VideoCodec;
import fm.icelink.webrtc.VideoStream;
import fm.icelink.websync.BaseLinkArgsExtensions;
import fm.icelink.websync.PeerClient;
import fm.websync.Record;

public class App {
	// Change the STUN/TURN server address
	// and port as needed for your environment.
	// Any STUN/TURN server will work. STUN is
	// required for WAN connections, and TURN
	// is required in some special cases. Peers
	// are not required to use the same server.
	private int icelinkServerPort = 3478; // 3478 is the default STUN/TURN port

	private Signalling signalling;
	private LocalMedia localMedia;
	private Conference conference;
	private Link peerLink;
	private String roomName;
	private static Certificate certificate;
	private static OpusEchoCanceller opusEchoCanceller = null;
	private static int opusClockRate = 48000, opusChannels = 2;

	static {
		// Log to the console.
		// Log.setProvider(new AndroidLogProvider(LogLevel.Info));

		try {
			// WebRTC has chosen VP8 as its mandatory video codec.
			// Since video encoding is best done using native code,
			// reference the video codec at the application-level.
			// This is required when using a WebRTC video stream.
			VideoStream.registerCodec("VP8", new EmptyFunction<VideoCodec>() {
				@Override
				public VideoCodec invoke() {
					return new Vp8Codec();
				}
			}, true);

			// For improved audio quality, we can use Opus. By
			// setting it as the preferred audio codec, it will
			// override the default PCMU/PCMA codecs.
			AudioStream.registerCodec("opus", opusClockRate, opusChannels, new EmptyFunction<AudioCodec>() {
				@Override
				public AudioCodec invoke() {
					return new OpusCodec(opusEchoCanceller);
				}
			}, true);

			// To save time, generate a DTLS certificate when the
			// app starts and reuse it for multiple conferences.
			certificate = Certificate.generateCertificate();
		} catch (Exception ex) {
			ex.printStackTrace();
		}
	}

	private static App app;

	public static synchronized App getInstance() {
		if (app == null) {
			app = new App();
		}
		return app;
	}

	private App() {
	}

	public boolean signallingStarted() {
		return (signalling != null);
	}

	public void startSignalling(SingleAction<String> callback, String websyncUrl, String userId, boolean isBroadcast,
			boolean isInitiator) {
		// if (signalling == null) {
		// Create and start the signalling engine.
		try {
			signalling = new Signalling(websyncUrl);
			signalling.start(callback, userId, isBroadcast, isInitiator);
		} catch (Exception e) {
			e.printStackTrace();
		}
		/*
		 * } else { callback.invoke(signalling.getLastStartException()); }
		 */
	}

	public boolean localMediaStarted() {
		return (localMedia != null);
	}

	public void startLocalMedia(SingleAction<Exception> callback, boolean video, boolean audio) {
		if (localMedia == null) {
			// Create and start the local media engine.
			localMedia = new LocalMedia();
			localMedia.start(callback, video, audio);
		} else {
			callback.invoke(localMedia.getLastStartException());
		}
	}

	public boolean conferenceStarted() {
		return (conference != null);
	}

	private Exception lastStartConferenceException = null;

	public void startConference(String iceLinkServerAddress, String roomName, boolean videoTrue,
			ViewGroup videoContainer, final SingleAction<Exception> callback, boolean isBroadcast, boolean isInitiator,
			final Callbacks callbacks) {
		if (!signallingStarted()) {
			callback.invoke(new Exception("Signalling must be started first."));
		} else if (!localMediaStarted()) {
			callback.invoke(new Exception("Local media must be started first."));
		} else if (conference != null) {
			callback.invoke(lastStartConferenceException);
		} else {
			try {
				// This is our local video control, a Java Component
				// or Android View. It is constantly updated with our
				// live video feed since we requested video above. Add
				// it directly to the UI or use the IceLink layout manager,
				// which we do below.
				Object localVideoControl = localMedia.getLocalVideoControl();

				// Create an IceLink layout manager, which makes the task
				// of arranging video controls easy. Give it a reference
				// to a Java Container that can be filled with video feeds.
				// For Android users, the WebRTC extension includes
				// AndroidLayoutManager, which accepts an Android ViewGroup.
				final AndroidLayoutManager layoutManager = new AndroidLayoutManager(videoContainer);

				// Position and display the local video control on-screen
				// by passing it to the layout manager created above.
				layoutManager.setLocalVideoControl(localVideoControl);

				// Create a WebRTC audio stream description (requires a
				// reference to the local audio feed).
				AudioStream audioStream = new AudioStream(localMedia.getLocalStream());

				// Create a WebRTC video stream description (requires a
				// reference to the local video feed). Whenever a P2P link
				// initializes using this description, position and display
				// the remote video control on-screen by passing it to the
				// layout manager created above. Whenever a P2P link goes
				// down, remove it.

				if (isBroadcast) {
					VideoStream videoStream = new VideoStream(localMedia.getLocalStream());
					videoStream.addOnLinkInit(new SingleAction<StreamLinkInitArgs>() {
						@Override
						public void invoke(final StreamLinkInitArgs e) {
							Record record = BaseLinkArgsExtensions.getPeerClient(e).getBoundRecords().get("hasVideo");
							if (null != record.getValueJson() && record.getValueJson().toString().equals("false")) {
								Object remoteVideoControl = LinkExtensions.getRemoteVideoControl(e.getLink());
								try {
									layoutManager.addRemoteVideoControl(e.getPeerId(), remoteVideoControl);

								} catch (Exception e1) {
									android.util.Log.e("Webrtc_library",
											"Add on link init exception " + e1.getLocalizedMessage());
									e1.printStackTrace();
								}
								peerLink = e.getLink();
							} else if (null == record.getValueJson()) {
								Object remoteVideoControl = LinkExtensions.getRemoteVideoControl(e.getLink());
								try {
									layoutManager.addRemoteVideoControl(e.getPeerId(), remoteVideoControl);
								} catch (Exception e1) {
									android.util.Log.e("Webrtc_library",
											"Add on link init exception " + e1.getLocalizedMessage());
									e1.printStackTrace();
								}
								peerLink = e.getLink();
							}

						}
					});
					videoStream.addOnLinkDown(new SingleAction<StreamLinkDownArgs>() {
						@Override
						public void invoke(final StreamLinkDownArgs e) {
							try {
								layoutManager.removeRemoteVideoControl(e.getPeerId());
							} catch (Exception e1) {
								android.util.Log.e("Webrtc_library",
										"AddOnLinkDown exception " + e1.getLocalizedMessage());
								e1.printStackTrace();
							}
						}
					});
					conference = new Conference(iceLinkServerAddress, icelinkServerPort, new Stream[] { audioStream,
							videoStream });
				} else {
					if (videoTrue) {
						VideoStream videoStream = new VideoStream(localMedia.getLocalStream());
						videoStream.addOnLinkInit(new SingleAction<StreamLinkInitArgs>() {
							@Override
							public void invoke(final StreamLinkInitArgs e) {
								/*String userId = "";
								PeerClient client = BaseLinkArgsExtensions.getPeerClient(e);
								if (client.getBoundRecords().containsKey("userId")) {
									Record record = client.getBoundRecords().get("userId");
									if (null != record.getValueJson()) {
										userId = record.getValueJson().toString();
									}
								}
								try {
									JSONObject json = new JSONObject();
									json.put("Connected_user", userId);
									callbacks.successCallback(json);
								} catch (Exception ee) {
									ee.printStackTrace();
								}*/
								Object remoteVideoControl = LinkExtensions.getRemoteVideoControl(e.getLink());
								try {
									layoutManager.addRemoteVideoControl(e.getPeerId(), remoteVideoControl);
								} catch (Exception e1) {
									android.util.Log.e("Webrtc_library",
											"Add on link init exception " + e1.getLocalizedMessage());
									e1.printStackTrace();
								}
								peerLink = e.getLink();
							}
						});
						videoStream.addOnLinkDown(new SingleAction<StreamLinkDownArgs>() {
							@Override
							public void invoke(final StreamLinkDownArgs e) {
								try {
									layoutManager.removeRemoteVideoControl(e.getPeerId());
								} catch (Exception e1) {
									android.util.Log.e("Webrtc_library",
											"AddOnLinkDown exception " + e1.getLocalizedMessage());
									e1.printStackTrace();
								}
							}
						});

						conference = new Conference(iceLinkServerAddress, icelinkServerPort, new Stream[] {
								audioStream, videoStream });
					} else {
						audioStream.addOnLinkInit(new SingleAction<StreamLinkInitArgs>() {
							@Override
							public void invoke(StreamLinkInitArgs e) {
								String userId = "";
								PeerClient client = BaseLinkArgsExtensions.getPeerClient(e);
								if (client.getBoundRecords().containsKey("userId")) {
									Record record = client.getBoundRecords().get("userId");
									if (null != record.getValueJson()) {
										userId = record.getValueJson().toString();
									}
								}

								try {
									JSONObject json = new JSONObject();
									json.put("Connected_user", userId);
									callbacks.successCallback(json);
								} catch (Exception ee) {
									ee.printStackTrace();
								}
							}
						});
						conference = new Conference(iceLinkServerAddress, icelinkServerPort,
								new Stream[] { audioStream });
					}
				}

				// Create a conference using our stream descriptions.

				// Use our pre-generated DTLS certificate.
				conference.setDtlsCertificate(certificate);

				// Supply TURN relay credentials in case we are behind a
				// highly restrictive firewall. These credentials will be
				// verified by the TURN server.
				conference.setRelayUsername("test");
				conference.setRelayPassword("pa55w0rd!");

				/*
				 * conference.setSuppressPrivateCandidates(true);
				 * conference.setSuppressPublicCandidates(true);
				 */

				// Add a few event handlers to the conference so we can see
				// when a new P2P link is created or changes state.
				conference.addOnLinkInit(new SingleAction<LinkInitArgs>() {
					@Override
					public void invoke(LinkInitArgs e) {
						Log.info("Link to peer initializing...");
						// peerLink = e.getLink();
					}
				});
				conference.addOnLinkUp(new SingleAction<LinkUpArgs>() {
					@Override
					public void invoke(LinkUpArgs e) {
						Log.info("Link to peer is UP.");
					}
				});
				conference.addOnLinkDown(new SingleAction<LinkDownArgs>() {
					@Override
					public void invoke(LinkDownArgs e) {
						Log.info("Link to peer is DOWN. " + e.getException().getMessage());
					}
				});

				try {
					opusEchoCanceller = new OpusEchoCanceller(opusClockRate, opusChannels);
					opusEchoCanceller.start();
				} catch (Exception e) {
					e.printStackTrace();
				} catch (Error e) {
					e.printStackTrace();
				}

				this.roomName = roomName;
				signalling.attach(conference, roomName, new SingleAction<String>() {
					@Override
					public void invoke(String ex) {
						if (ex != null) {
							// ex = new
							// Exception("Could not attach signalling to conference.",
							// ex);
							// lastStartConferenceException = ex;
							Log.error("Could not attach signalling to conference." + ex);
						}
						// callback.invoke(ex);
					}
				});
			} catch (Exception ex) {
				lastStartConferenceException = ex;
				callback.invoke(ex);
			}
		}
	}

	public void switchCamera() {
		if (localMedia != null) {
			localMedia.switchCamera();
		}
	}

	/**
	 * Ends the current video call Stops the local media (Camera , mircophone)
	 * used for current call Leave the current conference Stops the signalling
	 */
	public void endCall() {
		if (localMedia != null) {
			localMedia.stop(new SingleAction<Exception>() {

				@Override
				public void invoke(Exception ex) {
					if (ex != null) {
						// alert("Could not start signalling. %s",
						// ex.getMessage());
						Log.error("Could not start signalling. " + ex.getMessage());
					}
				}
			});
		}
		if (signalling != null) {
			try {
				signalling.leaveConference(roomName, new SingleAction<String>() {

					@Override
					public void invoke(String error) {
						// alert("Could not start signalling. %s",
						// ex.getMessage());
						Log.error("Could not start signalling. " + error);
					}
				});
			} catch (Exception e) {
				e.printStackTrace();
			}

			try {
				signalling.stop(new SingleAction<String>() {

					@Override
					public void invoke(String ex) {
						if (ex != null) {
							// alert("Could not start signalling. %s",
							// ex.getMessage());
							Log.error("Could not start signalling. " + ex);
						}
					}
				});
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
		if (conference != null) {
			try {
				conference.unlinkAll();
			} catch (Exception e) {
				Log.error("Conference unlinkall exception " + e.getMessage());
				e.printStackTrace();
			}
		}

		conference = null;
		localMedia = null;
		signalling = null;
		if (null != opusEchoCanceller) {
			opusEchoCanceller.stop();
			opusEchoCanceller = null;
		}
		Log.error("Leave conference done ,signallng and localmedia stopped");
	}

	/**
	 * Mute/Unmute incoming audio
	 * 
	 * @param mute
	 *            : <br />
	 *            <i>true</i> mutes the audio <br/>
	 *            <i>false</i> unmute the audio
	 **/
	public void muteAudio(boolean mute) {
		if (peerLink != null) {
			if (mute) {
				/* Other user will not hear your audio */
				localMedia.getLocalStream().muteAudio();
				// Log.error("Peerlink in mute = " + peerLink.getPeerId());
				/* Mutes incoming audio */
				// LinkExtensions.muteRemoteVideo(peerLink);
			} else {
				localMedia.getLocalStream().unmuteAudio();
				Log.error("Peerlink in unmute = " + peerLink.getPeerId());
				// LinkExtensions.unmuteRemoteVideo(peerLink);
			}
		}
	}

	/**
	 * Publish / Unpublish local video to other user
	 * 
	 * @param send
	 *            : <br />
	 *            <i>true</i> video will be published to other user <br />
	 *            <i>false</i> video will not be published to other user
	 **/
	public void publishLocalVideo(boolean send) {
		try {
			if (send) {
				/* Other user will not get your video */
				localMedia.getLocalStream().unmuteVideo();
				((View) localMedia.getLocalVideoControl()).setAlpha(1);
			} else {
				localMedia.getLocalStream().muteVideo();
				((View) localMedia.getLocalVideoControl()).setAlpha(0);

			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
