using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCall : MonoBehaviour
{
    public AudioSource popSource;
    public void CallPlant() 
    {
        transform.parent.GetComponent<SphereMovement>().CallPlant();
    
    }

    public void CallEffect() 
    {
        popSource.Play();
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
