using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool tutorialCompleted;

    [Header("Contacts")]
    [SerializeField] Contact tutorialContact;
    public List<Contact> contacts = new();

    [Header("References")]
    [SerializeField] AudioManager audioManager;

    public Chat_List chat_List;
    public Chat_Expanded chat_Expanded;

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
            //contactList.chat_Messages.GetComponent<Chat_Messages>().UpdateMessages();
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
        chat_List.ClearList();        
        for (int i = 0; i < contacts.Count; i++)
        {
            contacts[i].gameObject.SetActive(true);
            chat_List.AddContactToList(contacts[i]);
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
        tutorialContact.AddMessageToChat(MessageType.Meme, 0, 15, false);
        chat_List.AddContactToList(tutorialContact);

        yield return new WaitForSeconds(1f);

        //contactList.chat_Messages.GetComponent<Chat_Messages>().UpdateMessages();
        //tutorialContact.AddMessageToChat(MessageType.Meme, 0, 15, false);
    }
    private IEnumerator Tutorial_Part2()
    {
        yield return new WaitForSeconds(1f);
    }

}
