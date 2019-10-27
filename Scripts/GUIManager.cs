using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    private Text            countText;
    private GameObject      winText;
    private ScoreController scoreManager;
    public string scoreText { set; get; }
    public string statement { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        countText       = GameObject.Find("CountText").GetComponent<Text>();
        winText         = GameObject.Find("WinText");
        scoreManager    = GetComponent<ScoreController>();

        countText.text                          = "";
        winText.GetComponent<   Text>().text    = "";       
        winText.SetActive(false);
    }

    public void updateUI()
    {
        if (!winText.active) 
            countText.text = scoreText;
        else 
            winText.GetComponent<Text>().text = statement;
    }

    public void updateUI(string scoreText, string statement)
    {
        if (!winText.active)
            countText.text = this.scoreText = scoreText;
        else
            winText.GetComponent<Text>().text = this.statement = statement;
    }

    public void setActiveWinText(bool isActive)
    {
        winText.SetActive(isActive);
    }
}
