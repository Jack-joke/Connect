package fm.android.conference.webrtc;

import java.util.Locale;

import fm.Guid;
import fm.SingleAction;
import fm.icelink.Candidate;
import fm.icelink.Conference;
import fm.icelink.LinkCandidateArgs;
import fm.icelink.LinkOfferAnswerArgs;
import fm.icelink.OfferAnswer;
import fm.icelink.websync.ClientExtensions;
import fm.icelink.websync.JoinConferenceArgs;
import fm.icelink.websync.JoinConferenceFailureArgs;
import fm.icelink.websync.JoinConferenceSuccessArgs;
import fm.icelink.websync.LeaveConferenceArgs;
import fm.icelink.websync.LeaveConferenceFailureArgs;
import fm.icelink.websync.LeaveConferenceSuccessArgs;
import fm.websync.BindArgs;
import fm.websync.Client;
import fm.websync.ConnectArgs;
import fm.websync.ConnectFailureArgs;
import fm.websync.ConnectSuccessArgs;
import fm.websync.DisconnectArgs;
import fm.websync.DisconnectCompleteArgs;
import fm.websync.NotifyArgs;
import fm.websync.NotifyReceiveArgs;
import fm.websync.Record;
import fm.websync.SubscribeArgs;
import fm.websync.SubscribeFailureArgs;
import fm.websync.SubscribeReceiveArgs;
import fm.websync.SubscribeSuccessArgs;
import fm.websync.UnsubscribeArgs;
import fm.websync.UnsubscribeFailureArgs;
import fm.websync.UnsubscribeSuccessArgs;
import fm.websync.subscribers.ClientSubscribeArgs;
import fm.websync.subscribers.ClientUnsubscribeArgs;
import fm.websync.subscribers.SubscribeArgsExtensions;

// Peers have to exchange information when setting up P2P links,
// like descriptions of the streams (called the offer or answer)
// and information about network addresses (called candidates).
// IceLink generates this information for you automatically.
// Your responsibility is to pass messages back and forth between
// peers as quickly as possible. This is called "signalling".
public class Signalling {
    // We're going to use WebSync for this example, but any real-time
    // messaging system will do (like SIP or XMPP). We use WebSync
    // since it works well with JavaScript and uses HTTP, which is
    // widely allowed. To use something else, simply replace the calls
    // to WebSync with calls to your library.
    private String websyncServerUrl = null;
    private Client websyncClient = null;

    // IceLink includes a WebSync client extension that will
    // automatically manage signalling for you. If you are not
    // using WebSync, set this to false to see how the event
    // system works. Use it as a template for your own code.
    private boolean useWebSyncExtension = true;

    private SingleAction<LinkOfferAnswerArgs> sendOfferAnswerEvent;
    private SingleAction<LinkCandidateArgs> sendCandidateEvent;
    private SingleAction<NotifyReceiveArgs> receiveOfferAnswerOrCandidateEvent;

    public Signalling(String websyncServerUrl) {
        this.websyncServerUrl = websyncServerUrl;

        sendOfferAnswerEvent = new SingleAction<LinkOfferAnswerArgs>() {
            public void invoke(LinkOfferAnswerArgs e) {
                sendOfferAnswer(e);
            }
        };
        sendCandidateEvent = new SingleAction<LinkCandidateArgs>() {
            public void invoke(LinkCandidateArgs e) {
                sendCandidate(e);
            }
        };
        receiveOfferAnswerOrCandidateEvent = new SingleAction<NotifyReceiveArgs>() {
            public void invoke(NotifyReceiveArgs e) {
                receiveOfferAnswerOrCandidate(e);
            }
        };
    }

    public void start(final SingleAction<String> callback, boolean isBroadcast, boolean iamBroadcaster) throws Exception {
        // Create a WebSync client.
        websyncClient = new Client(websyncServerUrl);

        // Create a persistent connection to the server.
        if (isBroadcast) {
            String hasVideo = iamBroadcaster ? "false" : "true";
            Record record = new Record("hasVideo", hasVideo);
            BindArgs bindargs = new BindArgs(record);
            websyncClient.bind(bindargs);
        }
        websyncClient.connect(new ConnectArgs() {{
            setOnFailure(new SingleAction<ConnectFailureArgs>() {
                public void invoke(ConnectFailureArgs e) {
                    callback.invoke(String.format(Locale.getDefault(), "Could not connect to WebSync. %s", e.getException().getMessage()));
                    e.setRetry(false);
                }
            });
            setOnSuccess(new SingleAction<ConnectSuccessArgs>() {
                public void invoke(ConnectSuccessArgs e) {
                    callback.invoke(null);
                }
            });
        }});
    }

    public void stop(final SingleAction<String> callback) throws Exception {
        // Tear down the persistent connection.
        websyncClient.disconnect(new DisconnectArgs() {{
            setOnComplete(new SingleAction<DisconnectCompleteArgs>() {
                public void invoke(DisconnectCompleteArgs e) {
                    callback.invoke(null);
                }
            });
        }});

        websyncClient = null;
    }

    private Conference conference = null;
    private String sessionId = null;

    public void attach(final Conference conference, final String roomname, final SingleAction<String> callback) throws Exception {
        this.conference = conference;
        this.sessionId = roomname;

        if (useWebSyncExtension) {
            // Manage the conference automatically using a WebSync
            // channel. P2P links will be created automatically to
            // peers that join the same channel.
            ClientExtensions.joinConference(websyncClient, new JoinConferenceArgs(roomname, conference) {{
                setOnFailure(new SingleAction<JoinConferenceFailureArgs>() {
                    public void invoke(JoinConferenceFailureArgs e) {
                        callback.invoke(String.format(Locale.getDefault(), "Could not attach signalling to conference %s. %s", roomname, e.getException().getMessage()));
                    }
                });
                setOnSuccess(new SingleAction<JoinConferenceSuccessArgs>() {
                    public void invoke(JoinConferenceSuccessArgs e) {
                        callback.invoke(null);
                    }
                });
            }});
        } else {
            // When the conference generates an offer/answer or candidate,
            // we want to send it to the remote peer immediately.
            conference.addOnLinkOfferAnswer(sendOfferAnswerEvent);
            conference.addOnLinkCandidate(sendCandidateEvent);

            // When we receive an offer/answer or candidate, we want to
            // inform the conference immediately.
            websyncClient.addOnNotify(receiveOfferAnswerOrCandidateEvent);

            // Subscribe to a WebSync channel. When another client joins the same
            // channel, create a P2P link. When a client leaves, destroy it.

            // Subscribe to a WebSync channel. When another client joins the same
            // channel, create a P2P link. When a client leaves, destroy it.
            SubscribeArgs subscribeArgs = new SubscribeArgs(roomname) {{
                setOnFailure(new SingleAction<SubscribeFailureArgs>() {
                    public void invoke(SubscribeFailureArgs e) {
                        callback.invoke(String.format(Locale.getDefault(), "Could not attach signalling to conference %s. %s", roomname, e.getException().getMessage()));
                    }
                });
                setOnSuccess(new SingleAction<SubscribeSuccessArgs>() {
                    public void invoke(SubscribeSuccessArgs e) {
                        callback.invoke(null);
                    }
                });
                setOnReceive(new SingleAction<SubscribeReceiveArgs>() {
                    public void invoke(SubscribeReceiveArgs e) {
                    }
                });
            }};
            SubscribeArgsExtensions.setOnClientSubscribe(subscribeArgs, new SingleAction<ClientSubscribeArgs>() {
                public void invoke(ClientSubscribeArgs e) {
                    try {
                        // Kick off a P2P link.
                        String peerId = e.getSubscribedClient().getClientId().toString();
                        Object peerState = e.getSubscribedClient().getBoundRecords();
                        conference.link(peerId, peerState);
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            });
            SubscribeArgsExtensions.setOnClientUnsubscribe(subscribeArgs, new SingleAction<ClientUnsubscribeArgs>() {
                public void invoke(ClientUnsubscribeArgs e) {
                    try {
                        // Tear down a P2P link.
                        String peerId = e.getUnsubscribedClient().getClientId().toString();
                        conference.unlink(peerId);
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            });
            websyncClient.subscribe(subscribeArgs);
        }
    }

    private void sendOfferAnswer(LinkOfferAnswerArgs e) {
        try {
            websyncClient.notify(new NotifyArgs(new Guid(e.getPeerId()), e.getOfferAnswer().toJson(), "offeranswer:" + sessionId));
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void sendCandidate(LinkCandidateArgs e) {
        try {
            websyncClient.notify(new NotifyArgs(new Guid(e.getPeerId()), e.getCandidate().toJson(), "candidate:" + sessionId));
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void receiveOfferAnswerOrCandidate(NotifyReceiveArgs e) {
        try {
            String peerId = e.getNotifyingClient().getClientId().toString();
            Object peerState = e.getNotifyingClient().getBoundRecords();
            if (e.getTag() == "offeranswer:" + sessionId) {
                conference.receiveOfferAnswer(OfferAnswer.fromJson(e.getDataJson()), peerId, peerState);
            } else if (e.getTag() == "candidate:" + sessionId) {
                conference.receiveCandidate(Candidate.fromJson(e.getDataJson()), peerId);
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    public void leaveConference(final String roomname, final SingleAction<String> callback) throws Exception {
        if (useWebSyncExtension) {
            // Leave the managed WebSync channel.
            ClientExtensions.leaveConference(websyncClient, new LeaveConferenceArgs(roomname) {{
                setOnSuccess(new SingleAction<LeaveConferenceSuccessArgs>() {
                    public void invoke(LeaveConferenceSuccessArgs e) {
                        conference = null;
                        sessionId = null;

                        callback.invoke(null);
                    }
                });
                setOnFailure(new SingleAction<LeaveConferenceFailureArgs>() {
                    public void invoke(LeaveConferenceFailureArgs e) {
                        callback.invoke(String.format(Locale.getDefault(), "Could not detach signalling from conference %s. %s", sessionId, e.getException().getMessage()));
                    }
                });
            }});
        } else {
            // Unsubscribe from the WebSync channel.
            websyncClient.unsubscribe(new UnsubscribeArgs(roomname) {{
                setOnSuccess(new SingleAction<UnsubscribeSuccessArgs>() {
                    public void invoke(UnsubscribeSuccessArgs e) {
                        // Detach our event handlers.
                        conference.removeOnLinkOfferAnswer(sendOfferAnswerEvent);
                        conference.removeOnLinkCandidate(sendCandidateEvent);
                        websyncClient.removeOnNotify(receiveOfferAnswerOrCandidateEvent);

                        conference = null;
                        sessionId = null;

                        callback.invoke(null);
                    }
                });
                setOnFailure(new SingleAction<UnsubscribeFailureArgs>() {
                    public void invoke(UnsubscribeFailureArgs e) {
                        callback.invoke(String.format(Locale.getDefault(), "Could not detach signalling from conference %s. %s", sessionId, e.getException().getMessage()));
                    }
                });
            }});
        }
    }
}
