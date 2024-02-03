using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message_Warning : Message_OnChat
{
    [Header("Components")]
    [SerializeField] Image bgImage;
    [SerializeField] TMP_Text text_warning;
    [SerializeField] TMP_Text text_time;

    public override void UpdateComponentValues()
    {
        text_warning.text = contact.warning[contact._contentID[messageIndex]];
        text_time.text = contact._timeSent[messageIndex].ToString();
    }

    public override void SetVisibility(bool active)
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
