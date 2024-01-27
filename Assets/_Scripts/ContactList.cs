using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactList : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject listedChatPrefab;

    public void AddContactToList(Contact contact)
    {
        GameObject newListedChat = Instantiate(listedChatPrefab, transform);
        newListedChat.GetComponent<ListedChat>().contact = contact;
    }
    public void ClearList()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
    }

}
