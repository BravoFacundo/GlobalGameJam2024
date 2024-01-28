using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message_Warning : MonoBehaviour
{
    [Header("Message")]
    public Contact contact;
    public Message message;

    [Header("Components")]
    [SerializeField] Image bgImage;
    [SerializeField] TMP_Text text_warning;
    [SerializeField] TMP_Text text_time;

    private void Awake() => SetVisibility(false);
    private void Start() => StartCoroutine(StartDelay());
    private IEnumerator StartDelay()
    {
        yield return new WaitForEndOfFrame();
        SetVisibility(true);
        SetComponentValues();
    }

    private void SetComponentValues()
    {
        text_warning.text = contact.warning[message.contentID];
        text_time.text = message.timeSent.ToString();
    }

    private void SetVisibility(bool active)
    {
        if (active)
        {
            bgImage.color = Color.gray;
            text_warning.color = Color.white;
            text_time.color = Color.white;
        }
        else
        {
            Color alphaNull = new Color(0, 0, 0, 0);
            bgImage.color = alphaNull;
            text_warning.color = alphaNull;
            text_time.color = alphaNull;
        }
    }

}