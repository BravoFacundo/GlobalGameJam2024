using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message_Meme : MonoBehaviour
{
    [Header("Message")]
    public Contact contact;
    public Message message;

    [Header("Components")]
    [SerializeField] Image bgImage;
    [SerializeField] Image image;
    [SerializeField] TMP_Text time;
    [SerializeField] Image likedImage;

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
        image.sprite = contact.memes[message.contentID];
        time.text = message.timeSent.ToString();
    }

    private void SetVisibility(bool active)
    {
        if (active)
        {
            bgImage.color = Color.gray;
            image.color = Color.white;
            time.color = Color.white;
        }
        else
        {
            Color alphaNull = new Color(0, 0, 0, 0);
            bgImage.color = alphaNull;
            image.color = alphaNull;
            likedImage.color = alphaNull;
            time.color = alphaNull;
        }
    }

    public void OnButtonClicked()
    {
        likedImage.color = Color.white;
    }
}
