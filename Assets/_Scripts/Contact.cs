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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)) AddToChat();
    }

    private void AddToChat()
    {
        Message newMessage = new Message(MessageType.Meme, 0, 15, false);
        messages.Add(newMessage);
        
        type.Add(MessageType.Warning);
        contentID.Add(0);
        timeSent.Add(15);
        liked.Add(false);
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
