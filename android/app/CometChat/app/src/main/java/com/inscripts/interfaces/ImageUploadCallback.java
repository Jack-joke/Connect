package com.inscripts.interfaces;


import java.io.Serializable;

public interface ImageUploadCallback extends Serializable{
    void onProgress(float progress);
}
