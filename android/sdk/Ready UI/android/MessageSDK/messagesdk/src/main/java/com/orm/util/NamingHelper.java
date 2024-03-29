package com.orm.util;

import com.orm.dsl.Column;
import com.orm.dsl.Table;

import java.lang.reflect.Field;

public class NamingHelper {

    /**
     * Converts a given CamelCasedString to UPPER_CASE_UNDER_SCORE.
     *
     * @param camelCased a non empty camelCased string
     * @return the equivalent string converted to UPPER_CASE_UNDER_SCORE unless camelCased equals
     * "_id" (not case sensitive) in which case "_id" is returned
     */
    public static String toSQLNameDefault(String camelCased) {
        if (camelCased.equalsIgnoreCase("_id")) {
            return "_id";
        }

        StringBuilder sb = new StringBuilder();
        char[] buf = camelCased.toCharArray();
        int i, buflength = buf.length;
        char prevChar, c, nextChar;
        boolean isFirstChar;
        for (i = 0; i < buflength; i++) {
            prevChar = (i > 0) ? buf[i - 1] : 0;
            c = buf[i];
            nextChar = (i < buflength - 1) ? buf[i + 1] : 0;
            isFirstChar = (i == 0);

            if (isFirstChar || Character.isLowerCase(c) || Character.isDigit(c)) {
                sb.append(Character.toUpperCase(c));
            } else if (Character.isUpperCase(c)) {
                if (Character.isLetterOrDigit(prevChar)) {
                    if (Character.isLowerCase(prevChar)) {
                        sb.append('_').append(c);
                    } else if (nextChar > 0 && Character.isLowerCase(nextChar)) {
                        sb.append('_').append(c);
                    } else {
                        sb.append(c);
                    }
                } else {
                    sb.append(c);
                }
            }
        }

        return sb.toString();
    }

    /**
     * Maps a Java Field object to the database's column name.
     *
     * @param field the {@link Field} that will be mapped
     * @return the name of the given Field as represented in the database. If the Field is annotated
     * with {@link Column} then the {@link Column#name()} will be
     * returned. Else, the Field's {@link Field#getName()} will be
     * converted from CamelCase to UNDER_SCORE notation
     */
    public static String toSQLName(Field field) {
        try {
            if (field.isAnnotationPresent(Column.class)) {
                Column annotation = field.getAnnotation(Column.class);
                return annotation.name();
            }

            return toSQLNameDefault(field.getName());
        } catch (Exception e) {
            return customSQLNameFOrmattor(field.getName());
        }
    }

    /**
     * Maps a Java Class to the name of the class.
     *
     * @param table the generic {@link Class<T>} that defines a database table
     * @return if the given class is annotated with {@link Table} then the value for
     * {@link Table#name()} will be returned. Else, the class' simple name will
     * be converted from CamelCase to UNDER_SCORE notation
     */
    public static String toSQLName(Class<?> table) {
        try {
            if (table.isAnnotationPresent(Table.class)) {
                Table annotation = table.getAnnotation(Table.class);
                if ("".equals(annotation.name())) {
                    return NamingHelper.toSQLNameDefault(table.getSimpleName());
                }
                return annotation.name();
            }

            return NamingHelper.toSQLNameDefault(table.getSimpleName());
        } catch (Exception e) {
            return customSQLNameFOrmattor(table.getSimpleName());
        }
    }

    public static String customSQLNameFOrmattor(String s) {
        return s.replaceAll(
                String.format("%s|%s|%s",
                        "(?<=[A-Z])(?=[A-Z][a-z])",
                        "(?<=[^A-Z])(?=[A-Z])",
                        "(?<=[A-Za-z])(?=[^A-Za-z])"
                ),
                "_"
        );
    }

}
