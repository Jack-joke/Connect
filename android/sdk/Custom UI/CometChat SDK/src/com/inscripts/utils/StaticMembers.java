package com.inscripts.utils;

public class StaticMembers {

	/* Tag for loggers */
	static final String LOGGER_TAG = "com.inscripts.cometchat.sdk"; //$NON-NLS-1$
	public static final String SDK_VERSION = Messages.getString("Version"); //$NON-NLS-1$

	/* Response codes for AJAX calls */
	public static final int AJAX_SUCCESS = 200;
	public static final int AJAX_FAIL = 404;
	public static final int NO_INTERNET_CONNECTION = -1;

	public static final String UTF_8 = "UTF-8"; //$NON-NLS-1$

	public static final String COMETCHAT_LOGINURL_SUFFIX_0 = ""; //$NON-NLS-1$
	public static final String COMETCHAT_LOGINURL_SUFFIX_1 = "cometchat/"; //$NON-NLS-1$
	public static final String COMETCHAT_LOGINURL_SUFFIX_2 = "chat/"; //$NON-NLS-1$
	public static final String COMETCHAT_LOGINURL_SUFFIX_3 = "plugins/cometchat/"; //$NON-NLS-1$
	public static final String COMETCHAT_LOGINURL_SUFFIX_4 = "plugins/chat/";

	public static final String ANCHOR_TAG = "a"; //$NON-NLS-1$
	public static final String HREF = "href"; //$NON-NLS-1$
	public static final String FILE_PREFIX = "file="; //$NON-NLS-1$
	public static final String IMAGE_TAG = "img"; //$NON-NLS-1$
	public static final String ATTRIBUTE_SRC = "src"; //$NON-NLS-1$
	public static final String ATTRIBUTE_TITLE = "title"; //$NON-NLS-1$

	public static final String SPAN_TAG = "span"; //$NON-NLS-1$
	public static final String DEFAULT_TEXT_COLOR = "#000000"; //$NON-NLS-1$
	public static final String MY_DEFAULT_TEXT_COLOR = "#FFFFFF"; //$NON-NLS-1$
	public static final String STYLE_ATTR = "style"; //$NON-NLS-1$
	public static final String ME_TEXT = "Me"; //$NON-NLS-1$

	public static final String IMAGE_MESSAGE_CSS_CLASS = "file_image"; //$NON-NLS-1$
	public static final String VIDEO_MESSAGE_CSS_CLASS = "file_video"; //$NON-NLS-1$

	public static final String FILETRANSFER_KEY = "plugins/filetransfer"; //$NON-NLS-1$
	public static final String IMAGE_MESSAGE_CLASS = "imagemessage"; //$NON-NLS-1$
	public static final String AUDIO_MESSAGE_CSS_CLASS = "file_audio";

	public static final String REQUEST = "request"; //$NON-NLS-1$
	public static final String REJECTCALL_ACTION = "rejectcall"; //$NON-NLS-1$
	public static final String ENDCALL_ACTION = "endcall"; //$NON-NLS-1$
	public static final String NO_ANSWER_ACTION = "noanswer"; //$NON-NLS-1$
	public static final String BUSY_CALL_ACTION = "busycall"; //$NON-NLS-1$
	public static final String CANCEL_OUTGOING_CALL_ACTION = "canceloutgoingcall"; //$NON-NLS-1$
	public static final String ACCEPTED = "accept"; //$NON-NLS-1$
	public static final String CALL = "call";

	public static final String DOMAIN_ERROR = "Unable to connect to domain. Please contact us at support@cometchat.com for more information.";
}