using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LootFX : MonoBehaviour
{
    //[Range(0.1f, 1.0f)]
    //public  float           volume;         // Głośność dźwięku
    private AudioSource     audioSource;    // Obsługuję dźwięk
    
    [SerializeField]
    private AudioClip       oneUp;          // Dźwięk zebrania loot'a

    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        audioSource = GetComponent<      AudioSource >();
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
