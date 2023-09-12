using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
     public Slider slider;
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
        //Debug.Log(gameObject.name);
        slider.value = statsVal;  
     }
    
     
}
