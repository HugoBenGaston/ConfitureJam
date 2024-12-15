using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    private void Update()
    {
        transform.position = transform.GetChild(0).position;
    }
}
