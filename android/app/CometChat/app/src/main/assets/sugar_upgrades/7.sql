CREATE TABLE STATUS (STATUSMESSAGE STRING);
CREATE TABLE IF NOT EXISTS bot ( bot_id INT PRIMARY KEY NOT NULL UNIQUE, bot_name TEXT, bot_description TEXT, bot_avatar TEXT);