using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message_Meme : Message_OnChat
{
    [Header("Components")]
    [SerializeField] Image bgImage;
    [SerializeField] Image image;
    [SerializeField] TMP_Text time;
    [SerializeField] Image likedImage;

    private void Awake() => SetVisibility(false);
    private void Start() => StartCoroutine(StartDelay());
    private IEnumerator StartDelay()
    {
        yield return new WaitForEndOfFrame();
        SetVisibility(true);
        SetComponentValues();
    }

    private void SetComponentValues()
    {
        image.sprite = contact.memes[message.contentID];
        time.text = message.timeSent.ToString();
    }

    private void SetVisibility(bool active)
    {
        Color alphaNull = new(0, 0, 0, 0);

        if (active)
        {
            bgImage.color = Color.gray;
            image.color = Color.white;
            time.color = Color.white;
            if (message.liked) likedImage.color = Color.white;
        }
        else
        {            
            bgImage.color = alphaNull;
            image.color = alphaNull;
            time.color = alphaNull;

            likedImage.color = alphaNull;
        }
    }

    public void OnButtonClicked()
    {
        Transform chat_Messages = transform.parent;
        int messageCount = chat_Messages.childCount;

        Message_OnChat[] message_OnChatComponents = chat_Messages.GetComponentsInChildren<Message_OnChat>();

        foreach (Message_OnChat message_OnChat in message_OnChatComponents)
        {
            if (message_OnChat.message.type == MessageType.Meme)
            {
                message_OnChat.contact.messages[messageCount-1].liked = true;
            }
        }

        likedImage.color = Color.white;
    }
}
