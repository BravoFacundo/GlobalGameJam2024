using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message_Block : Message_OnChat
{
    [Header("Components")]
    [SerializeField] TMP_Text text_Block;

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
        text_Block.text = contact.username + GameConstants.BLOCK_MESSAGE;
    }

    private void SetVisibility(bool active)
    {
        if (active)
        {
            text_Block.color = Color.gray;
        }
        else
        {
            Color alphaNull = new Color(0, 0, 0, 0);
            text_Block.color = alphaNull;
        }
    }

}
