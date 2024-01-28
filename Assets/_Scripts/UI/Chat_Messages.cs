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

    private void OnEnable()
    {
        StartCoroutine(nameof(OnEnabledDelayed));
    }
    private IEnumerator OnEnabledDelayed()
    {
        yield return new WaitForEndOfFrame();
        UpdateMessages();
        //InvokeRepeating(nameof(UpdateMessages), GameConstants.UPDATE_TIME, GameConstants.UPDATE_TIME);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(UpdateMessages));
    }

    public void UpdateMessages()
    {
        if (gameObject.activeInHierarchy)
        {
            chat_Listed.AddNewMessageToChat();
            scrollbar.value = 0f;
        }
    }

    public void OnButtonBackClicked()
    {
        chat_Listed.OnReturn();
    }

}
