using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject SeedPrefab;
    public Transform SpawnLocation;
    public CinemachineVirtualCamera VirtualCamera;
    public GameObject previousSeed;
    public GameObject cam;
    bool FirstSpawn = true;
    public Score scoreManager;

    public bool TestSpawn = false;

    private void Update()
    {
        if (TestSpawn) 
        {
           SpawnNewSeed();
            TestSpawn = false;
        
        }
    }

    private void Start()
    {
        SpawnNewSeed();
    }

    public void SpawnNewSeed() 
    {
        GameObject NewSeed = Instantiate(SeedPrefab, SpawnLocation);
        NewSeed.GetComponent<SphereMovement>().ActiveSeed = true;
        NewSeed.GetComponent<SphereMovement>().plantsManager = GetComponent<PlantsJauge>();
        VirtualCamera.LookAt = NewSeed.transform;
        VirtualCamera.Follow = NewSeed.transform;
        

        if (!FirstSpawn)
        {
            
            previousSeed = NewSeed;
            GetComponent<PlantsJauge>().Reset();
            scoreManager.addScore(10);
        }
        else 
        {
            FirstSpawn = false;
            previousSeed = NewSeed;
        
        }
        

    }

    public void PlantOldSeed() 
    {
        Rigidbody rb = previousSeed.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        previousSeed.GetComponent<SphereMovement>().ActiveSeed = false;
        rb.detectCollisions = false;
        rb.useGravity = false;
        
        
        previousSeed.GetComponent<SphereMovement>().Plant();
        VirtualCamera.LookAt = null;

    }
}
