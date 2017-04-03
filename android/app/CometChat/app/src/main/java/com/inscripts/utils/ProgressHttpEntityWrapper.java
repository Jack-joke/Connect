package com.inscripts.utils;


import org.apache.http.HttpEntity;
import org.apache.http.entity.HttpEntityWrapper;

import java.io.FilterOutputStream;
import java.io.IOException;
import java.io.OutputStream;

public class ProgressHttpEntityWrapper  extends HttpEntityWrapper {

    private final ProgressCallback progressCallback;

    public static interface ProgressCallback {
        public void progress(float progress) throws InterruptedException;
    }

    public ProgressHttpEntityWrapper(final HttpEntity entity, final ProgressCallback progressCallback) {
        super(entity);
        this.progressCallback = progressCallback;
    }

    @Override
    public void writeTo(final OutputStream out) throws IOException {
        this.wrappedEntity.writeTo(out instanceof ProgressFilterOutputStream ? out : new ProgressFilterOutputStream(out, this.progressCallback, getContentLength()));
    }

    static class ProgressFilterOutputStream extends FilterOutputStream {

        private final ProgressCallback progressCallback;
        private long transferred;
        private long totalBytes;

        ProgressFilterOutputStream(final OutputStream out, final ProgressCallback progressCallback, final long totalBytes) {
            super(out);
            this.progressCallback = progressCallback;
            this.transferred = 0;
            this.totalBytes = totalBytes;
        }

        @Override
        public void write(final byte[] b, final int off, final int len) throws IOException {
            //super.write(byte b[], int off, int len) calls write(int b)
            out.write(b, off, len);
            this.transferred += len;
            try {
                this.progressCallback.progress(getCurrentProgress());
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        @Override
        public void write(final int b) throws IOException {
            out.write(b);
            this.transferred++;
            try {
                this.progressCallback.progress(getCurrentProgress());
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        private float getCurrentProgress() {
            return ((float) this.transferred / this.totalBytes) * 100;
        }

    }

}
