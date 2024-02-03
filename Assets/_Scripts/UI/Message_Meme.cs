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

    [Header("References")]
    public Transform messages_List;

    public override void UpdateComponentValues()
    {
        image.sprite = contact.memes[contact._contentID[messageIndex]]; //message.contentID
        time.text = contact._timeSent[messageIndex].ToString();
    }

    public override void SetVisibility(bool active)
    {
        Color alphaNull = new(0, 0, 0, 0);

        if (active)
        {
            bgImage.color = Color.gray;
            image.color = Color.white;
            time.color = Color.white;
            if (contact._messageLiked[messageIndex]) likedImage.color = Color.white;
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
        int messageCount = messages_List.childCount;

        Message_OnChat[] message_OnChatComponents = messages_List.GetComponentsInChildren<Message_OnChat>();

        foreach (Message_OnChat message_OnChat in message_OnChatComponents)
        {
            if (message_OnChat.contact._messageType[messageIndex] == MessageType.Meme)
            {
                message_OnChat.contact._messageLiked[messageCount-1] = true;
            }
        }

        likedImage.color = Color.white;
    }
}
