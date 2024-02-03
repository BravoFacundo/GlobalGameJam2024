using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat_Expanded : MonoBehaviour
{
    [Header("Contact")]
    public Contact contact;

    [Header("Prefabs")]
    [SerializeField] GameObject messagePrefab_Meme;
    [SerializeField] GameObject messagePrefab_Warning;
    [SerializeField] GameObject messagePrefab_Angry;
    [SerializeField] GameObject messagePrefab_Block;

    [Header("Local References")]
    public GameObject messages_List;
    [SerializeField] Scrollbar scrollbar;

    private void OnEnable()
    {
        StartCoroutine(nameof(OnEnabledDelayed));
    }
    private IEnumerator OnEnabledDelayed()
    {
        yield return new WaitForEndOfFrame();
        contact.OnUpdatedContact += AddMessagesToChat;
    }
    private void OnDisable() => contact.OnUpdatedContact -= AddMessagesToChat;

    public void AddMessagesToChat()
    {
        if (gameObject.activeInHierarchy)
        {
            //ClearChat();
            int messageCount = messages_List.transform.childCount;
            for (int i = 0; i < contact._messageType.Count - messageCount; i++)
            {
                switch (contact._messageType[i + messageCount])
                {
                    case MessageType.Meme:
                        AddMemeToChat(i);
                        break;
                    case MessageType.Warning:
                        AddWarningToChat(i);
                        break;
                    case MessageType.Angry:
                        AddAngryToChat(i);
                        break;
                    case MessageType.Block:
                        AddBlockToChat(i);
                        break;
                }
            }
            scrollbar.value = 0f;
        }
    }
    public void ClearChat() => Utilities.DeleteChilds(messages_List.transform);

    private void AddMemeToChat(int messageIndex)
    {
        GameObject newMeme = Instantiate(messagePrefab_Meme, messages_List.transform);
        Message_Meme newMemeScript = newMeme.GetComponent<Message_Meme>();

        newMemeScript.contact = contact;
        newMemeScript.messageIndex = messageIndex;
        newMemeScript.messages_List = messages_List.transform;
    }
    private void AddWarningToChat(int messageIndex)
    {
        GameObject newWarning = Instantiate(messagePrefab_Warning, messages_List.transform);
        Message_Warning newWarningScript = newWarning.GetComponent<Message_Warning>();

        newWarningScript.contact = contact;
        newWarningScript.messageIndex = messageIndex;
    }
    private void AddAngryToChat(int messageIndex)
    {
        GameObject newAngry = Instantiate(messagePrefab_Angry, messages_List.transform);
        Message_Angry newAngryScript = newAngry.GetComponent<Message_Angry>();

        newAngryScript.contact = contact;
        newAngryScript.messageIndex = messageIndex;
    }
    private void AddBlockToChat(int messageIndex)
    {
        GameObject newBlock = Instantiate(messagePrefab_Block, messages_List.transform);
        Message_Block newBlockScript = newBlock.GetComponent<Message_Block>();

        newBlockScript.contact = contact;
        newBlockScript.messageIndex = messageIndex;
    }

    public void OnReturnPressed()
    {
        gameObject.SetActive(false);
        GetComponent<Chat_Expanded>().contact = null;
    }

}
