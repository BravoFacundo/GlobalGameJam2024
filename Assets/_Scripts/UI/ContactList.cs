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

    private void Start()
    {
        InvokeRepeating(nameof(UpdateList), 0, GameConstants.UPDATE_TIME);
    }

    public void UpdateList()
    {
        //Debug.Log("ContactList/UpdateList");
        Chat_Listed[] chatListedComponents = GetComponentsInChildren<Chat_Listed>();
        foreach (Chat_Listed chatListed in chatListedComponents)
        {
            chatListed.SetComponentValues();
        }
    }
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
