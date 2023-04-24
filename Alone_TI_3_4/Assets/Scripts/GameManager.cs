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
    private int cont = 0;
    private int[] UpdateOfVariable = {2, 2, 2};
    private int[] StatsMin = {0, 0, 0};
    //Variaveis do sistema de dia e noite
    [Header("Variavel de duração do dia")]
    [SerializeField][Tooltip("Duração do dia em segundos")] private int durationDay;
    private float seconds;
    private float multiplicador;

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
    private void updateDayCycle(){
        seconds += Time.deltaTime * multiplicador;
        
        if(seconds > 86400){
            seconds = 0;
        }
        cont++;
        if(cont == 3600){
            //Ficar com fome
            hunger -= UpdateOfVariable[0];
            Hud.instance?.updateFood(hunger);
            //Ficar com sede
            thirst -= UpdateOfVariable[1];
            Hud.instance?.updateWater(thirst);
           temperaturaTest();
           hungryAndThirstDamage();
           cont = 0;
        }

        if(hunger == 0){
            UpdateOfVariable[0] = 0; 
        }
        if(thirst == 0){
            UpdateOfVariable[1] = 0;           
        }
        
    }
    public void setSpeedDay(int mult){
            if(mult == 1){
             multiplicador = 86400/durationDay;
            }else if( mult == 2){
             multiplicador = (86400/durationDay)*2 ;
            }else if (mult == 3){
             multiplicador = (86400/durationDay)*3;
            }
    }
    private void hungryAndThirstDamage(){
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
    private void temperaturaTest(){
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
        //Tempo 
        durationDay = 1440;
        multiplicador = 86400/durationDay;
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
        /*if(life > lifeMax){
            life = lifeMax;
        }
        if(hunger > hungerMax){
            hunger = hungerMax;
        }
        if(thirst > thirstMax){
            thirst = thirstMax;
        }
        if(hunger < StatsMin[0]){
            hunger = StatsMin[0];
        }
        if(thirst < StatsMin[1]){
            thirst = StatsMin[1];
        }*/
        updateDayCycle();
        
        Hud.instance?.prosCeu(seconds);
        Hud.instance?.CalcTime(seconds);
    }
    
}
