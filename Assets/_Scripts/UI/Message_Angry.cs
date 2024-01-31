using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message_Angry : Message_OnChat
{
    [Header("Components")]
    [SerializeField] Image bgImage;
    [SerializeField] Image Image_Icon;
    [SerializeField] TMP_Text text_time;

    public override void UpdateComponentValues()
    {
        Image_Icon.sprite = contact.angry[message.contentID];
        text_time.text = message.timeSent.ToString();
    }

    public override void SetVisibility(bool active)
    {
        if (active)
        {
            bgImage.color = Color.gray;
            Image_Icon.color = Color.white;
            text_time.color = Color.white;
        }
        else
        {
            Color alphaNull = new Color(0, 0, 0, 0);
            bgImage.color = alphaNull;
            Image_Icon.color = alphaNull;
            text_time.color = alphaNull;
        }
    }

}
