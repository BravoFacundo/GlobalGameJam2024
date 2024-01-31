using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat_List : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject chat_Listed_Prefab;
    
    [Header("Local References")]
    public GameObject contact_List;
    
    [Header("References")]
    [SerializeField] GameObject chat_Expanded;

    public void AddContactToList(Contact contact)
    {
        GameObject newListedChat = Instantiate(chat_Listed_Prefab, contact_List.transform);
        Chat_Listed newListedChatScript = newListedChat.GetComponent<Chat_Listed>();

        newListedChatScript.contact = contact;
        newListedChatScript.chat_Expanded = chat_Expanded;
    }

    public void ClearList() => Utilities.DeleteChilds(contact_List.transform);

}
