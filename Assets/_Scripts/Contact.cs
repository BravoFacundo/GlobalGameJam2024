using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    [Header("Contact Data")]
    public string username;
    public Sprite image;

    [Header("Chat List")]
    public List<MessageType> type;
    public List<int> contentID;
    public List<float> timeSent;
    public List<Message> chat = new();

    [Header("Message Data")]
    public List<Sprite> memes = new();
    public List<string> warning = new();
    public List<Sprite> angry = new();
    public string block;

    private void Awake()
    {
        LoadContentToChatList();
        //CreateContentOnChatList(5);
    }

    private void LoadContentToChatList()
    {
        for (int i = 0; i < type.Count; i++)
        {
            Message newMessage = new Message(type[i], contentID[i], timeSent[i]);
            chat.Add(newMessage);
        }
    }

    private void CreateContentOnChatList(float range)
    {
        for (int i = 0; i < range; i++)
        {
            Message newMessage = new Message(
                type[i], 
                contentID[Random.Range(0, contentID.Count - 1)], 
                timeSent[i]);
            chat.Add(newMessage);
        }
    }
}
