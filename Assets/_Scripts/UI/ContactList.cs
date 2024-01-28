using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactList : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject chat_Listed_Prefab;

    [Header("References")]
    [SerializeField] GameObject chat_Expanded;
    [SerializeField] GameObject chat_Messages;

    public void AddContactToList(Contact contact)
    {
        GameObject newListedChat = Instantiate(chat_Listed_Prefab, transform);
        Chat_Listed newChatScript = newListedChat.GetComponent<Chat_Listed>();
        
        newChatScript.contact = contact;
        newChatScript.chat_Expanded = chat_Expanded;
        newChatScript.chat_Messages = chat_Messages;
    }
    public void ClearList()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
    }

}
