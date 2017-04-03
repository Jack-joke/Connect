package com.inscripts.factories;


import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.support.v4.content.AsyncTaskLoader;

import com.orm.SugarDb;

public class DataCursorLoader extends AsyncTaskLoader<Cursor> {

    private Cursor mCursor;
    private String table;
    private String[] projection;
    private String selection;
    private String[] selectionArgs;
    private String orderBy;
    private String rawQuery;
    private Context mContext;

    public DataCursorLoader(Context context) {
        super(context);
    }

    public DataCursorLoader(Context context, String table, String[] projection, String selection, String[] selectionArgs, String orderBy) {
        this(context);
        this.mContext = context;
        this.table = table;
        this.projection = projection;
        this.selection = selection;
        this.selectionArgs = selectionArgs;
        this.orderBy = orderBy;
    }

    public DataCursorLoader(Context context, String rawQuery, String[] selectionArgs) {
        this(context);
        this.mContext = context;
        this.rawQuery = rawQuery;
        this.selectionArgs = selectionArgs;
    }

    public String getSelection() {
        return selection;
    }

    public void setSelection(String selection) {
        this.selection = selection;
    }

    public String[] getSelectionArgs() {
        return selectionArgs;
    }

    public void setSelectionArgs(String[] selectionArgs) {
        this.selectionArgs = selectionArgs;
    }

    @Override
    public Cursor loadInBackground() {
        Cursor cursor;
        SugarDb sugarDb = new SugarDb(mContext);
        SQLiteDatabase sqLiteDatabase = sugarDb.getDB();

        if (rawQuery == null) {
            cursor = sqLiteDatabase
                    .query(table,
                            projection,
                            selection,
                            selectionArgs,
                            null,
                            null,
                            orderBy);
        }
        else {
            cursor = sqLiteDatabase.rawQuery(rawQuery,selectionArgs);
        }
        return cursor;
    }


    /* Runs on the UI thread */
    @Override
    public void deliverResult(Cursor cursor) {
        if (isReset()) {
            // An async query came in while the loader is stopped
            if (cursor != null) {
                cursor.close();
            }
            return;
        }
        Cursor oldCursor = mCursor;
        mCursor = cursor;

        if (isStarted()) {
            super.deliverResult(cursor);
        }

        if (oldCursor != null && oldCursor != cursor && !oldCursor.isClosed()) {
            oldCursor.close();
        }
    }

    /**
     * Starts an asynchronous load of the contacts list data. When the result is ready the callbacks
     * will be called on the UI thread. If a previous load has been completed and is still valid
     * the result may be passed to the callbacks immediately.
     * <p/>
     * Must be called from the UI thread
     */
    @Override
    protected void onStartLoading() {
        if (mCursor != null) {
            deliverResult(mCursor);
        }
        if (takeContentChanged() || mCursor == null) {
            forceLoad();
        }
    }

    /**
     * Must be called from the UI thread
     */
    @Override
    protected void onStopLoading() {
        // Attempt to cancel the current load task if possible.
        cancelLoad();
    }

    @Override
    public void onCanceled(Cursor cursor) {
        if (cursor != null && !cursor.isClosed()) {
            cursor.close();
        }
    }

    @Override
    protected void onReset() {
        super.onReset();

        // Ensure the loader is stopped
        onStopLoading();

        if (mCursor != null && !mCursor.isClosed()) {
            mCursor.close();
        }
        mCursor = null;
    }
}
