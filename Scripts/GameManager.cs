using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MovementController  player;
    private GUIController       gui;
    private ScoreManager        scoreManager;
    private Collectible[]       loots;
    private float               countdown = 4F;
    private Vector3[]           respawnPoint = {
        new Vector3(0F, 0.5F, 0F),              // For level one 
        new Vector3(27.5F, 0.5F, -27.5F),       // For level two
        new Vector3(0F, 0.5F, 0F)               // For level three
    };

    // Start is called before the first frame update
    void Start()
    {
        player          = FindObjectOfType<MovementController>();
        loots           = FindObjectsOfType<Collectible>();
        gui             = GetComponent<GUIController>();
        scoreManager    = GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager.currentResult == scoreManager.maxPointInLevel)
        {
            if (scoreManager.currentLevel == scoreManager.lastLevel) // może tu trzeba dać z prawej strony -1
            {        
                gui.statement = string.Format("You win! :)\n Exit for {0:0.0}", (countdown -= Time.deltaTime) - 1F);

                gui.setActiveWinText(true);

                if (countdown <= 1)      gui.statement = "You win! :)\n Exit for 0";
                if (countdown < 0.1f)    Application.Quit();
                
                gui.updateUI();
            }
            else
            {
                gui.statement = string.Format("You win! :)\n Next level for {0:0.0}", (countdown -= Time.deltaTime)-1F);
                gui.setActiveWinText(true);              
                if (countdown <= 1)
                    gui.statement = "You win! :)\n Next level for 0";
                if (countdown < 0.1f) 
                {
                    SceneManager.LoadSceneAsync((++scoreManager.currentLevel) + 1);              
                    respawnPlayer();
                }
                gui.updateUI();
            }
        }
        if (player.transform.position.y < -15)
        {
            respawnPlayer();
            if (scoreManager.currentResult != scoreManager.maxPointInLevel) resetLoots();
        }
    }

    public void addScore() 
    {
        scoreManager.currentResult++;
        gui.updateUI();
    }

    private void respawnPlayer()
    {
        player.transform.position = respawnPoint[scoreManager.currentLevel];
        player.rb.Sleep();
    }

    public void resetLoots()
    {
        foreach (Collectible loot in loots)
            if(!loot.gameObject.activeSelf) 
                loot.gameObject.SetActive(true);
        scoreManager.currentResult = 0;
        gui.updateUI();
    }
}
