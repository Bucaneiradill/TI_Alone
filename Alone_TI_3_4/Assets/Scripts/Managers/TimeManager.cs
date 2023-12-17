using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    //Variaveis do sistema de dia e noite
    [Header("Variavel de duração do dia")]
    //[SerializeField][Tooltip("Duração do dia em segundos")] private int durationDay;
    [Header("Tempo e Sol")]
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] public Transform directionalLight;
    [SerializeField] private int cont = 0;
    [SerializeField] private int cont2 = 0;
    [SerializeField][Tooltip("Valor padrão do delay")] private float dalayValue = 0.03f;
    public float delay;
    public string timeString;
    public bool isPlaying;
    [SerializeField][Tooltip("Duração do dia em segundos")] public int seconds;
    //valores de tempo: 6h da manha => 21600
    void Awake()
    {
        instance = this;
        isPlaying = true;
    }

    void Start()
    {
        setSpeedDay(1);
        //Tempo
        delay = dalayValue;
        
        Invoke("TimeCount", delay);
        directionalLight = GameObject.Find("Directional_Light").transform;
        timeTxt = UIManager.instance.timeTxt;
        //Sanidade
        GameManager.instance?.sanityCheck();
    }

    public void SkipTime(int seconds = 21600)
    {
        this.seconds += seconds;
        int curLife = GameManager.instance.life;
        int curHunger = GameManager.instance.hunger;
        int curThirst = GameManager.instance.thirst;
        GameManager.instance.addLife(curLife + (curThirst+curHunger)/2);
        GameManager.instance.addSanity(40);
        GameManager.instance.toHungry(10);
        GameManager.instance.toThirst(10);
        prosCeu(seconds);
        CalcTime(seconds);
    }
    
    void CalcTime(float seconds)
    {
        timeString = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm");
        timeTxt.text = timeString;//\:ss
    }
   
   /* public void prosCeu()
    { 
        //Debug.Log(seconds);
        float rotX = Mathf.Lerp(-90, 270, seconds/86400.0f);
    }*/

    public void prosCeu(float seconds)
    {
        float rotX = Mathf.Lerp(-90, 270, seconds / 86400);
        if(directionalLight != null)
            directionalLight.rotation = Quaternion.Euler(rotX, 44.002f, 0);
    }

    public void updateDayCycle(){
        seconds += 1;
        if(cont2 >= 200){
            GameManager.instance.recover(5);
            cont2 = 0;
        }
        if(cont >= 600){
            //Checar a sanidade
            if(ClimateManager.instance.state == State.RAIN || seconds > 69304 || seconds < 21600 || !GameManager.instance.nearFire){
              GameManager.instance?.toInsane(5); 
            }else{
             GameManager.instance?.toInsane(1); 
            }           
            GameManager.instance?.sanityCheck();
            //Ficar com fome e sede
            if(GameManager.instance.calm == true){
                GameManager.instance?.toHungry(1);
                GameManager.instance?.toThirst(1);
            }else if(GameManager.instance.unstable == true){
                GameManager.instance?.toHungry(3);
                GameManager.instance?.toThirst(3);
            }else if(GameManager.instance.insane == true){
                GameManager.instance?.toHungry(5);
                GameManager.instance?.toThirst(5);
            }           
            GameManager.instance?.hungryAndThirstDamage();
            cont = 0;             
            //Clima
            ClimateManager.instance?.ChangeState();
            
            
        }
        cont = cont + 1;
        cont2 = cont2 + 1;
    }

    public void setSpeedDay(int mult)
    {
        if (mult == 1)
        {
            Debug.Log("1X");
            Time.timeScale = 1;
            delay = dalayValue;
        }
        else if (mult == 2)
        {
            Debug.Log("2X");
            Time.timeScale = 2;
            //delay = dalayValue/4;
        }
        else if (mult == 3)
        {
            Debug.Log("3X");
            Time.timeScale = 3;
            //delay = dalayValue/6;
        }
    }

    void TimeCount(){
        if(isPlaying){
            updateDayCycle();
            prosCeu(seconds);
            CalcTime(seconds);
        }
       Invoke("TimeCount", delay);
    }
    //bool play
    public void boolPlay(){
        isPlaying = !isPlaying;
    }
    // Salvar o TimeManager
    public TimeManagerData GetTimeManagerData(){
        TimeManagerData data = new TimeManagerData(seconds);
        return data;
    }
    //Load do save
    public void SetTimeManagerData(TimeManagerData data){
        seconds = data.seconds;
    }
}
