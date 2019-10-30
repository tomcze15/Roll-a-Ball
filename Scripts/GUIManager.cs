using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    //private MovementController  player;
    private Text                countText;
    private GameObject          winText;
    //private ScoreController     scoreManager;
    private GameObject          panelScore;
    public string scoreText { set; get; }
    public string statement { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        countText       = GameObject.Find("CountText").GetComponent<Text>();
        winText         = GameObject.Find("WinText");
        panelScore      = GameObject.Find("bg_Win");
        //scoreManager    = GetComponent<     ScoreController     >();
        //player          = FindObjectOfType< MovementController  >();

        countText.text                          = "";
        winText.GetComponent<   Text>().text    = "";
        panelScore.gameObject.SetActive(false);
        winText.SetActive(false);
    }

    public void updateUI()
    {
        if (!winText.activeSelf) 
            countText.text = scoreText;
        else 
            winText.GetComponent<Text>().text = statement;
    }

    public void updateUI(string scoreText, string statement)
    {
        if (!winText.activeSelf)
            countText.text = this.scoreText = scoreText;
        else
            winText.GetComponent<Text>().text = this.statement = statement;
    }

    public void setActiveWinText(bool isActive)
    {
        panelScore.gameObject.SetActive(isActive);
        winText.SetActive(isActive);
    }
}
