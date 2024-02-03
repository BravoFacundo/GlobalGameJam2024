using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Chat_Listed : MonoBehaviour
{
    [Header("Contact")]
    public Contact contact;

    [Header("Components")]
    [SerializeField] Image bgImage;
    [SerializeField] Image image;
    [SerializeField] TMP_Text username;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text time;

    [Header("References")]
    public GameObject chat_Expanded;
    
    private void Awake() => SetVisibility(false);
    private void OnEnable() => StartCoroutine(nameof(OnEnableDelayed));
    private IEnumerator OnEnableDelayed()
    {
        yield return new WaitForEndOfFrame();
        contact.OnUpdatedContact += UpdateComponentValues;
        UpdateComponentValues();
        SetVisibility(true);
    }
    private void OnDisable() => contact.OnUpdatedContact -= UpdateComponentValues;

    public void UpdateComponentValues()
    {
        image.sprite = contact.image;
        username.text = contact.username;
        UpdateDescriptionComponent();
        UpdateTimeComponent();
    }
    private void UpdateDescriptionComponent()
    {
        switch (contact._messageType[^1])
        {
            case MessageType.Meme:
                var messageTypeCount = 0;
                for (int i = 0; i < contact._messageType.Count; i++)
                {
                    if (contact._messageType[i] == MessageType.Meme) messageTypeCount += 1;
                }
                var messageTypeString = contact._messageType[^1].ToString();
                description.text = "Sent you " + messageTypeCount + " " + messageTypeString + "'s";
                break;
            case MessageType.Warning:
                var messageString = contact.warning[contact._contentID[^1]];
                description.text = messageString;
                break;
            case MessageType.Angry:
                description.text = "Sent you an Angry Emoji";
                break;
            case MessageType.Block:
                description.text = "Te ha bloqueado";
                break;
        }
    }
    private void UpdateTimeComponent()
    {
        var currentTime = GameManager.playTimeCount - contact._timeSent[^1];
        time.text = "Received " + currentTime.ToString() + " ago";
    }

    private void SetVisibility(bool active)
    {
        if (active)
        {
            bgImage.color = Color.gray;
            image.color = Color.white;
            username.color = Color.white;
            description.color = Color.white;
            time.color = Color.white;
        }
        else
        {
            Color alphaNull = new Color(0,0,0,0);
            bgImage.color = alphaNull;
            image.color = alphaNull;
            username.color = alphaNull;
            description.color = alphaNull;
            time.color = alphaNull;
        }        
    }    

    //---------- INPUTS -------------------------------------------------------------------------------------------------

    public void OnChatPressed()
    {
        chat_Expanded.SetActive(true);
        var chat_Expanded_Script = chat_Expanded.GetComponent<Chat_Expanded>();
        chat_Expanded_Script.contact = contact;
        //StartCoroutine(nameof(OnChatPressed_Delayed));
    }
    private IEnumerator OnChatPressed_Delayed()
    {
        chat_Expanded.SetActive(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1f);
        var chat_Expanded_Script = chat_Expanded.GetComponent<Chat_Expanded>();
        //chat_Expanded_Script.contact = contact;
        chat_Expanded.GetComponent<Chat_Expanded>().contact = contact;
        //chat_Expanded_Script.UpdateMessages();
    }
    public void OnReturnPressed()
    {
        chat_Expanded.SetActive(false);
        chat_Expanded.GetComponent<Chat_Expanded>().contact = null;
    }

}
