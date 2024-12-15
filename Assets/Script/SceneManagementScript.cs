using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    public void ReplayLevel(string LevelName) 
    {
        SceneManager.LoadScene(LevelName);
    
    }

    public void Quit() 
    {
       Application.Quit();
    
    }
}
