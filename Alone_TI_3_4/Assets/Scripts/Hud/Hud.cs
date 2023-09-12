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
   public StatsBar sanityBar;
   //txt e  transform
   
   void Awake(){
      instance = this;
   }
   //Coloca os valores maximos e minimos do Status do player 
   public void SetStatMax(StatsBar stat, int val){
      stat.SetStatsMax(val);
   }
  
   public void UpdateVidaHud(int vida){
      SetStatMax(lifeBar, vida);
   }
   public void UpdateHungerHud(int hunger){
      SetStatMax(hungerBar, hunger); 
   }
   public void UpdateThirstHud(int thirst){
      SetStatMax(thirstBar, thirst); 
   }
   public void UpdateSanityBar(int sanity){
      SetStatMax(sanityBar, sanity);
   }
  
   //atualização dos status
   public void updateLife(int life){
      lifeBar.UpdateStats(life);
    }
   public void updateFood(int food){        
      hungerBar.UpdateStats(food);
   }
   public void updateWater(int water){
      thirstBar.UpdateStats(water);
   }
   public void updateSanity(int sanity){
      sanityBar.UpdateStats(sanity);
   }

}
