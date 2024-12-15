using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantsJauge : MonoBehaviour
{
    public Slider Sunjauge;
    public Slider Waterjauge;
    public int WaterLevel = Mathf.Clamp(0,0,10);
    public int SunLevel = Mathf.Clamp(0,0,10);
    public bool FullWater;
    public bool FullSun;
    public bool CanPlant;
    public GameObject CanPlantText;

    private void Update()
    {
        if (CanPlant && Input.GetKeyDown(KeyCode.F)) 
        {
            Plant();
        
        }
    }
    public void AddWater(int WatertoAdd) 
    {
        WaterLevel += WatertoAdd;
        Waterjauge.value = WaterLevel;

        if (WaterLevel == 10) 
        {
            FullWater = true;
            CheckFull();
        }
    }

    public void AddSun(int SunToAdd) 
    {
        SunLevel += SunToAdd;
        Sunjauge.value = SunLevel;

        if (SunLevel == 10) 
        {
            FullSun = true;
            CheckFull();
        }
    
    }

    void CheckFull() 
    {
        if (FullWater && FullSun) 
        {
            CanPlant = true;
            CanPlantText.SetActive(true);

        }
    
    
    }

    public void Reset()
    {
        FullWater = false;
        FullSun = false;
        CanPlant = false;
        WaterLevel = 0;
        SunLevel = 0;
        Waterjauge.value = WaterLevel;
        Sunjauge.value = SunLevel;
    }

    void Plant() 
    {
        GetComponent<SpawnManager>().SpawnNewSeed();
    
    }
}
