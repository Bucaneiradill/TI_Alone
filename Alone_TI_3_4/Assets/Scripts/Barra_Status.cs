using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Status : MonoBehaviour
{
     public Slider slider;
      //Define o valor maximo
     public void ColocarStatusMaxima(int statusMax){
        slider.maxValue = statusMax;
        slider.value = statusMax;
     }
     //Define o valor minimo
     public void ColocarStatusMamino(int statusMin){
        slider.minValue = statusMin;
     }
     public void AlterarStatus(int statusVal){       
        slider.value = statusVal;  
     }
     //Define o valor maximo da temperatura
     public void ColocarTempMaxima(float statusMax){
        slider.maxValue = statusMax;
     }
     //Define o valor minimo da temperatura
     public void ColocarTempMinimo(float statusMin){
        slider.minValue = statusMin;
     }
     //Atera o valor usando um float
     public void AlterarStatusFlo(float statusVal){    
       slider.value = statusVal;
     }
}
