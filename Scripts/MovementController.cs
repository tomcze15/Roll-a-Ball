using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float thrust = 5;
    public float speed = 5;
    public bool isGrounded;
    private Rigidbody rb;

    void Awake()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);
        if (Input.GetKey(KeyCode.W)) rb.AddForce(0, 0, thrust, ForceMode.Force);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(0, 0, -thrust, ForceMode.Force);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(thrust, 0, 0, ForceMode.Force);
        if (Input.GetKey(KeyCode.A)) rb.AddForce(-thrust, 0, 0, ForceMode.Force);
        if (isGrounded)
            if (Input.GetButtonDown("Jump"))
                rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wall")
            isGrounded = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wall")
            isGrounded = false;
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            isGrounded = true;
    }

    public void sleep()
    {
        rb.Sleep();
    }
}