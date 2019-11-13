using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelByContact : MonoBehaviour
{
    public event Action resetLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            resetLevel?.Invoke();
    }
}
