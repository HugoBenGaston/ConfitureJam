using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    public TextMeshProUGUI timerText;
    
    public float minutes;
    public float secondes;
    public GameObject endTab;
    public Score scoreManager;
   
    void Update()
    {
        minusOneSecond();
        timerText.text = minutes.ToString("F0") + ":" + secondes.ToString("F0");
        
    }

    void minusOneSecond() 
    {
        secondes -= Time.deltaTime;
        if (secondes < 0) 
        {
            minutes -= 1;
            secondes = 59;
            
        }
        if (minutes< 0)
        {
            TimeUP();

        }
    }

    void TimeUP() 
    {
        endTab.SetActive(true);
        endTab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = scoreManager.score.ToString();
    }
}
