using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
   public static Hud instance;
   public StatsBar lifeBar;
   public StatsBar hungerBar;
   public StatsBar thirstBar;
   public StatsBar tempBar;

   void Awake(){
      instance = this;
   }
   public void ColocaStatMax(StatsBar stat, int val){
      stat.SetStatsMax(val);
   }
   public void ColocaStatTemp(StatsBar stat, float valMax, float valMin, float valIni){
      stat.SetTempMax(valMax);
      stat.SetTempMin(valMin);
      stat.UpdateStatsFloat(valIni);
   }
   /*public void ColocaStatMinTemp(Barra_Status stat, float val){
      stat.ColocarTempMinimo(val);
   }*/
   
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
}
