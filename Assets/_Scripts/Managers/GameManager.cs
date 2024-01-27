using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool tutorialCompleted;

    [Header("Contacts")]
    public List<Contact> Contacts = new();

    [Header("References")]
    [SerializeField] ContactList contactList;

    void Start()
    {
        if (tutorialCompleted) StartGame();
        else StartTutorial();
    }

    void Update()
    {
        
    }

    //---------------------------------------------------------------------------------------------------------------

    private void StartTutorial()
    {

    }
    private void StartGame()
    {
        contactList.ClearList();
        
        //contactList.AddContactToList(Contacts[0]);
        for (int i = 0; i < Contacts.Count; i++)
        {
            contactList.AddContactToList(Contacts[i]);
        }
    }
}
