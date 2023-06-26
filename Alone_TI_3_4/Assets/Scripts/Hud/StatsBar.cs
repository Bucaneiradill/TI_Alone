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
     //Define o valor maximo da temperatura
     public void SetTempMax(float statsMax){
        slider.maxValue = statsMax;
     }
     //Define o valor minimo da temperatura
     public void SetTempMin(float statsMin){
        slider.minValue = statsMin;
     }
     //Atera o valor usando um float
     public void UpdateStatsFloat(float statsVal){    
       slider.value = statsVal;
     }
     
}
