using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject chat_Messages;

    [Header("Prefabs")]
    [SerializeField] GameObject messagePrefab_Meme;
    [SerializeField] GameObject messagePrefab_Warning;
    [SerializeField] GameObject messagePrefab_Angry;
    [SerializeField] GameObject messagePrefab_Block;

    private void Awake() => SetVisibility(false);
    private void Start() => StartCoroutine(StartDelay());
    private IEnumerator StartDelay()
    {
        yield return new WaitForEndOfFrame();
        SetVisibility(true);
        SetComponentValues();
    }


    public void SetComponentValues()
    {
        image.sprite = contact.image;
        username.text = contact.username;
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

    public void OnButtonClicked()
    {
        chat_Expanded.SetActive(true);
        chat_Messages.GetComponent<Chat_Messages>().chat_Listed = this;
        AddMessagesToChat();
    }
    public void AddNewMessageToChat()
    {
        ClearChat(); //Deberia excluir los ya enviados no reiniciar la lista
        AddMessagesToChat();
    }
    public void OnReturn()
    {
        chat_Expanded.SetActive(false);
        chat_Messages.GetComponent<Chat_Messages>().chat_Listed = null;
    }

    public void ClearChat()
    {
        int messageCount = chat_Messages.transform.childCount;
        //Debug.Log(messageCount);
        Message_OnChat[] message_OnChatComponents = chat_Messages.transform.GetComponentsInChildren<Message_OnChat>();

        for (int i = 0; i < message_OnChatComponents.Length; i++)
        {
            Message_OnChat message_OnChat = message_OnChatComponents[i];
            //Debug.Log(message_OnChat.name);
            contact.messages[0] = message_OnChat.contact.messages[0];
            Debug.Log(contact.messages[0].liked);
            Debug.Log(message_OnChat.contact.messages[0].liked);
        }

        foreach (Transform child in chat_Messages.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void AddMessagesToChat()
    {
        for (int i = 0; i < contact.messages.Count; i++)
        {            
            switch (contact.messages[i].type)
            {
                case MessageType.Meme:
                    AddMemeToChat(contact.messages[i]);
                    break;
                case MessageType.Warning:
                    AddWarningToChat(contact.messages[i]);
                    break;
                case MessageType.Angry:
                    AddAngryToChat(contact.messages[i]);
                    break;
                case MessageType.Block:
                    AddBlockToChat(contact.messages[i]);
                    break;
            }
            //Debug.Log(contact.chat[i].type + " | " + contact.chat[i].contentID);
        }
    }

    private void AddMemeToChat(Message message)
    {
        GameObject newMeme = Instantiate(messagePrefab_Meme, chat_Messages.transform);
        Message_Meme newMemeScript = newMeme.GetComponent<Message_Meme>();

        newMemeScript.contact = contact;
        newMemeScript.message = message;
    }
    private void AddWarningToChat(Message message)
    {
        GameObject newWarning = Instantiate(messagePrefab_Warning, chat_Messages.transform);
        Message_Warning newWarningScript = newWarning.GetComponent<Message_Warning>();

        newWarningScript.contact = contact;
        newWarningScript.message = message;
    }
    private void AddAngryToChat(Message message)
    {
        GameObject newAngry = Instantiate(messagePrefab_Angry, chat_Messages.transform);
        Message_Angry newAngryScript = newAngry.GetComponent<Message_Angry>();

        newAngryScript.contact = contact;
        newAngryScript.message = message;
    }
    private void AddBlockToChat(Message message)
    {
        GameObject newBlock = Instantiate(messagePrefab_Block, chat_Messages.transform);
        Message_Block newBlockScript = newBlock.GetComponent<Message_Block>();

        newBlockScript.contact = contact;
        //newBlockScript.message = message;
    }
    
}
