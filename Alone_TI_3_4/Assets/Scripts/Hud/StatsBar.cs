using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
     public Slider slider; 
    public GameObject background;
    //Define o valor maximo
    public void SetStatsMax(int statsMax){
        slider.maxValue = statsMax;
        slider.value = statsMax;
     }
     //Define o valor minimo
     public void SetStatsMin(int statsMin){
        slider.minValue = statsMin;
     }
     public void UpdateStats(int statsVal){
        Color col = background.GetComponent<Image>().color;
        slider.value = statsVal;  

        if(statsVal < 20)
        {
            col.a = 1f;
            background.GetComponent<Image>().color = col;
        } else
        {
            col.a = 0f;
            background.GetComponent<Image>().color = col;
        }
    }
    
     
}
