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
    public bool inTheSun;
    public bool inTheWater;
    public bool inFlowerRange;
    public float jaugeTimer;
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (ActiveSeed)
        {
            mouvemement();

        }

        if (inTheSun && jaugeTimer <= 0)
        {
            plantsManager.AddSun(1);
            jaugeTimer = 1;
        }
        
        if (inTheWater && jaugeTimer <= 0)
        {
            plantsManager.AddWater(1);
            jaugeTimer = 1;
        }

        jaugeTimer -= Time.deltaTime;   
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Onground = true ;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Water")
        {
            inTheWater = true;

        }
        if (other.transform.tag == "Sun")
        {
            inTheSun = true;

        }
        if (other.transform.tag == "Flower")
        {
            inFlowerRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Water")
        {
            inTheWater = false;

        }
        if (other.transform.tag == "Sun")
        {
            inTheSun = false;

        }
        if (other.transform.tag == "Flower")
        {
            inFlowerRange = false;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Onground=false ;
        }


    }

    void mouvemement() 
    {

        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

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

        rb.AddForce(desiredMoveDirection * speed);

        if (Input.GetKeyDown(KeyCode.Space) && Onground)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

    }


    public void Plant() 
    {
        transform.eulerAngles = new Vector3(-90f,0f,0f);
        animator.enabled = true;    
        animator.SetBool("Plant", true);
    
    }

    public void CallPlant() 
    {
        plantsManager.GetComponent<SpawnManager>().SpawnNewSeed();
    
    }
}
