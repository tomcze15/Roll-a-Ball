using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    private Text            countText;
    private GameObject      winText;   // Jest GameObject'em dlatego, że chcę go w trakcie gry dezaktywować.
    private ScoreManager    scoreManager;
    public string statement
    {
        set;
        get;
    }
    // Start is called before the first frame update
    void Start()
    {
        countText       = GameObject.Find("CountText").GetComponent<Text>();
        winText         = GameObject.Find("WinText");
        scoreManager    = GetComponent<ScoreManager>();

        countText.text = "Score: " + scoreManager.currentResult + " / " + scoreManager.maxPointInLevel;
        winText.GetComponent<   Text>().text = "";       
        winText.SetActive(false);
    }

    public void updateUI()
    {
        if(!winText.active)
            countText.text = "Score: " + scoreManager.currentResult + " / " + scoreManager.maxPointInLevel;
        else
            winText.GetComponent<Text>().text = statement;
    } 

    public void setActiveWinText(bool isActive)
    {
        winText.SetActive(isActive);
    }
}
