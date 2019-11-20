using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LootFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource     audioSource;
    
    [SerializeField]
    private AudioClip       oneUp;

    private Player player;

    private void Awake()
    {
        player      = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        player.pickupEvent += collectSound;
    }

    public void collectSound()
    {
        audioSource.PlayOneShot(oneUp);
    }
}
