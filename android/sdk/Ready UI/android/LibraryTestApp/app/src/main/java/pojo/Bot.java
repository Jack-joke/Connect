package pojo;


public class Bot {
    public long botId;
    public String botName;
    public String botDescription;
    public String botAvatar;


    public String getBotAvatar() {
        return botAvatar;
    }

    public void setBotAvatar(String botAvatar) {
        this.botAvatar = botAvatar;
    }

    public String getBotDescription() {
        return botDescription;
    }

    public void setBotDescription(String botDescription) {
        this.botDescription = botDescription;
    }

    public long getBotId() {
        return botId;
    }

    public void setBotId(long botId) {
        this.botId = botId;
    }

    public String getBotName() {
        return botName;
    }

    public void setBotName(String botName) {
        this.botName = botName;
    }
}
