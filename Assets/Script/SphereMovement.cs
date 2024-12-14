using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody rb;
    public bool Onground = true;
    public bool ActiveSeed;
    public PlantsJauge plantsManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (ActiveSeed)
        {

            float horizontal = Input.GetAxis("Horizontal");
 
            float vertical = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Space) && Onground)
            {
                rb.AddForce(Vector3.up * jumpForce);
            } 

            //assuming we only using the single camera:
            var camera = Camera.main;

            //camera forward and right vectors:
            var forward = camera.transform.forward;
            var right = camera.transform.right;

            //project forward and right vectors on the horizontal plane (y = 0)
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            //this is the direction in the world space we want to move:
            var desiredMoveDirection = forward * vertical + right * horizontal;

            rb.AddForce(desiredMoveDirection  * speed);

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Onground = true ;
        }
        if(collision.transform.tag == "Water") 
        {
            plantsManager.AddWater(1);
        
        }
        if (collision.transform.tag == "Sun")
        {
            plantsManager.AddSun(1);

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
