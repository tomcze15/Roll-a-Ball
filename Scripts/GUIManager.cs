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
    private bool                displayStatement;
    private int                 currentLevel;
    private float               countdown;
    public string scoreText { set; get; }
    public string statement { set; get; }

    //private RestartLevelByContact rs;

    private void Awake()
    {
        countText       = GameObject.Find(  "CountText" ).GetComponent<Text>();
        winText         = GameObject.Find(  "WinText"   );
        panelScore      = GameObject.Find(  "bg_Win"    );
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
    private void Start()
    {
        player.pickupEvent  += updateUI;
    }

    private void Update()
    {
        if (displayStatement) DisplayStatement();
    }

    public void updateUI()
    {
        countText.text = "Score: " + player.GetScore() + " / " + numberOfLoots;

        if (player.score == numberOfLoots){ displayStatement = true; }
    }

    private void DisplayStatement()
    {
        setActiveWinText(true);
        countdown -= Time.deltaTime;
        if (currentLevel != 4)
        {
            if (countdown <= 1)
                SetStatement("You win! :)\n Next level for 0,0");
            else
                SetStatement(string.Format("You win! :)\n Next level for {0:0.0}", countdown - 1f));
        }
        else
        {
            if (countdown <= 1)
                SetStatement("You win! :)\n Exit to Menu for 0,0");
            else
                SetStatement(string.Format("You win! :)\n Exit to Menu for {0:0.0}", countdown - 1f));
        }
    }

    private void SetStatement(string text)
    {
        winText.GetComponent<Text>().text = text;
    }

    public void setActiveWinText(bool isActive)
    {
        panelScore.gameObject.SetActive(isActive);
        winText.SetActive(isActive);
    }
}