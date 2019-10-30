using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MovementController  player;
    private GUIManager          gui;
    //private ScoreController     scoreManager;
    private Collectible[]       loots;
    private float               countdown;
    private int                 score;
    private int                 currentLevel;
    
    public  AudioClip           lose;
    public  AudioClip           win;
    private AudioSource         audioSource;
    private bool                isLosedSound;
    private bool                isWinSound;
    private bool isFirstLoadText;
    private Vector3[]           respawnPoint = {
        new Vector3(0F, 0.5F, 0F),              // For level one 
        new Vector3(27.5F, 0.5F, -27.5F),       // For level two
        new Vector3(0F, 0.5F, 0F)               // For level three
    };

    // Start is called before the first frame update
    void Start()
    {
        isFirstLoadText = isWinSound = isLosedSound = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        score = 0;
        countdown       = 4F;
        currentLevel    = SceneManager.GetActiveScene().buildIndex;
        player          = FindObjectOfType<     MovementController  >();
        loots           = FindObjectsOfType<    Collectible         >();
        gui             = GameObject.FindGameObjectWithTag("UIScore").GetComponent<GUIManager>();
        //scoreManager    = GetComponent<ScoreController>();
        QualitySettings.vSyncCount = 1;
        //updateUIScore(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstLoadText)
        {
            isFirstLoadText = false;
            updateUIScore();
        }

        if (score == loots.Length)
        {
            if (currentLevel == 3)
            {
                if (isWinSound)
                {      
                    audioSource.PlayOneShot(win);
                    isWinSound = false;
                }

                displayStatement(string.Format("You win! :)\n Exit to Menu for {0:0.0}", (countdown -= Time.deltaTime) - 1F));

                if (countdown <= 1)     gui.statement = "You win! :)\n Exit to Menu for 0,0";
                if (countdown < 0.1f)   SceneManager.LoadSceneAsync("MenuMain");

                gui.updateUI();
            }
            else
            {
                displayStatement(string.Format("You win! :)\n Next level for {0:0.0}", (countdown -= Time.deltaTime)-1F));           
                
                if (countdown <= 1) gui.statement = "You win! :)\n Next level for 0,0";
                
                if (countdown < 0.1f) 
                {
                    SceneManager.LoadSceneAsync((currentLevel + 1));              
                    respawnPlayer();
                }
                gui.updateUI();
            }
        }

        if (player.transform.position.y < -5 && isLosedSound)
        {
            audioSource.PlayOneShot(lose);
            isLosedSound = false;
        }

        respawnLevel();
    }

    public void addScore() 
    {
        score++;
        GetComponent<LootFX>().collectSound();
        updateUIScore();
    }

    private void respawnPlayer()
    {
        player.transform.position = respawnPoint[currentLevel-1];
        player.sleep();
    }

    private void updateUIScore()
    {
        gui.scoreText = "Score: " + score + " / " + loots.Length;
        gui.updateUI();
    }

    public void resetLoots()
    {
        foreach (Collectible loot in loots)
            if (!loot.gameObject.activeSelf)
                loot.gameObject.SetActive(true);
    }

    void displayStatement(string statement)
    {
        gui.statement = statement;
        gui.setActiveWinText(true);
    }

    void respawnLevel()
    {
        if (player.transform.position.y < -15)
        {
            respawnPlayer();
            if (score < loots.Length)
            {
                resetLoots();
                score = 0;
                updateUIScore();
            }
            isLosedSound = true;
        }
    }
}
