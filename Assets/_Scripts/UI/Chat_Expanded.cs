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
        AddMessagesToChat();
        //InvokeRepeating(nameof(AddMessagesToChat), 1, GameConstants.UPDATE_TIME);
    }

    public void AddMessagesToChat()
    {
        if (gameObject.activeInHierarchy)
        {
            ClearChat();
            scrollbar.value = 0f;
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
            }
        }
    }
    public void ClearChat() => Utilities.DeleteChilds(messages_List.transform);

    private void AddMemeToChat(Message message)
    {
        GameObject newMeme = Instantiate(messagePrefab_Meme, messages_List.transform);
        Message_Meme newMemeScript = newMeme.GetComponent<Message_Meme>();

        newMemeScript.contact = contact;
        newMemeScript.message = message;
        newMemeScript.messages_List = messages_List.transform;
    }
    private void AddWarningToChat(Message message)
    {
        GameObject newWarning = Instantiate(messagePrefab_Warning, messages_List.transform);
        Message_Warning newWarningScript = newWarning.GetComponent<Message_Warning>();

        newWarningScript.contact = contact;
        newWarningScript.message = message;
    }
    private void AddAngryToChat(Message message)
    {
        GameObject newAngry = Instantiate(messagePrefab_Angry, messages_List.transform);
        Message_Angry newAngryScript = newAngry.GetComponent<Message_Angry>();

        newAngryScript.contact = contact;
        newAngryScript.message = message;
    }
    private void AddBlockToChat(Message message)
    {
        GameObject newBlock = Instantiate(messagePrefab_Block, messages_List.transform);
        Message_Block newBlockScript = newBlock.GetComponent<Message_Block>();

        newBlockScript.contact = contact;
        newBlockScript.message = message;
    }

    public void OnReturnPressed()
    {
        gameObject.SetActive(false);
        GetComponent<Chat_Expanded>().contact = null;
    }

}
