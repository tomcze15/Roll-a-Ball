using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public  int         speed          = 10;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider collision)
    {
        gameObject.SetActive(false);
        gameManager.addScore();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20,30,0) * Time.deltaTime * speed);
    }
}
