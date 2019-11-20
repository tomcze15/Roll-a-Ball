//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    private AudioSource audioSource;
    
    [SerializeField]
    private AudioClip   hoverFx;
    
    [SerializeField]
    private AudioClip   clickFx;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(clickFx);
    }
}
