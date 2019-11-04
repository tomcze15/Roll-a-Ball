using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public  float        thrust = 5;
    private Rigidbody    rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent< Rigidbody >();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W)) rb.AddForce(0, 0, thrust, ForceMode.Force);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(0, 0, -thrust, ForceMode.Force);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(thrust, 0, 0, ForceMode.Force);
        if (Input.GetKey(KeyCode.A)) rb.AddForce(-thrust, 0, 0, ForceMode.Force);

        if (Input.GetKeyDown("space") && 0.49 < transform.position.y && transform.position.y < 0.515)
            rb.AddForce(0, thrust * 50, 0, ForceMode.Force);
    }

    public void sleep()
    { 
        rb.Sleep();
    }
}
