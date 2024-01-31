using System;
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

    public delegate void UpdateContactInformation();
    public event UpdateContactInformation OnUpdatedContact;

    private void Awake()
    {
        LoadContentToChatList();
    }

    private void Start()
    {
        InvokeRepeating(nameof(UpdateContact), 0, 1f);
    }

    private void UpdateContact()
    {
        if (gameObject.activeInHierarchy)
        {
            //Debug.Log("Updating Contact");

            for (int i = 0; i < messages.Count; i++)
            {
                messages[i].timeSent += 1;
                timeSent[i] += 1;
            }

            OnUpdatedContact?.Invoke();
        }
    }

    public void AddMessageToChat(MessageType messageType, int _contentID, float _timeSent, bool _liked)
    {
        Message newMessage = new(messageType, _contentID, _timeSent, _liked);
        messages.Add(newMessage);
        
        type.Add(messageType);
        contentID.Add(_contentID);
        timeSent.Add(_timeSent);
        liked.Add(_liked);
    }

    private void LoadContentToChatList()
    {
        for (int i = 0; i < type.Count; i++)
        {
            Message newMessage = new Message(type[i], contentID[i], timeSent[i], liked[i]);
            messages.Add(newMessage);
        }
    }

    /*
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
    */
}
