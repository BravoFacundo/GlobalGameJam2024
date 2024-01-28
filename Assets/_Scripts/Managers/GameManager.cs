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
        StartCoroutine(nameof(TutorialDelay));
    }
    private IEnumerator TutorialDelay()
    {
        yield return new WaitForSeconds(1f);

        contactList.AddContactToList(tutorialContact);
        audioManager.PlayAudio_NewMessage();
    }

}
