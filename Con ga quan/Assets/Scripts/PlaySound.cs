using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySound : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    void Awake()
    {
        audioSource = GameObject.Find("Universal audio source").GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayAudioClip();
    }

    public void PlayAudioClip()
    {
        if(audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
