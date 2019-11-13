using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectible : MonoBehaviour
{
    [SerializeField]
    private  int         speed          = 10;

    private void OnTriggerEnter(Collider collision)
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(20, 30, 0) * Time.deltaTime * speed);
    }
}
