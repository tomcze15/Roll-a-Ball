using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float       thrust  = 5;
    public  float       speed   = 5;
    public  bool        isGrounded;
    private Rigidbody   rb;

    private Dictionary<KeyCode, Vector3> forces = new Dictionary<KeyCode, Vector3>();

    public event Action jumped;

    private void Awake()
    {
        forces[KeyCode.W]       = new Vector3(  0,          0,       thrust     );
        forces[KeyCode.S]       = new Vector3(  0,          0,       -thrust    );
        forces[KeyCode.D]       = new Vector3(  thrust,     0,       0          );
        forces[KeyCode.A]       = new Vector3(  -thrust,    0,       0          );
        forces[KeyCode.Space]   = new Vector3(  0,          thrust,  0          );
        isGrounded              = true;
        rb                      = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) rb.AddForce(   forces[KeyCode.W],    ForceMode.Force);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(   forces[KeyCode.S],    ForceMode.Force);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(   forces[KeyCode.D],    ForceMode.Force);
        if (Input.GetKey(KeyCode.A)) rb.AddForce(   forces[KeyCode.A],    ForceMode.Force);
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(forces[KeyCode.Space], ForceMode.Impulse);
                jumped?.Invoke();
            }
        }
    }

    public float getThrust()
    {
        return thrust;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wall")
            isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
            isGrounded = true;
    }

    public void Sleep()
    {
        rb.Sleep();
    }

    private void SetDefaultKey()
    {
        forces[KeyCode.W]       = new Vector3(0,        0,      thrust  );
        forces[KeyCode.S]       = new Vector3(0,        0,      -thrust );
        forces[KeyCode.D]       = new Vector3(thrust,   0,      0       );
        forces[KeyCode.A]       = new Vector3(-thrust,  0,      0       );
    }

    public void setKey(Vector3 force, KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W: forces[KeyCode.W] = force; break;
            case KeyCode.S: forces[KeyCode.S] = force; break;
            case KeyCode.D: forces[KeyCode.D] = force; break;
            case KeyCode.A: forces[KeyCode.A] = force; break;
        }
    }
}