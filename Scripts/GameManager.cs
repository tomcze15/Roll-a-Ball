using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes : byte
{
    MainMenu,
    Level_1,
    Level_2,
    Level_3,
}

public class GameManager : MonoBehaviour
{
    private Player              player;
    private MovementController  player_mc;
    private Collectible[]       loots;
    private float               countdown;
    private int                 currentLevel;
    private bool                loadLvl;
    private Vector3[]           respawnPoint = {
        new Vector3(0F, 0.5F, 0F),              // For level one 
        new Vector3(27.5F, 0.5F, -27.5F),       // For level two
        new Vector3(0F, 0.5F, 0F)               // For level three
    };

    void Awake()
    {      
        loadLvl         = false;
        countdown       = 4f;
        currentLevel    = SceneManager.GetActiveScene().buildIndex;
        player          = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player_mc       = player.GetComponent<  MovementController  >();
        loots           = FindObjectsOfType<    Collectible         >();
        QualitySettings.vSyncCount = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        player.pickupEvent += isLoadLvl;
    }

    // Update is called once per frame
    void Update()
    {
        if (loadLvl)
        {
            if (currentLevel != 3)
            {
                countdown -= Time.deltaTime;
                if (countdown < 0.1f)
                {
                    SceneManager.LoadSceneAsync((currentLevel + 1));
                    player.score = 0;
                    respawnPlayer();
                }
            }
            else
            {
                countdown -= Time.deltaTime;
                if (countdown < 0.1f)
                    SceneManager.LoadSceneAsync(0);
            }
        }
        respawnLevel();
    }

    private void respawnPlayer()
    {
        player_mc.transform.position = respawnPoint[currentLevel-1];
        player_mc.sleep();
    }

    public void resetLoots()
    {
        foreach (Collectible loot in loots)
            if (!loot.gameObject.activeSelf)
                loot.gameObject.SetActive(true);
    }

    void respawnLevel()
    {
        if (player_mc.transform.position.y < -15)
        {
            respawnPlayer();
            if (player.score < loots.Length)
            {
                resetLoots();
                player.score = 0;
            }
        }
    }

    void isLoadLvl()
    {
        if (player.score == loots.Length)
            loadLvl = true;
    }
}