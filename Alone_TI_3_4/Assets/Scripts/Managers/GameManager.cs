using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    //Variavel que instancia o GameManager
    public static GameManager instance;

    //Variaveis do sistema de status
    [Header("Variaveis do sistema de status")]
    public int life = 100;
    private int lifeMax;
    public int hunger = 50;
    private int hungerMax;
    public int thirst = 50;
    private int thirstMax;
    public float tempMin = -50.0f;
    public float tempMax =  50.0f;
    public float tempValue = 0f;
    [NonSerialized]public int[] UpdateOfVariable = {2, 2, 2};
    [NonSerialized]public int[] StatsMin = {0, 0, 0};
   

    //methods
    //metodo de preservar o GameManger
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    //metodos do sistema de status
    public void addLife()
    {
         life += 0;
        Hud.instance.UpdateVidaHud(life);
    }
    public void addHunger()
    {
         hunger += 0;
        Hud.instance.UpdateFomeHud(hunger);
    }
    public void addThirst()
    {
        thirst += 0;
        Hud.instance.UpdateSedeHud(thirst);
    }    
    public void addTemp()
    {
        tempMax += 0f;
        tempMin -= 0f;
        Hud.instance.UpdateTempHud(tempMax, tempMin, tempValue);
    }
    //Atualizçãoes
    
    public void hungryAndThirstDamage(){
        if(hunger == 0 || hunger == 0){
            if(life <= 0){
                UpdateOfVariable[2]= 0;
                Debug.Log("Morreu");
            }else{
                life -= UpdateOfVariable[2];
                Hud.instance.updateLife(life);
            }
            
        }
    }
    public void temperaturaTest(){
        if(tempValue >= 50||tempValue <= -50){
            if(life <= 0){
                UpdateOfVariable[2]= 0;
                Debug.Log("Morreu");
            }else{
               life -= UpdateOfVariable[2];
               Hud.instance?.updateLife(life);
            }
        }
    }
    public void recover(int val){
        if(life == lifeMax){
            Debug.Log("Vida Maxima");
        }else{
            life += val;
            Hud.instance?.updateLife(life);
        }
    }
    public void toHungry(){
            hunger -= 2;
            Hud.instance?.updateFood(hunger);
    }
    public void toThirst(){
            thirst -= 2;
            Hud.instance?.updateWater(thirst);
    }
    public void toEat(int val){
        if(hunger == hungerMax){
            Debug.Log("Cheio");
        }else{
            hunger += val;
            Hud.instance?.updateFood(hunger);
            UIManager.instance.DisplayAction($"Comida +{val}");
        }
    }
    public void toDrink(int val){
        if(thirst == thirstMax){
            Debug.Log("Cheio");
        }else{
            thirst += val;
            Hud.instance?.updateWater(thirst);
            UIManager.instance.DisplayAction($"Hidratação +{val}");
        }
    }
    //metodos Start e Update
    void Start()
    {
        
        //Ajustes dos sliders
        addLife();
        addHunger();
        addThirst();
        addTemp();
        //Ajustes de max status
        lifeMax = life;
        hungerMax = hunger;
        thirstMax = thirst;
        
    }
    void FixedUpdate()
    {
        if(life == 50){
            UIManager.instance.DisplayAction("Vida baixa");
        }
        if(life == 10){
            UIManager.instance.DisplayAction("Você esta morrendo");
        }
        if(hunger == 25){
           UIManager.instance.DisplayAction("Você está com fome");
        }
       if(hunger == 10){
           UIManager.instance.DisplayAction("Você está faminto");
        }
        if(thirst == 25){
           UIManager.instance.DisplayAction("Você está com sede");
        }
        if(thirst == 10){
           UIManager.instance.DisplayAction("Você está desidratado");
        }
       
    }
    
}
