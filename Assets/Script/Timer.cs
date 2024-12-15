using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    public TextMeshProUGUI timerText;
    
    public float minutes = Mathf.Clamp(0,0,10);
    public float secondes = Mathf.Clamp(0, 0, 60);
    public GameObject endTab;
    public Score scoreManager;
    public bool TimeUp = false;
    public SpawnManager spawnManager;
   
    void Update()
    {
        if (!TimeUp)
        {
            minusOneSecond();
            timerText.text = minutes.ToString("F0") + ":" + secondes.ToString("F0");
        }
        
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
        TimeUp = true;
        timerText.gameObject.SetActive(false);
        spawnManager.DeactivatePlayer();
        endTab.SetActive(true);
        endTab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = scoreManager.score.ToString();
    }
}
