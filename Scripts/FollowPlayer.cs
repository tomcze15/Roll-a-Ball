using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The camera follows the subject
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    private Vector3     position;
    private Transform   player;

    // Start is called before the first frame update
    void Start()
    {
        player   = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        position = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - position;
    }
}
