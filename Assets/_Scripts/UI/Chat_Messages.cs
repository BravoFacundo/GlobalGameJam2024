using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat_Messages : MonoBehaviour
{
    [Header("References")]
    public Chat_Listed chat_Listed;

    [Header("Local References")]
    [SerializeField] Scrollbar scrollbar;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateMessages), 0, GameConstants.UPDATE_TIME);
    }
    private void OnEnable()
    {
        InvokeRepeating(nameof(UpdateMessages), 0, GameConstants.UPDATE_TIME);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(UpdateMessages));
    }

    private void UpdateMessages()
    {
        if (gameObject.activeSelf)
        {
            //Debug.Log("Chat_Messages/UpdateMessages");
            chat_Listed.AddNewMessageToChat();
            scrollbar.value = 0f;
        }
    }

    public void OnButtonBackClicked()
    {
        chat_Listed.OnReturn();
    }

}
