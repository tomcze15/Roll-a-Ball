using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    private GameObject countText;
    private GameObject winText;
    private string str_winText;
    private string str_countText;
    
    public string countText_to_show
    { 
        set { str_countText = value; }
        get { return str_countText; } 
    }
    public string winText_to_show
    {
        set { str_winText = value; }
        get { return str_winText; }
    }

    // Start is called before the first frame update
    void Start()
    {
        countText   = GameObject.Find("CountText");
        winText     = GameObject.Find("WinText");
        
        countText.GetComponent< Text>().text = "Score: " + ScoreManager.Instance.currentResult + " / " + ScoreManager.Instance.maxPointInLevel;
        winText.GetComponent<   Text>().text = "";       
        winText.SetActive(false);
    }

    public void setActiveCountText(bool isActive)
    {
        countText.SetActive(isActive);
    }

    public void updateGUI() 
    {
        //countText.GetComponent<Text>().text = str_countText;
        countText.GetComponent<Text>().text = "Score: " + ScoreManager.Instance.currentResult + " / " + ScoreManager.Instance.maxPointInLevel;
        winText.GetComponent<Text>().text = str_winText;

    }

    public void setActiveWinText(bool isActive)
    {
        winText.SetActive(isActive);
    }
}
