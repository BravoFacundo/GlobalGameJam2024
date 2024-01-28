using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool tutorialCompleted;

    [Header("Contacts")]
    [SerializeField] Contact tutorialContact;
    public List<Contact> Contacts = new();

    [Header("References")]
    [SerializeField] ContactList contactList;
    [SerializeField] AudioManager audioManager;

    void Start()
    {
        if (tutorialCompleted) StartCoroutine(nameof(StartDelay), 1f);
        else StartTutorial();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            tutorialContact.AddMessageToChat(MessageType.Meme, 0, 15, false);
            contactList.chat_Messages.GetComponent<Chat_Messages>().UpdateMessages();
        }
    }
    //---------------------------------------------------------------------------------------------------------------

    private IEnumerator StartDelay(float time)
    {
        yield return new WaitForSeconds(time);
        StartGame();
    }
    private void StartGame()
    {
        contactList.ClearList();
        for (int i = 0; i < Contacts.Count; i++)
        {
            contactList.AddContactToList(Contacts[i]);
            audioManager.PlayAudio_NewMessage();
        }
    }

    //---------------------------------------------------------------------------------------------------------------

    private void StartTutorial()
    {
        StartCoroutine(nameof(Tutorial_Part1));
    }
    private IEnumerator Tutorial_Part1()
    {
        yield return new WaitForSeconds(1f);

        audioManager.PlayAudio_NewMessage();
        contactList.AddContactToList(tutorialContact);

        yield return new WaitForSeconds(1f);

        tutorialContact.AddMessageToChat(MessageType.Meme, 0, 15, false);
        contactList.chat_Messages.GetComponent<Chat_Messages>().UpdateMessages();
        //tutorialContact.AddMessageToChat(MessageType.Meme, 0, 15, false);
    }
    private IEnumerator Tutorial_Part2()
    {
        yield return new WaitForSeconds(1f);
    }

}
