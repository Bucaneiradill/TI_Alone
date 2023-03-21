using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
   public static Hud instance;
   public Barra_Status barraVida;
   public Barra_Status barraFome;
   public Barra_Status barraSede;
   public Barra_Status barra_Temp;

   void Awake(){
      instance = this;
   }
   public void ColocaStatMax(Barra_Status stat, int val){
      stat.ColocarStatusMaxima(val);
   }
   public void ColocaStatMaxTemp(Barra_Status stat, float val){
      stat.ColocarTempMaxima(val);
   }
   public void ColocaStatMinTemp(Barra_Status stat, float val){
      stat.ColocarTempMinimo(val);
   }
   public void UpdateVidaHud(int vida){
        ColocaStatMax(barraVida, vida);
   }
   public void UpdateFomeHud(int fome){
        ColocaStatMax(barraFome, fome); 
   }
   public void UpdateSedeHud(int sede){
        ColocaStatMax(barraSede, sede); 
   }
   public void UpdateTempHud(float tempMax, float tempMin){
        ColocaStatMaxTemp(barra_Temp, tempMax);
        ColocaStatMinTemp(barra_Temp, tempMin);
   }
}
