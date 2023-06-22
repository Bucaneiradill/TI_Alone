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
    private int life;
    public int lifeMax = 100;
    private int hunger;
    public int hungerMax = 50;
    private int thirst;
    public int thirstMax = 50;
    //temperature
    public float tempMin = -30.0f;
    public float tempMax =  30.0f;
    public float tempValue = 0f;

   

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
         life = 30;
        Hud.instance?.UpdateVidaHud(lifeMax);
        Hud.instance?.updateLife(life);
    }
    public void addHunger()
    {
         hunger = 15;
        Hud.instance?.UpdateFomeHud(hungerMax);
        Hud.instance?.updateFood(hunger);
    }
    public void addThirst()
    {
        thirst = 15;
        Hud.instance?.UpdateSedeHud(thirstMax);
        Hud.instance?.updateWater(thirst);
    }    
    public void addTemp()
    {
        tempMax += 0f;
        tempMin -= 0f;
        Hud.instance?.UpdateTempHud(tempMax, tempMin);
        Hud.instance?.updateTemp(tempValue);
    }
    //Atualizçãoes
    
    public void hungryAndThirstDamage(){
        if(hunger == 0 || hunger == 0){
            if(life <= 0){                
                Debug.Log("Morreu");
                UIManager.instance?.ShowGameOver();
            }else{
                damage(1);
            }           
        }
    }
    public void temperaturaTest(){
        if(tempValue >= 30||tempValue <= -30){
            if(life <= 0){             
                Debug.Log("Morreu");
            }else{
              damage(1);
            }
        }
    }
    public void damage(int val){
        if(life == 50){
            UIManager.instance?.DisplayAction("Vida baixa");
        }
        else if(life == 10){
            UIManager.instance?.DisplayAction("Você esta morrendo");
        }
        else if(life <= 0)
        {
            UIManager.instance?.ShowGameOver();
        }
        life -= val;
        Hud.instance?.updateLife(life);
    }
    public void recover(int val){
        life += val;
        if(life == lifeMax){
            UIManager.instance?.DisplayAction("Você Maxima");
            life = lifeMax;
            Hud.instance?.updateLife(life);
        }else{
            life += val;
            Hud.instance?.updateLife(life);
        }
    }
    public void toHungry(int val){
        hunger -= val;
        if(hunger == 25){
           UIManager.instance?.DisplayAction("Você está com fome");
        }
        if(hunger <= 0 || hunger == 10){
           UIManager.instance?.DisplayAction("Você está faminto");
        }else{       
           Hud.instance?.updateFood(hunger);
        }      
    }
    public void toThirst(int val){
        thirst -= val;
        if(thirst == 25){
           UIManager.instance?.DisplayAction("Você está com sede");
        }
        if(thirst <= 0 || thirst == 10){
           UIManager.instance?.DisplayAction("Você está desidratado");
        }else{
           Hud.instance?.updateWater(thirst);
        }           
    }
    public void toEat(int val){
        hunger += val;
        if(hunger >= hungerMax){
            Debug.Log("Cheio");
            hunger = hungerMax;
            Hud.instance?.updateFood(hunger);
            UIManager.instance?.DisplayAction($"Comida +{val}");
        }else{        
            Hud.instance?.updateFood(hunger);
            UIManager.instance?.DisplayAction($"Comida +{val}");
        }
    }
    public void toDrink(int val){
        thirst += val;
        if(thirst >= thirstMax){
            Debug.Log("Cheio");
            thirst = thirstMax;
            Hud.instance?.updateWater(thirst);
            UIManager.instance?.DisplayAction($"Hidratação +{val}");
        }else{            
            Hud.instance?.updateWater(thirst);
            UIManager.instance?.DisplayAction($"Hidratação +{val}");
        }
    }
    public void toCold(){
        if(tempValue >= tempMin){
            tempValue += 0.1f*Time.deltaTime;
            Hud.instance?.updateTemp(tempValue);
        }else{
            UIManager.instance?.DisplayAction("Frio Estremo");
        }
    }
    public void toHot(){
        if(tempValue <= tempMax){
            tempValue -= 0.1f*Time.deltaTime;
            Hud.instance?.updateTemp(tempValue);
        }else{
            UIManager.instance?.DisplayAction("Calor Estremo");
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
        
        
        
    }
    void FixedUpdate()
    {  
    }
    
}
