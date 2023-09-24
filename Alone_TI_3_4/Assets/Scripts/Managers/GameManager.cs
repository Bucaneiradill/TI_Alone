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
    [SerializeField] private int hunger;
    public int hungerMax = 100;
    [SerializeField] private int thirst;
    public int thirstMax = 100;
    [SerializeField] private int sanity;
    public int sanityMax = 100;

    AudioSource audioSource;

    [Header("Sounds")]
    [SerializeField] AudioClip hungry;
    [SerializeField] AudioClip thirsty;

    [Header("Sanity")]
    [SerializeField] private bool calm;
    [SerializeField] private bool unstable;
    [SerializeField] private bool insane;

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

    void Start()
    {
        //Ajustes dos sliders
        addLife();
        addHunger();
        addThirst();
        addSanity();
        //reset();
        audioSource = GetComponent<AudioSource>();
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
        Hud.instance?.UpdateHungerHud(hungerMax);
        Hud.instance?.updateFood(hunger);
    }
    public void addThirst()
    {
        thirst = 30;
        Hud.instance?.UpdateThirstHud(thirstMax);
        Hud.instance?.updateWater(thirst);
    }  
    public void addSanity(){
        sanity = 80;
        Hud.instance?.UpdateSanityHud(sanityMax);
        Hud.instance?.updateSanity(sanity);
    }
    //reset
    public void reset(){
        addLife();
        addHunger();
        addThirst();
        addSanity();
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
            Debug.Log(hungry.name);
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
    public void toInsane(int val){
        if(sanity <= 0){
          sanity = 0;
          Hud.instance?.updateWater(sanity);
        }else{
           sanity -= val;
           Hud.instance?.updateSanity(sanity);
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
            Debug.Log("Comeu");
            Hud.instance?.updateFood(hunger);
            UIManager.instance?.DisplayAction($"Comida +{val}");
        }
        toSane(5);
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
        toSane(5);
    }
    public void toSane(int val){
         sanity += val;
        if(sanity >= sanityMax){
            Debug.Log("Esta copletamente em si");
            sanity = sanityMax;
            Hud.instance?.updateSanity(sanity);
            UIManager.instance?.DisplayAction($"Sanidade +{val}");
        }else{
            Debug.Log("Recuperou sanidade");
            Hud.instance?.updateSanity(sanity);
            UIManager.instance?.DisplayAction($"Sanidade +{val}");
        }
    }
    public void sanityCheck(){
        if (sanity <= 25){
            calm = false;
            unstable = false;
            insane = true;
            UIManager.instance?.DisplayAction("Você está INSANO");
        }else if(sanity < 75 && sanity >25){
            calm = false;
            unstable = true;
            insane = false;
            UIManager.instance?.DisplayAction("Você está INSTAVEL");
        }else{
            calm = true;
            unstable = false;
            insane = false;
            UIManager.instance?.DisplayAction("Você está CALMO");
        }
    }
}
