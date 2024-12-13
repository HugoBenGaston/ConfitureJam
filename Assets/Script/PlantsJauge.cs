using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantsJauge : MonoBehaviour
{
    public Slider Sunjauge;
    public Slider Waterjauge;
    public int WaterLevel = Mathf.Clamp(0,0,10);
    public int SunLevel Mathf.Clamp(0,0,10);;
    public bool FullWater;
    public bool FullSun;

    private void Start()
    {
        
    }

    void AddWater(int WatertoAdd) 
    {
        WaterLevel += WatertoAdd;
        Waterjauge.value = WaterLevel;

        if (WaterLevel == 10) 
        {
            FullWater = true;
        }
    }

    void AddSun(int SunToAdd) 
    {
        SunLevel += SunToAdd;
        Sunjauge.value = SunLevel;
    
    }
}
