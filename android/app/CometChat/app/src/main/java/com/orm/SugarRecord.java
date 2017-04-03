package com.orm;

import android.annotation.SuppressLint;
import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteException;
import android.database.sqlite.SQLiteStatement;
import android.text.TextUtils;
import android.util.Log;

import com.orm.dsl.Ignore;
import com.orm.dsl.Table;
import com.orm.util.NamingHelper;
import com.orm.util.ReflectionUtil;
import com.orm.util.SugarConfig;

import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.NoSuchElementException;

import static com.orm.SugarContext.getSugarContext;

public class SugarRecord {

    protected Long id = null;

    public static <T> void deleteAll(Class<T> type) {
        getSugarContext().getSugarDb().getDB().delete(NamingHelper.toSQLName(type), null, null);
    }

    public static <T> void deleteAll(Class<T> type, String whereClause,
                                     String... whereArgs) {
        getSugarContext().getSugarDb().getDB().delete(NamingHelper.toSQLName(type), whereClause,
                whereArgs);
    }

    public static <T> void deleteInTx(Class<T> type){
        SQLiteDatabase sqLiteDatabase = getSugarContext().getSugarDb().getDB();
        try{
            sqLiteDatabase.beginTransaction();
            sqLiteDatabase.setLockingEnabled(false);
            sqLiteDatabase.delete(NamingHelper.toSQLName(type), null, null);
            sqLiteDatabase.setTransactionSuccessful();
        } catch (Exception e) {
            //Log.i(SUGAR, "Error in deleting in transaction " + e.getMessage());
        } finally {
            sqLiteDatabase.endTransaction();
            sqLiteDatabase.setLockingEnabled(true);
        }
    }

    @SuppressWarnings("deprecation")
    public static <T> void saveInTx(Collection<T> objects) {
        SQLiteDatabase sqLiteDatabase = getSugarContext().getSugarDb().getDB();
        try {
            sqLiteDatabase.beginTransaction();
            sqLiteDatabase.setLockingEnabled(false);
            for (T object : objects) {
                SugarRecord.save(object);
            }
            sqLiteDatabase.setTransactionSuccessful();
        } catch (Exception e) {
            Log.i("Sugar", "Error in saving in transaction " + e.getMessage());
        } finally {
            sqLiteDatabase.endTransaction();
            sqLiteDatabase.setLockingEnabled(true);
        }
    }

    public static <T> List<T> listAll(Class<T> type) {
        return find(type, null, null, null, null, null);
    }

    public static <T> T findById(Class<T> type, Long id) {
        List<T> list = find(type, "id=?", new String[]{String.valueOf(id)},
                null, null, "1");
        if (list.isEmpty())
            return null;
        return list.get(0);
    }

    public static <T> T findById(Class<T> type, Integer id) {
        return findById(type, Long.valueOf(id));
    }

    public static <T> Iterator<T> findAll(Class<T> type) {
        return findAsIterator(type, null, null, null, null, null);
    }

    public static <T> Iterator<T> findAsIterator(Class<T> type,
                                                 String whereClause, String... whereArgs) {
        return findAsIterator(type, whereClause, whereArgs, null, null, null);
    }

    public static <T> Iterator<T> findWithQueryAsIterator(Class<T> type,
                                                          String query, String... arguments) {
        SugarDb db = getSugarContext().getSugarDb();
        SQLiteDatabase sqLiteDatabase = db.getDB();
        Cursor c = sqLiteDatabase.rawQuery(query, arguments);
        return new CursorIterator<T>(type, c);
    }

    public static <T> Iterator<T> findAsIterator(Class<T> type,
                                                 String whereClause, String[] whereArgs, String groupBy,
                                                 String orderBy, String limit) {
        SugarDb db = getSugarContext().getSugarDb();
        SQLiteDatabase sqLiteDatabase = db.getDB();
        Cursor c = sqLiteDatabase.query(NamingHelper.toSQLName(type), null,
                whereClause, whereArgs, groupBy, null, orderBy, limit);
        return new CursorIterator<T>(type, c);
    }

    public static <T> List<T> find(Class<T> type, String whereClause,
                                   String... whereArgs) {
        return find(type, whereClause, whereArgs, null, null, null);
    }

    public static <T> List<T> findWithQuery(Class<T> type, String query,
                                            String... arguments) {
        T entity;
        List<T> toRet = new ArrayList<>();
        Cursor c = getSugarContext().getSugarDb().getDB().rawQuery(query, arguments);

        /*Custom code start here */

        List<Field> toStore = new ArrayList<>();
        List<Field> fieldList = SugarConfig.getFields(type);
        List<String> colomnNames = new ArrayList<>();
        if (fieldList != null) {
            toStore = fieldList;
            for (Field field : toStore) {
                colomnNames.add(NamingHelper.toSQLName(field));
            }
            fieldList = null;
        } else {
            List<Field> typeFields = new ArrayList<>();

            ReflectionUtil.getAllFields(typeFields, type);
            for (Field field : typeFields) {
                if (!field.isAnnotationPresent(Ignore.class) && !Modifier.isStatic(field.getModifiers()) && !Modifier.isTransient(field.getModifiers())) {
                    toStore.add(field);
                    colomnNames.add(NamingHelper.toSQLName(field));
                }
            }
            SugarConfig.setFields(type, toStore);
        }
        /*Custom code ends here*/

        try {
            while (c.moveToNext()) {
                entity = type.getDeclaredConstructor().newInstance();
                customInflate(c, entity, toStore, colomnNames);
                toRet.add(entity);
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            c.close();
        }

        return toRet;
    }

    public static void executeQuery(String query, String... arguments) {
        getSugarContext().getSugarDb().getDB().execSQL(query, arguments);
    }

    public static <T> List<T> find(Class<T> type, String whereClause,
                                   String[] whereArgs, String groupBy, String orderBy, String limit) {
        T entity;
        List<T> toRet = new ArrayList<T>();
        Cursor c = getSugarContext().getSugarDb().getDB().query(NamingHelper.toSQLName(type), null,
                whereClause, whereArgs, groupBy, null, orderBy, limit);

        /*Custom code start here */

        List<Field> toStore = new ArrayList<>();
        List<Field> fieldList = SugarConfig.getFields(type);
        List<String> colomnNames = new ArrayList<>();
        if (fieldList != null) {
            toStore = fieldList;
            for (Field field : toStore) {
                colomnNames.add(NamingHelper.toSQLName(field));
            }
            fieldList = null;
        } else {
            List<Field> typeFields = new ArrayList<>();

            ReflectionUtil.getAllFields(typeFields, type);
            for (Field field : typeFields) {
                if (!field.isAnnotationPresent(Ignore.class) && !Modifier.isStatic(field.getModifiers()) && !Modifier.isTransient(field.getModifiers())) {
                    toStore.add(field);
                    colomnNames.add(NamingHelper.toSQLName(field));
                }
            }
            SugarConfig.setFields(type, toStore);
        }
        /*Custom code ends here*/

        try {
            while (c.moveToNext()) {
                entity = type.getDeclaredConstructor().newInstance();
                customInflate(c, entity, toStore, colomnNames);
                toRet.add(entity);
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            c.close();
        }

        /*try {
            while (c.moveToNext()) {
                entity = type.getDeclaredConstructor().newInstance();
                inflate(c, entity);
                toRet.add(entity);
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            c.close();
        }*/
        return toRet;
    }

    public static <T> long count(Class<?> type) {
        return count(type, null, null, null, null, null);
    }

    public static <T> long count(Class<?> type, String whereClause,
                                 String[] whereArgs) {
        return count(type, whereClause, whereArgs, null, null, null);
    }

    public static <T> long count(Class<?> type, String whereClause,
                                 String[] whereArgs, String groupBy, String orderBy, String limit) {

        long toRet = -1;
        String filter = (!TextUtils.isEmpty(whereClause)) ? " where "
                + whereClause : "";
        SQLiteStatement sqliteStatement;
        try {
            sqliteStatement = getSugarContext().getSugarDb().getDB()
                    .compileStatement("SELECT count(*) FROM "
                            + NamingHelper.toSQLName(type) + filter);
        } catch (SQLiteException e) {
            e.printStackTrace();
            return toRet;
        }

        if (whereArgs != null) {
            int i, len = whereArgs.length;
            for (i = len; i != 0; i--) {
                sqliteStatement.bindString(i, whereArgs[i - 1]);
            }
        }

        try {
            toRet = sqliteStatement.simpleQueryForLong();
        } finally {
            sqliteStatement.close();
        }

        return toRet;
    }

    public static long save(Object object) {
        return save(getSugarContext().getSugarDb().getDB(), object);
    }

    @SuppressLint("NewApi")
    static long save(SQLiteDatabase db, Object object) {
        List<Field> columns = ReflectionUtil.getTableFields(object.getClass());
        ContentValues values = new ContentValues(columns.size());
        Field idField = null;
        for (Field column : columns) {
            ReflectionUtil.addFieldValueToColumn(values, column, object);
            if (column.getName().equals("id")) {
                idField = column;
            }
        }

        long id = db.insertWithOnConflict(
                NamingHelper.toSQLName(object.getClass()), null, values,
                SQLiteDatabase.CONFLICT_REPLACE);

        if (object.getClass().isAnnotationPresent(Table.class)) {
            if (idField != null) {
                idField.setAccessible(true);
                try {
                    idField.set(object, id);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        } else if (SugarRecord.class.isAssignableFrom(object.getClass())) {
            ((SugarRecord) object).setId(id);
        }

        // Log.i("Sugar", object.getClass().getSimpleName() + " saved : " + id);

        return id;
    }

    private static void customInflate(Cursor cursor, Object object, List<Field> columns, List<String> columnsNames) {
        if (columns == null) {
            columns = ReflectionUtil.getTableFields(object.getClass());
        }
        int i, len = columns.size();
        for (i = 0; i < len; i++) {
            Field field = columns.get(i);
            field.setAccessible(true);
            Class<?> fieldType = field.getType();
            if (fieldType.isAnnotationPresent(Table.class)
                    || SugarRecord.class.isAssignableFrom(fieldType)) {
                try {
                    long id = cursor.getLong(cursor.getColumnIndex(columnsNames.get(i)));
                    field.set(object, (id > 0) ? findById(fieldType, id) : null);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            } else {
                ReflectionUtil.customSetFieldValueFromCursor(cursor, field, fieldType
                        , object, columnsNames.get(i));
            }
        }
    }

    private static void inflate(Cursor cursor, Object object) {
        List<Field> columns = ReflectionUtil.getTableFields(object.getClass());

        for (Field field : columns) {
            field.setAccessible(true);
            Class<?> fieldType = field.getType();
            if (fieldType.isAnnotationPresent(Table.class)
                    || SugarRecord.class.isAssignableFrom(fieldType)) {
                try {
                    long id = cursor.getLong(cursor.getColumnIndex(NamingHelper
                            .toSQLName(field)));
                    field.set(object, (id > 0) ? findById(fieldType, id) : null);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            } else {
                ReflectionUtil.setFieldValueFromCursor(cursor, field, object);
            }
        }
    }

    public void delete() {
        getSugarContext().getSugarDb().getDB().delete(NamingHelper.toSQLName(getClass()), "Id=?",
                new String[]{getId().toString()});
        // Log.i("Sugar", getClass().getSimpleName() + " deleted : " +
        // getId().toString());
    }

    public long save() {
        return save(getSugarContext().getSugarDb().getDB(), this);
    }

    @SuppressWarnings("unchecked")
    void inflate(Cursor cursor) {
        inflate(cursor, this);
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    static class CursorIterator<E> implements Iterator<E> {
        Class<E> type;
        Cursor cursor;

        public CursorIterator(Class<E> type, Cursor cursor) {
            this.type = type;
            this.cursor = cursor;
        }

        @Override
        public boolean hasNext() {
            return cursor != null && !cursor.isClosed()
                    && !cursor.isAfterLast();
        }

        @Override
        public E next() {
            E entity = null;
            if (cursor == null || cursor.isAfterLast()) {
                throw new NoSuchElementException();
            }

            if (cursor.isBeforeFirst()) {
                cursor.moveToFirst();
            }

            try {
                entity = type.getDeclaredConstructor().newInstance();
                SugarRecord.inflate(cursor, entity);
            } catch (Exception e) {
                e.printStackTrace();
            } finally {
                cursor.moveToNext();
                if (cursor.isAfterLast()) {
                    cursor.close();
                }
            }

            return entity;
        }

        @Override
        public void remove() {
            throw new UnsupportedOperationException();
        }
    }

}
