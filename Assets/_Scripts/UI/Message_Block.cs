using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message_Block : Message_OnChat
{
    [Header("Components")]
    [SerializeField] TMP_Text text_Block;

    public override void UpdateComponentValues()
    {
        text_Block.text = contact.username + GameConstants.BLOCK_MESSAGE;
    }

    public override void SetVisibility(bool active)
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
