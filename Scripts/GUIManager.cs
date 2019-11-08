using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    private Player              player;
    private Text                countText;
    private GameObject          winText;
    private GameObject          panelScore;
    private int                 numberOfLoots;
    private bool                showStatement;
    private int                 currentLevel;
    private float               countdown;
    public string scoreText { set; get; }
    public string statement { set; get; }

    void Awake()
    {
        countText       = GameObject.Find("CountText"   ).GetComponent<Text>();
        winText         = GameObject.Find("WinText"     );
        panelScore      = GameObject.Find("bg_Win"      );
        player          = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        numberOfLoots   = FindObjectsOfType<Collectible>().Length;
        currentLevel    = SceneManager.GetActiveScene().buildIndex;
        countText.text                          = "";
        winText.GetComponent<Text>().text       = "";
        countdown                               = 4f;
        panelScore.gameObject.SetActive(false);
        winText.SetActive(false);
        updateUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        player.pickupEvent += updateUI;
    }

    private void Update()
    {
        if (player.GetComponent<MovementController>().transform.position.y < -15)
            countText.text = "Score: 0 / " + numberOfLoots;

        if (showStatement)
        {
            countdown -= Time.deltaTime;
            if (currentLevel != 3)
            {
                if (countdown <= 1)
                    statement = "You win! :)\n Next level for 0,0";
                else
                    statement = string.Format("You win! :)\n Next level for {0:0.0}", countdown - 1f);
            }
            else 
            {
                if (countdown <= 1)
                    statement = "You win! :)\n Exit to Menu for 0,0";
                else
                    statement = string.Format("You win! :)\n Exit to Menu for {0:0.0}", countdown - 1f);
            }
            winText.GetComponent<Text>().text = statement;
        }
    }

    public void updateUI()
    {
        countText.text = "Score: " + player.getScore() + " / " + numberOfLoots;

        if (player.score == numberOfLoots){ showStatement = true; setActiveWinText(true); }
    }

    public void setActiveWinText(bool isActive)
    {
        panelScore.gameObject.SetActive(isActive);
        winText.SetActive(isActive);
    }
}