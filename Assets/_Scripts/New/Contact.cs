using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    [Header("Contact Data")]
    public string username;
    public Sprite image;
    [Space]
    public int unansweredCount = 3;
    public bool isBlockingYou;
    [Space]
    public float sendTime;
    public float answerTime;
    [Space]
    public int memesSent;
    public int memesLiked;

    [Header("Chat List")]
    public List<MessageType> _messageType;
    public List<int> _contentID;
    public List<float> _timeSent;
    public List<bool> _messageLiked;

    //public List<Message> messages = new();

    [Space][Space][Space]

    [Header("Message Data")]
    public List<Sprite> memes = new();
    public List<string> warning = new();
    public List<Sprite> angry = new();

    public delegate void UpdateContactInformation();
    public event UpdateContactInformation OnUpdatedContact;

    private void Awake()
    {
        //LoadContentToChatList();
    }

    private void Start()
    {
        InvokeRepeating(nameof(UpdateContact), 0, 1f);
    }

    private void UpdateContact()
    {
        if (gameObject.activeInHierarchy)
        {
            OnUpdatedContact?.Invoke(); //Debug.Log("Updating Contact");

            memesSent = 0; memesLiked = 0;
            for (int i = 0; i < _messageType.Count; i++)
            {
                if (_messageType[i] == MessageType.Meme)
                {
                    memesSent += 1;
                    if (_messageLiked[i]) memesLiked += 1;
                }
            }
            if (memesSent > memesLiked && _messageType.Count != 0)
            {
                if (GameManager.playTimeCount - _timeSent[^1] >= answerTime)
                {
                    unansweredCount -= 1; Debug.Log(unansweredCount);
                    switch (unansweredCount)
                    {
                        case 2:
                            AddMessageToChat(MessageType.Warning, UnityEngine.Random.Range(0, warning.Count), GameManager.playTimeCount, false);
                            break;
                        case 1:
                            AddMessageToChat(MessageType.Angry, UnityEngine.Random.Range(0, angry.Count), GameManager.playTimeCount, false);
                            break;
                        case 0:
                            AddMessageToChat(MessageType.Block, 0, GameManager.playTimeCount, false);
                            break;
                    }
                }
            }           
        }
    }



    public void AddMessageToChat(MessageType _messageType, int _contentID, float _timeSent, bool _liked)
    {
        //Message newMessage = new(messageType, _contentID, _timeSent, _liked);
        //messages.Add(newMessage);

        this._messageType.Add(_messageType);
        this._contentID.Add(_contentID);
        this._timeSent.Add(_timeSent);
        this._messageLiked.Add(_liked);
    }

    private void LoadContentToChatList()
    {
        for (int i = 0; i < _messageType.Count; i++)
        {
            Message newMessage = new Message(_messageType[i], _contentID[i], _timeSent[i], _messageLiked[i]);
            //messages.Add(newMessage);
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
