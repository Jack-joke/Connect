package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class HeaderImage {

	@SerializedName("image_path")
	@Expose
	private String imagePath;
	@SerializedName("image_width")
	@Expose
	private Integer imageWidth;
	@SerializedName("image_height")
	@Expose
	private Integer imageHeight;
	@SerializedName("image_modified_time")
	@Expose
	private Integer imageModifiedTime;

	/**
	 * 
	 * @return The imagePath
	 */
	public String getImagePath() {
		return imagePath;
	}

	/**
	 * 
	 * @param imagePath
	 *            The image_path
	 */
	public void setImagePath(String imagePath) {
		this.imagePath = imagePath;
	}

	/**
	 * 
	 * @return The imageWidth
	 */
	public Integer getImageWidth() {
		return imageWidth;
	}

	/**
	 * 
	 * @param imageWidth
	 *            The image_width
	 */
	public void setImageWidth(Integer imageWidth) {
		this.imageWidth = imageWidth;
	}

	/**
	 * 
	 * @return The imageHeight
	 */
	public Integer getImageHeight() {
		return imageHeight;
	}

	/**
	 * 
	 * @param imageHeight
	 *            The image_height
	 */
	public void setImageHeight(Integer imageHeight) {
		this.imageHeight = imageHeight;
	}

	/**
	 * 
	 * @return The imageModifiedTime
	 */
	public Integer getImageModifiedTime() {
		return imageModifiedTime;
	}

	/**
	 * 
	 * @param imageModifiedTime
	 *            The image_modified_time
	 */
	public void setImageModifiedTime(Integer imageModifiedTime) {
		this.imageModifiedTime = imageModifiedTime;
	}

}
