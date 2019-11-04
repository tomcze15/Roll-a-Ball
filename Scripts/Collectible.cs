using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectible : MonoBehaviour
{
    public  int         speed          = 10;

    void OnTriggerEnter(Collider collision)
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20, 30, 0) * Time.deltaTime * speed);
    }
}
