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
    [SerializeField][Tooltip("Valor padrão do delay")] private float dalayValue = 0.05f;
    public float delay;
    
    public bool isPlaying;
    [SerializeField][Tooltip("Duração do dia em segundos")] private int seconds = 21643;
    private int contHora;

    void Awake()
    {
        instance = this;
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
       timeTxt.text = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm");//\:ss
    }
   
    public void prosCeu()
    { 
        //Debug.Log(seconds);
        float rotX = Mathf.Lerp(-90, 270, seconds/86400.0f);
    }

    public void tempValue(float temp){
        if(temp <= 86400.0f/2 ){
            GameManager.instance?.toCold();
        }
        else{
            GameManager.instance?.toHot();
        }
    }

    public void prosCeu(float seconds)
    {
        float rotX = Mathf.Lerp(-90, 270, seconds / 86400);
        if(directionalLight != null)
            directionalLight.rotation = Quaternion.Euler(rotX, 44.002f, 0);
    }

    public void updateDayCycle(){
        seconds += 1;
        tempValue(seconds);       
        if(cont >= 600){

            //Ficar com fome
            GameManager.instance?.toHungry(1);
            //Ficar com sede
            GameManager.instance?.toThirst(1);
           GameManager.instance?.temperaturaTest();
           GameManager.instance?.hungryAndThirstDamage();
           cont = 0;
        }
         cont = cont + 1;
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
            delay = (dalayValue/2);
        }
        else if (mult == 3)
        {
            Debug.Log("3X");
            delay = (dalayValue/3);
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
}
