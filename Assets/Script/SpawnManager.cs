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
            previousSeed.GetComponent<SphereMovement>().ActiveSeed = false;
            previousSeed.GetComponent<Rigidbody>().detectCollisions = false;
            previousSeed.GetComponent<Rigidbody>().useGravity = false;
            previousSeed = NewSeed;
            GetComponent<PlantsJauge>().Reset();
        }
        else 
        {
            FirstSpawn = false;
            previousSeed = NewSeed;
        
        }
        scoreManager.addScore(10);

    }
}
