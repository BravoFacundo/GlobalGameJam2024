using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListedChat : MonoBehaviour
{
    public Contact contact;

    [Header("Components")]
    [SerializeField] Image image;
    [SerializeField] TMP_Text username;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text time;

    private void Start()
    {
        StartCoroutine(Fuck());
    }

    private IEnumerator Fuck()
    {
        yield return new WaitForEndOfFrame();
        image.sprite = contact.image;
        username.text = contact.username;
    }
}
