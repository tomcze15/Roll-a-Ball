using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LootFX : MonoBehaviour
{
    private AudioSource audioSource;
    [Range(0.1f, 1.0f)]
    public float volume;
    public  AudioClip   oneUp;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void collectSound()
    {
        audioSource.PlayOneShot(oneUp);
    }
}
