using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    GameObject optionsPanel;
    public void StartGame() 
    {
        SceneManager.LoadSceneAsync("level_1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowOptions(bool isActive)
    {
        //optionsPanel.SetActive(isActive);
    }
}
