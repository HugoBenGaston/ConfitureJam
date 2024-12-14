using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    

    public void addScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        UpdateScore();
    
    }

    void UpdateScore() 
    {
        scoreText.text = score.ToString();
    
    }
}
