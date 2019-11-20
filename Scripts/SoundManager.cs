using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip win;

    [SerializeField]
    private AudioClip lose;

    [SerializeField]
    private AudioClip jump_player;

    private bool                    alreadyPlayedWinSound;
    private int                     currentLevel;
    private Player                  player;
    private MovementController      player_mv;
    private RestartLevelByContact   rl;
    private int                     numberOfLoots;

    // Start is called before the first frame update
    private void Awake()
    {
        LoadData();
        LoadAction();
        audioSource.Play();
    }

    private void RespawnSoundPlayer()
    {
        audioSource.PlayOneShot(lose);
    }

    private void SoundJump()
    {
        audioSource.PlayOneShot(jump_player);
    }

    private void PlayWinGameSound()
    {
        if (currentLevel == 4)
        {
            if (!alreadyPlayedWinSound && (player.score == numberOfLoots))
            {
                audioSource.PlayOneShot(win);
                alreadyPlayedWinSound = true;
            }
        }
    }

    public void LoadData()
    {
        alreadyPlayedWinSound   = false;
        currentLevel            = SceneManager.GetActiveScene().buildIndex;
        audioSource             = GetComponent<AudioSource>();
        numberOfLoots           = FindObjectsOfType<Collectible>().Length;
        player                  = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player_mv               = player.GetComponent<MovementController>();
        rl                      = GameObject.FindObjectOfType<RestartLevelByContact>();
    }

    private void LoadAction()
    {
        player_mv.jumped    += SoundJump;
        rl.resetLevel       += RespawnSoundPlayer;
        player.pickupEvent  += PlayWinGameSound;
    }
}