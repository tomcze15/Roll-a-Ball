using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LootFX : MonoBehaviour
{

    [Range(0.1f, 1.0f)]
    public  float           volume;
    private AudioSource     audioSource;
    private Collectible[]   loots;
    public  AudioClip       oneUp;
    private void Start()
    {
        audioSource = GetComponent<      AudioSource >();
        loots       = FindObjectsOfType< Collectible >();
    }

    public void collectSound()
    {
        audioSource.PlayOneShot(oneUp);
    }
}
