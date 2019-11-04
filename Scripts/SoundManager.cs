using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private AudioSource     audioSource;
    public  AudioClip       win;
    public  AudioClip       lose;
    public  AudioClip       jump_player;
    private bool            alreadyPlayedWinSound;
    private bool            loseSound;
    private int             currentLevel;
    private Player          player;
    private Transform       player_position;
    private int             numberOfLoots;

    // Start is called before the first frame update
    void Start()
    {
        alreadyPlayedWinSound   =   false;
        loseSound               =   true;
        currentLevel            =   SceneManager.GetActiveScene().buildIndex;
        audioSource             =   GetComponent<AudioSource>();
        numberOfLoots           =   FindObjectsOfType<Collectible>().Length;
        player                  =   GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player_position         =   player.GetComponent<Transform>();
        player.pickupEvent      +=  playWinGameSound;
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && 0.49 < player_position.position.y && player_position.position.y < 0.515)
            audioSource.PlayOneShot(jump_player);
        respawnSoundPlayer();
    }

    void respawnSoundPlayer()
    {
        if (player_position.position.y < -5 && loseSound)
        {
            audioSource.PlayOneShot(lose);
            loseSound = false;
        }

        if (player_position.position.y < -15)
            loseSound = true;
    }

    void playWinGameSound()
    {
        if (currentLevel == 3)
        {
            if (!alreadyPlayedWinSound && (player.score == numberOfLoots))
            {
                audioSource.PlayOneShot(win);
                alreadyPlayedWinSound = true;
            }
        }
    }
}
