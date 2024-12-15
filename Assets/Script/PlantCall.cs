using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCall : MonoBehaviour
{
    public void CallPlant() 
    {
        transform.parent.GetComponent<SphereMovement>().CallPlant();
    
    }
}
