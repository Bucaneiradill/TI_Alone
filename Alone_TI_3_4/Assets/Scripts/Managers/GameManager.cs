using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    //Variavel que instancia o GameManager
    public static GameManager instance;

    //Variaveis do sistema de status
    [Header("Variaveis do sistema de status")]
    [SerializeField] private int life;
    public int lifeMax = 100;
    public bool canRecorver;
    [SerializeField] private int hunger;
    public int hungerMax = 100;
    [SerializeField] private int thirst;
    public int thirstMax = 100;
    [SerializeField] private int sanity;
    public int sanityMax = 100;
    public bool isLowLife;
    protected int[] newGameStats = {30, 30, 30, 80};

    [SerializeField] GameObject vignettePrefab;
    GameObject vignette;

    AudioSource audioSource;

    [Header("Sounds")]
    [SerializeField] AudioClip hungry;
    [SerializeField] AudioClip thirsty;

    [Header("Sanity")]
    [SerializeField] public bool calm;
    [SerializeField] public bool unstable;
    [SerializeField] public bool insane;

    [HideInInspector] public delegate void UpdateVignette(int life);
    [HideInInspector] public UpdateVignette updateVignette;

    [HideInInspector] public bool nearFire;
     
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
        addLife(newGameStats[0]);
        addHunger(newGameStats[1]);
        addThirst(newGameStats[2]);
        addSanity(newGameStats[3]);
        //reset();
        audioSource = GetComponent<AudioSource>();
        canRecorver = false;
    }
    //metodos do sistema de status
    public void addLife(int life)
    {
        this.life = life;
        Hud.instance?.UpdateVidaHud(lifeMax);
        Hud.instance?.updateLife(life);
    }
    public void addHunger(int hunger)
    {
        this.hunger = hunger;
        Hud.instance?.UpdateHungerHud(hungerMax);
        Hud.instance?.updateFood(hunger);
    }
    public void addThirst(int thirst)
    {
        this.thirst = thirst;
        Hud.instance?.UpdateThirstHud(thirstMax);
        Hud.instance?.updateWater(thirst);
    }  
    public void addSanity(int sanity){
        
        this.sanity = sanity;
        Hud.instance?.UpdateSanityHud(sanityMax);
        Hud.instance?.updateSanity(sanity);
    }
    //reset
    public void reset(){
        addLife(newGameStats[0]);
        addHunger(newGameStats[1]);
        addThirst(newGameStats[2]);
        addSanity(newGameStats[3]);
        if(TimeManager.instance != null)
            TimeManager.instance.seconds = 21643;
        InventoryUI.instance.ClearInventory();
    }
    //Atualizçãoes  
    public void hungryAndThirstDamage(){
        if(hunger <= 0 || thirst <= 0){
            if(life <= 0){                
                //Debug.Log("Morreu");
                TimeManager.instance.isPlaying = false;
                UIManager.instance?.ShowGameOver();
            }else{
                damage(5);
            }
        }
    }
    public void damage(int val){
        life -= val;
        toInsane(5);
        if (life <= 0)
        {
            //Debug.Log("Morreu");
            TimeManager.instance.isPlaying = false;
            UIManager.instance?.ShowGameOver();
        }
        else if(life <= 20)
        {
            if (!isLowLife)
            {
                isLowLife = true;
                vignette = Instantiate(vignettePrefab);
            }
            if(updateVignette != null) updateVignette(life);
        }
        Hud.instance?.updateLife(life);
    }
    public void recover(int val){      
        if(life == lifeMax){
            life = lifeMax;
            canRecorver = false;
            Hud.instance?.updateLife(life);
        }else{
            if(hunger >= 50 && thirst >= 50){
                life += val;
                Hud.instance?.updateLife(life);
            }
            //life += val;           
        }
        if(life > 20)
        {
            isLowLife = false;
            Destroy(vignette);
        }
    }
    public void toHungry(int val){
       
        if(hunger == 25){
            //Debug.Log(hungry.name);
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
          Hud.instance?.updateSanity(sanity);
        }else{
           sanity -= val;
           Hud.instance?.updateSanity(sanity);
        } 
    }
    public void toEat(int val){
        hunger += val;
        if(hunger >= hungerMax){
            //Debug.Log("Cheio");
            hunger = hungerMax;
            Hud.instance?.updateFood(hunger);
            UIManager.instance?.DisplayAction($"Comida +{val}");
        }else{
            //Debug.Log("Comeu");
            Hud.instance?.updateFood(hunger);
            UIManager.instance?.DisplayAction($"Comida +{val}");
        }
        toSane(5);
    }
    public void toDrink(int val){
        thirst += val;
        if(thirst >= thirstMax){
            //Debug.Log("Cheio");
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
            //Debug.Log("Esta copletamente em si");
            sanity = sanityMax;
            Hud.instance?.updateSanity(sanity);
            UIManager.instance?.DisplayAction($"Sanidade +{val}");
        }else{
            //Debug.Log("Recuperou sanidade");
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
    public void gmTimeScaleOn(){
        Time.timeScale = 1;
    }
    public void gmTimeScaleOff(){
        Time.timeScale = 0; 
    }
    public void MaxALL(){
        if(Input.GetKeyDown(KeyCode.K)){
             addLife(lifeMax);
             addHunger(hungerMax);
             addThirst(thirstMax);
             addSanity(sanityMax);
        }
    }
    void Update(){
        MaxALL();
    }
    //Salvar o GamaManager
    public GameManagerData GetGameManager(){
        GameManagerData data = new GameManagerData(life,hunger,thirst,sanity);
        return data;
    }
    //load do save
    public void SetGameManagerData(GameManagerData data){
        life = data.life;
        hunger = data.hunger;
        thirst = data.thirst;
        sanity = data.sanity;
        //TimeManager.instance.updateDayCycle();
    }

}
