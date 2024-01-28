using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    [Header("Contact Data")]
    public string username;
    public Sprite image;

    [Header("Message Data")]
    public List<Sprite> memes = new();
    public List<string> warning = new();
    public List<Sprite> angry = new();

    [Header("Divider")]
    [SerializeField] bool divider;

    [Header("Chat List")]
    public List<MessageType> type;
    public List<int> contentID;
    public List<float> timeSent;
    public List<bool> liked;
    public List<Message> messages = new();

    private void Awake()
    {
        LoadContentToChatList();
        //CreateContentOnChatList(5);
    }

    private void Start()
    {
        //InvokeRepeating(nameof(AddToChat), 0, 5f);
    }

    public void AddMessageToChat(MessageType messageType, int v1, float v2, bool v3)
    {
        Message newMessage = new Message(messageType, v1, v2, v3);
        messages.Add(newMessage);
        
        type.Add(messageType);
        contentID.Add(v1);
        timeSent.Add(v2);
        liked.Add(v3);
    }

    private void LoadContentToChatList()
    {
        for (int i = 0; i < type.Count; i++)
        {
            Message newMessage = new Message(type[i], contentID[i], timeSent[i], liked[i]);
            messages.Add(newMessage);
        }
    }

    private void CreateContentOnChatList(float range)
    {
        for (int i = 0; i < range; i++)
        {
            Message newMessage = new Message(
                type[i], 
                contentID[Random.Range(0, contentID.Count - 1)], 
                timeSent[i],
                liked[i]);
            messages.Add(newMessage);
        }
    }
}
