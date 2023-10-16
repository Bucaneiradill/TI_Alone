using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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
    [SerializeField][Tooltip("Valor padrão do delay")] private float dalayValue = 0.05f;
    public float delay;
    public string timeString;
    public bool isPlaying;
    [SerializeField][Tooltip("Duração do dia em segundos")] public int seconds = 21643;
    private int contHora;

    void Awake()
    {
        instance = this;
        isPlaying = true;
    }

    void Start()
    {
        /* //Tempo 
         durationDay = 1440;
         multiplicador = 86400 / durationDay;*/
        //Tempo
        delay = dalayValue;
        
        Invoke("TimeCount", delay);
        directionalLight = GameObject.Find("Directional_Light").transform;
        timeTxt = UIManager.instance.timeTxt;
    }
    
    void CalcTime(float seconds)
    {
        timeString = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm");
        timeTxt.text = timeString;//\:ss
    }
   
    public void prosCeu()
    { 
        //Debug.Log(seconds);
        float rotX = Mathf.Lerp(-90, 270, seconds/86400.0f);
    }

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
            //Ficar com fome
            GameManager.instance?.toHungry(1);
            //Ficar com sede
            GameManager.instance?.toThirst(1);
            GameManager.instance?.hungryAndThirstDamage();
            cont = 0;
            //Checar a sanidade
            GameManager.instance?.toInsane(1);
            GameManager.instance?.sanityCheck();
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
            delay = dalayValue;
        }
        else if (mult == 2)
        {
            Debug.Log("2X");
            delay = (dalayValue/4);
        }
        else if (mult == 3)
        {
            Debug.Log("3X");
            delay = (dalayValue/6);
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
   /* void  Update()
    {
         if(isPlaying == true){
            Time.timeScale = 1;           
            }
         if(isPlaying == false){
            Time.timeScale = 0;          
        }
    }*/
}
