using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chat_Notification : MonoBehaviour
{
    [Header("Contact")]
    public Contact contact;

    [Header("Components")]
    [SerializeField] Image bgImage;
    [SerializeField] Image image;
    [SerializeField] TMP_Text username;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text time;

    [Header("References")]
    private GameObject chat_Expanded;

    private void Awake() => SetVisibility(false);
    private void OnEnable() => StartCoroutine(nameof(OnEnableDelayed));
    private IEnumerator OnEnableDelayed()
    {
        chat_Expanded = GameObject.FindGameObjectWithTag("Chat_Expanded");
        yield return new WaitForEndOfFrame();
        contact.OnUpdatedContact += UpdateComponentValues;
        UpdateComponentValues();
        SetVisibility(true);
    }
    private void OnDisable() => contact.OnUpdatedContact -= UpdateComponentValues;

    public void UpdateComponentValues()
    {
        image.sprite = contact.image;
        username.text = contact.username;
        UpdateDescriptionComponent();
        UpdateTimeComponent();
    }
    private void UpdateDescriptionComponent()
    {
        description.text = "Sent you 1 " + contact.type[contact.type.Count - 1].ToString();
    }
    private void UpdateTimeComponent()
    {
        time.text = "Received " + contact.timeSent[contact.timeSent.Count - 1].ToString() + " ago";
    }

    private void SetVisibility(bool active)
    {
        if (active)
        {
            bgImage.color = Color.gray;
            image.color = Color.white;
            username.color = Color.white;
            description.color = Color.white;
            time.color = Color.white;
        }
        else
        {
            Color alphaNull = new Color(0, 0, 0, 0);
            bgImage.color = alphaNull;
            image.color = alphaNull;
            username.color = alphaNull;
            description.color = alphaNull;
            time.color = alphaNull;
        }
    }

    //---------- INPUTS -------------------------------------------------------------------------------------------------

    public void OnNotificationPressed()
    {
        chat_Expanded.SetActive(false);
        chat_Expanded.SetActive(true);
        var chat_Expanded_Script = chat_Expanded.GetComponent<Chat_Expanded>();
        chat_Expanded_Script.contact = contact;
        //StartCoroutine(nameof(OnChatPressed_Delayed));
    }
    private IEnumerator OnChatPressed_Delayed()
    {
        chat_Expanded.SetActive(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1f);
        var chat_Expanded_Script = chat_Expanded.GetComponent<Chat_Expanded>();
        //chat_Expanded_Script.contact = contact;
        chat_Expanded.GetComponent<Chat_Expanded>().contact = contact;
        //chat_Expanded_Script.UpdateMessages();
    }
    public void OnReturnPressed()
    {
        chat_Expanded.SetActive(false);
        chat_Expanded.GetComponent<Chat_Expanded>().contact = null;
    }
}
