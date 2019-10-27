using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    private AudioSource audioSource;
    public  AudioClip   hoverFx;
    public  AudioClip   clickFx;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void hoverSound()
    {
        audioSource.PlayOneShot(hoverFx);
    }

    public void clickSound()
    {
        audioSource.PlayOneShot(clickFx);
    }
}
