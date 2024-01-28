using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Audio References")]
    [SerializeField] AudioClip audio_NewMessage;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio_NewMessage()
    {
        audioSource.clip = audio_NewMessage;
        audioSource.Play();
    }
}
