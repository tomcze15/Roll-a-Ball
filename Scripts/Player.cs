using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int currentScore;
    public int score 
    {
        set { currentScore = value; }
        get { return currentScore; }
    }
    public event Action pickupEvent;

    private void Start()
    {
        currentScore = 0;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "BasicLoot") { addScore(1); pickupEvent?.Invoke(); };
    }

    private void addScore(int score)
    {
        this.currentScore += score;
    }

    public int getScore()
    {
        return currentScore;
    }
}
