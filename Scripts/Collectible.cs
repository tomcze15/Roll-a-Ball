using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public  MovementController   player;
    public  int                  speed          = 10;
    private GUIController gui;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovementController>();
        gui = GameObject.Find("Main Camera").GetComponent<GUIController>();
    }

    void OnTriggerEnter(Collider collision)
    {
       
        gameObject.SetActive(false);
        ScoreManager.Instance.currentResult++;
        gui.countText_to_show = "Score: " + ScoreManager.Instance.currentResult + " / " + ScoreManager.Instance.maxPointInLevel;
        gui.updateGUI();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20,30,0) * Time.deltaTime * speed);
    }
}
