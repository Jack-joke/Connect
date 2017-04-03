/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.pojos;

import com.inscripts.utils.CommonUtils;

/**
 * POJO to hold all the user data fields.
 */
public class User {

	private long id;
	private String name, link, status, statusMessage, avatarLink, userGroup, unreadCount;

	public User() {
	}

	/**
	 * @return unreadCount of message
	 */
	public String getUnreadCount() {
		return unreadCount;
	}

	/**
	 * @param unreadCount
	 *            Set unreadCount of message
	 */
	public void setUnreadCount(String unreadCount) {
		this.unreadCount = unreadCount;
	}

	/**
	 * @return the id
	 */
	public long getId() {
		return id;
	}

	/**
	 * @return the firstName
	 */
	public String getName() {
		return name;
	}

	/**
	 * @return the lastName
	 */
	public String getLink() {
		return link;
	}

	/**
	 * @return the status
	 */
	public String getStatus() {
		return status;
	}

	/**
	 * @return the statusMessage
	 */
	public String getStatusMessage() {
		return statusMessage;
	}

	/**
	 * @return the avatarLink
	 */
	public String getAvatarLink() {
		return avatarLink;
	}

	/**
	 * @return the userGroup
	 */
	public String getGroup() {
		return userGroup;
	}

	/**
	 * @param id
	 *            the id to set
	 */
	public void setId(Long id) {
		this.id = id;
	}

	/**
	 * @param name
	 *            the firstName to set
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * @param link
	 *            the lastName to set
	 */
	public void setLink(String link) {
		this.link = link;
	}

	/**
	 * @param status
	 *            the status to set
	 */
	public void setStatus(String status) {
		this.status = status;
	}

	/**
	 * @param statusMessage
	 *            the statusMessage to set
	 */
	public void setStatusMessage(String statusMessage) {
		this.statusMessage = statusMessage;
	}

	/**
	 * @param avatarLink
	 *            the avatarLink to set
	 */
	public void setAvatarLink(String avatarLink) {
		this.avatarLink = CommonUtils.processAvatarUrl(avatarLink);
	}

	/**
	 * @param userGroup
	 *            the userGroup to set
	 */
	public void setUserGroup(String userGroup) {
		this.userGroup = userGroup;
	}
}
