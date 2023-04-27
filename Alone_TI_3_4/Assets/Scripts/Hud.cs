using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Hud : MonoBehaviour
{
   //Instancia
   public static Hud instance;
   //Sliders 
   [Header("Sliders")]
   public StatsBar lifeBar;
   public StatsBar hungerBar;
   public StatsBar thirstBar;
   public StatsBar tempBar;
   //txt e  transform
   
   void Awake(){
      instance = this;
   }
   //Coloca os valores maximos e minimos do Status do player 
   public void ColocaStatMax(StatsBar stat, int val){
      stat.SetStatsMax(val);
   }
   public void ColocaStatTemp(StatsBar stat, float valMax, float valMin, float valIni){
      stat.SetTempMax(valMax);
      stat.SetTempMin(valMin);
      stat.UpdateStatsFloat(valIni);
   }
   public void ColocaStatMinTemp(StatsBar stat, float val){
      stat.SetTempMin(val);
   } 
   public void UpdateVidaHud(int vida){
        ColocaStatMax(lifeBar, vida);
   }
   public void UpdateFomeHud(int fome){
        ColocaStatMax(hungerBar, fome); 
   }
   public void UpdateSedeHud(int sede){
        ColocaStatMax(thirstBar, sede); 
   }
   public void UpdateTempHud(float tempMax, float tempMin, float tempValue){
        ColocaStatTemp(tempBar, tempMax, tempMin, tempValue);
   }
   //
   public void updateLife(int life)
    {
        lifeBar.UpdateStats(life);
    }
   public void updateFood(int food){
      hungerBar.UpdateStats(food);
   }
   public void updateWater(int water){
       thirstBar.UpdateStats(water);
   }
   
    
}
