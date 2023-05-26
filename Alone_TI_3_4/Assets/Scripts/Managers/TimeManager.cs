using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public float delay = 0.05f;
    public bool isPlaying;
    
    void Awake(){
      instance = this;
        
    }
     //Variaveis do sistema de dia e noite
    [Header("Variavel de duração do dia")]
    private int seconds;
    private int contHora;
    
    [Header("Tempo e Sol")]
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] public Transform directionalLight;
    [SerializeField] private int cont = 0;

    void CalcTime(){
       
       timeTxt.text = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm");//\:ss
   }
<<<<<<< HEAD:Alone_TI_3_4/Assets/Scripts/TimeManager.cs
<<<<<<< HEAD:Alone_TI_3_4/Assets/Scripts/Managers/TimeManager.cs
   public void prosCeu()
    { 
<<<<<<< HEAD:Alone_TI_3_4/Assets/Scripts/TimeManager.cs
        Debug.Log(seconds);
=======
        //Debug.Log(seconds);
>>>>>>> parent of 764e0b2 (Revert "Merge branch 'main' of https://github.com/Bucaneiradill/TI_Alone"):Alone_TI_3_4/Assets/Scripts/Managers/TimeManager.cs
        float rotX = Mathf.Lerp(-90, 270, seconds/86400.0f);
=======
   public void prosCeu(float seconds)
    {
      float rotX = Mathf.Lerp(-90, 270, seconds/86400);
>>>>>>> 07e82113ee5c1f9f1ca760b9895060b6e31727d8:Alone_TI_3_4/Assets/Scripts/TimeManager.cs
=======
   public void prosCeu()
    { 
        //Debug.Log(seconds);
        float rotX = Mathf.Lerp(-90, 270, seconds/86400.0f);
>>>>>>> parent of 764e0b2 (Revert "Merge branch 'main' of https://github.com/Bucaneiradill/TI_Alone"):Alone_TI_3_4/Assets/Scripts/Managers/TimeManager.cs
      directionalLight.rotation = Quaternion.Euler(rotX,44.002f,0);
    }

    public void updateDayCycle(){
        seconds += 1;       
        if(cont >= 600){
            
            //Ficar com fome
            GameManager.instance?.toHungry();
            //Ficar com sede
            GameManager.instance?.toThirst();
           GameManager.instance?.temperaturaTest();
           GameManager.instance?.hungryAndThirstDamage();
           cont = 0;
        }
         cont = cont + 1;
    }
    public void setSpeedDay(int mult){
            if(mult == 1){
             delay = 0.05f;
            }else if( mult == 2){
             delay = (0.05f/2);
            }else if (mult == 3){
             delay = (0.05f/3);
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Tempo
        Invoke("TimeCount", delay);
    }

    void TimeCount()
    {
        if (isPlaying)
        {
            updateDayCycle();
            prosCeu();
            CalcTime();
        }

        Invoke("TimeCount", delay);
    }
}