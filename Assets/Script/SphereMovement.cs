using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody rb;
    public bool Onground = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetAxis("Horizontal")!= 0) 
        {
            float horizontal = Input.GetAxis("Horizontal");
            rb.AddForce((Vector3.right * horizontal)*speed);
        }
        
        if (Input.GetAxis("Vertical")!= 0) 
        {
            float vertical = Input.GetAxis("Vertical");
            rb.AddForce((Vector3.forward * vertical)*speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Onground)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Onground = true ;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Onground=false ;
        }
    }
}
