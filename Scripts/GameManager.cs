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
    private Player                  player;
    private MovementController      player_mc;
    private Collectible[]           loots;
    private float                   countdown;
    private int                     currentLevel;
    private bool                    loadLvl;
    private bool                    alreadySetKeys = false;
    private RestartLevelByContact   rs;
    private GUIManager              gui;
    private Vector3[]           respawnPoint = {
        new Vector3(0F, 0.5F, 0F),              // For level one 
        new Vector3(27.5F, 0.5F, -27.5F),       // For level two
        new Vector3(0F, 0.5F, 0F),              // For level three
        new Vector3(0F, 2F, 2F)               // For level four
    };

    private void Awake()
    {      
        loadLvl         = false;
        countdown       = 4f;
        currentLevel    = SceneManager.GetActiveScene().buildIndex;
        player          = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player_mc       = player.GetComponent<          MovementController      >();
        rs              = GameObject.FindObjectOfType<  RestartLevelByContact   >();
        gui             = GameObject.FindObjectOfType<GUIManager>();
        loots           = FindObjectsOfType<Collectible>();
        QualitySettings.vSyncCount = 1;
    }

    // Start is called before the first frame update
    private void Start()
    {
        player.pickupEvent  += IsLoadLvl;
        rs.resetLevel       += ResetLevel;

        if (currentLevel == 4 && !alreadySetKeys)
        {
            player_mc.setKey(new Vector3(-player_mc.getThrust(), 0, 0), KeyCode.W);
            player_mc.setKey(new Vector3(player_mc.getThrust(), 0, 0), KeyCode.S);
            player_mc.setKey(new Vector3(0, 0, -player_mc.getThrust()), KeyCode.A);
            player_mc.setKey(new Vector3(0, 0, player_mc.getThrust()), KeyCode.D);
            alreadySetKeys = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(loadLvl) LoadLevel();
    }

    private void IsLoadLvl()
    {
        if (player.score == loots.Length)
            loadLvl = true;
    }

    private void LoadLevel()
    {
        if (player.score == loots.Length)
        {
            if (currentLevel != lastLevel())
            {
                countdown -= Time.deltaTime;
                if (countdown < 0.1f)
                {
                    SceneManager.LoadSceneAsync((currentLevel + 1));
                    player.score = 0;
                    RespawnPlayer();
                }
            }
            else
            {
                countdown -= Time.deltaTime;
                if (countdown < 0.1f)
                    SceneManager.LoadSceneAsync(0);
            }
        }
    }

    private void RespawnPlayer()
    {
        player_mc.transform.position = respawnPoint[currentLevel-1];
        player_mc.Sleep();
    }
    public void ResetLoots()
    {
        foreach (Collectible loot in loots)
            if (!loot.gameObject.activeSelf)
                loot.gameObject.SetActive(true);
    }

    private void ResetLevel()
    {
        StartCoroutine("RestartLevelCoroutine");
    }

    private IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        RespawnPlayer();
        if (player.score < loots.Length)
        {
            ResetLoots();
            player.score = 0;
            gui.updateUI();
        }
    }

    public int lastLevel()
    {
        return 4;
    }
}