using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MovementController  player;
    private GUIController       gui;
    private Collectible[]       loots;
    private float               countdown = 3f;
    private Vector3[]           respawnPoint = {
        new Vector3(0F, 0F, 0F),                // For Menu 
        new Vector3(0F, 0.5F, 0F),              // For level one 
        new Vector3(27.5F, 0.5F, -27.5F),       // For level two
        new Vector3(0F, 0.5F, 0F)               // For level three
    };
    
    // Start is called before the first frame update
    void Start()
    {
        player  = FindObjectOfType<MovementController>();
        loots   = FindObjectsOfType<Collectible>();
        gui     = GameObject.Find("Main Camera").GetComponent<GUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.Instance.currentResult == ScoreManager.Instance.maxPointInLevel)
        {
            if (ScoreManager.Instance.currentLevel == ScoreManager.Instance.currentLevel-1)
            {               
                gui.winText_to_show = string.Format("You win! :)\n Exit for {0:0.0}", (countdown -= Time.deltaTime));
                gui.updateGUI();
                gui.setActiveWinText(true);
                if (countdown < 0.1f)
                {        
                    gui.winText_to_show = "if: You win! :)\n Exit for 0";
                    gui.updateGUI();
                    Application.Quit();
                }
            }
            else
            {
                gui.winText_to_show = string.Format("You win! :)\n Next level for {0:0.0}", (countdown -= Time.deltaTime));
                gui.setActiveWinText(true);
                gui.updateGUI();
                if (countdown < 0.1f)
                {
                    gui.winText_to_show = "You win! :)\n Next level for 0";
                    gui.updateGUI();
                    SceneManager.LoadSceneAsync(++ScoreManager.Instance.currentLevel);
                    respawnPlayer();
                }
            }
        }
        if (player.transform.position.y < -15)
        {
            respawnPlayer();
            //Dla cwaniaczków co wyskoczą poza mapę, żeby im loot'ów nie zrespiło.
            if (ScoreManager.Instance.currentResult != ScoreManager.Instance.maxPointInLevel) resetLoots();
        }
    }

    private void respawnPlayer()
    {
        player.transform.position = respawnPoint[ScoreManager.Instance.currentLevel];  // tu przef chwilą było -1
        player.rb.Sleep();
    }


    public void resetLoots()
    {
        foreach (Collectible loot in loots)
            if(!loot.gameObject.activeSelf) 
                loot.gameObject.SetActive(true);
        ScoreManager.Instance.currentResult = 0;
        gui.countText_to_show = "Score: " + ScoreManager.Instance.currentResult + " / " + ScoreManager.Instance.maxPointInLevel;
        gui.updateGUI();
    }
}
