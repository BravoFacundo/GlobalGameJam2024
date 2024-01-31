using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_OnChat : MonoBehaviour
{
    [Header("Message")]
    public Contact contact;
    public Message message;

    private void Awake() => SetVisibility(false);
    public virtual void OnEnable() => StartCoroutine(nameof(OnEnableDelayed));
    private IEnumerator OnEnableDelayed()
    {
        yield return new WaitForEndOfFrame();
        contact.OnUpdatedContact += UpdateComponentValues;
        UpdateComponentValues();
        SetVisibility(true);
    }
    private void OnDisable() => contact.OnUpdatedContact -= UpdateComponentValues;

    public virtual void UpdateComponentValues() { }
    public virtual void SetVisibility(bool active) { }

}
