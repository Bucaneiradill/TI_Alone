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
    [SerializeField] private int life;
    public int lifeMax = 100;
    private int hunger;
    public int hungerMax = 100;
    private int thirst;
    public int thirstMax = 100;
    //temperature
    public float tempMin = -30.0f;
    public float tempMax =  30.0f;
    public float tempValue = 0f;
    AudioSource audioSource;

    [Header("Sounds")]
    [SerializeField] AudioClip hungry;
    [SerializeField] AudioClip thirsty;

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
         hunger = 30;
        Hud.instance?.UpdateFomeHud(hungerMax);
        Hud.instance?.updateFood(hunger);
    }
    public void addThirst()
    {
        thirst = 30;
        Hud.instance?.UpdateSedeHud(thirstMax);
        Hud.instance?.updateWater(thirst);
    }    
    public void addTemp()
    {
        tempMax +=  30f;
        tempMin -= -30f;
        tempValue = 0.1f;
        Hud.instance?.UpdateTempHud(tempMax, tempMin);
        Hud.instance?.updateTemp(tempValue);
    }
    //reset
    public void reset(){
        addLife();
        addHunger();
        addThirst();
        //addTemp();
        if(TimeManager.instance != null)
            TimeManager.instance.seconds = 21643;
        InventoryUI.instance.ClearInventory();
    }
    //Atualizçãoes
    
    public void hungryAndThirstDamage(){
        if(hunger <= 0 || thirst <= 0){
            if(life <= 0){                
                Debug.Log("Morreu");
                TimeManager.instance.isPlaying = false;
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
        if(life == lifeMax){
            UIManager.instance?.DisplayAction("Você Maxima");
            life = lifeMax;
            Hud.instance?.updateLife(life);
        }else{
            if(hunger >= 50 && thirst >= thirstMax){
                life += val;
                Hud.instance?.updateLife(life);
            }
            //life += val;
            
        }
    }
    public void toHungry(int val){
       
        if(hunger == 25){
            audioSource.clip = hungry;
            audioSource.Play();
            UIManager.instance?.DisplayAction("Você está com fome");
        }
        if(hunger <= 0 || hunger == 10){
            audioSource.clip = hungry;
            audioSource.Play();
            UIManager.instance?.DisplayAction("Você está faminto");
        }
        if(hunger<=0){
            hunger = 0;
            Hud.instance?.updateFood(hunger);
        }else{ 
             hunger -= val;      
             Hud.instance?.updateFood(hunger);
        }      
    }
    public void toThirst(int val){
        
        if(thirst == 25){
           UIManager.instance?.DisplayAction("Você está com sede");
        }
        if(thirst <= 0 || thirst == 10){
           UIManager.instance?.DisplayAction("Você está desidratado");
        }
        if(thirst <= 0){
          thirst = 0;
          Hud.instance?.updateWater(thirst);
        }else{
            thirst -= val;
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
        //reset();
        audioSource = GetComponent<AudioSource>();
       
    }
    void FixedUpdate()
    {  
    }
    
}
