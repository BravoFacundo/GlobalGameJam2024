using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListedChat : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] Contact contact;

    [Header("Components")]
    [SerializeField] Image image;
    [SerializeField] TMP_Text username;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text time;

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contact != null)
        {
            image.sprite = contact.image;
            username.text = contact.username;
        }
    }
}
