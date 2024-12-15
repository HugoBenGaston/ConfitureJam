using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPop : MonoBehaviour
{
    public GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            effect.SetActive(true);
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            effect.SetActive(false);

        }
    }
}
