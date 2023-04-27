using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    
    void Awake(){
      instance = this;
    }
     //Variaveis do sistema de dia e noite
    [Header("Variavel de duração do dia")]
    [SerializeField][Tooltip("Duração do dia em segundos")] private int durationDay;
    private float seconds;
    private float multiplicador;
    [Header("Tempo e Sol")]
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] public Transform directionalLight;
    [SerializeField] private float cont = 0;

    public void CalcTime(float seconds){
       timeTxt.text = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm");
   }
   public void prosCeu(float seconds)
    {
      float rotX = Mathf.Lerp(-90, 270, seconds/86400);
      directionalLight.rotation = Quaternion.Euler(rotX,44.002f,0);
    }

    public void updateDayCycle(){
        seconds += Time.deltaTime * multiplicador;
        
        if(seconds > 86400){
            seconds = 0;
        }
       
        if(cont >= 600){
            //3600
            //Ficar com fome
            GameManager.instance?.toHungry();
            //Ficar com sede
            GameManager.instance?.toThirst();
           GameManager.instance?.temperaturaTest();
           GameManager.instance?.hungryAndThirstDamage();
           cont = 0;
        }
         cont +=  Time.deltaTime * multiplicador;
    }
    public void setSpeedDay(int mult){
            if(mult == 1){
             multiplicador = 86400/durationDay;
            }else if( mult == 2){
             multiplicador = (86400/durationDay)*4 ;
            }else if (mult == 3){
             multiplicador = (86400/durationDay)*6;
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Tempo 
        durationDay = 1440;
        multiplicador = 86400/durationDay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateDayCycle();
        prosCeu(seconds);
        CalcTime(seconds);
    }
}
