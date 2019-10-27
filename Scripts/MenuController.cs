using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private float delay = 0.6f; 
    public void StartGame()
    {
        StartCoroutine(StartGameDelay());       
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameDelay());
    }

    public void ShowOptions(bool isActive)
    {
        StartCoroutine(SettingsGameDelay()); 
    }

    IEnumerator StartGameDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync("level_1");
    }

    IEnumerator ExitGameDelay()
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }

    IEnumerator SettingsGameDelay()
    {
        yield return new WaitForSeconds(delay);
        //optionsPanel.SetActive(isActive);
    }
}
