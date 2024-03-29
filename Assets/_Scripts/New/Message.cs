using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message
{
    public MessageType type;
    public int contentID;
    public float timeSent;
    public bool liked;

    public Message(MessageType messageType, int v1, float v2, bool v3)
    {
        this.type = messageType;
        this.contentID = v1;
        this.timeSent = v2;
        this.liked = v3;
    }
}
public enum MessageType
{
    Meme,
    Warning,
    Angry,
    Block
}
