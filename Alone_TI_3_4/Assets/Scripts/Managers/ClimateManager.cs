using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;

public enum State{SUN, RAIN};
public class ClimateManager : MonoBehaviour
{
    public static ClimateManager instance;
    
    public State state = State.SUN; 
    State currentState = State.SUN;
    public GameObject Light;
    public GameObject VFX_chuva;
    Light lightComp;
    
    void Awake(){
        instance = this;
    }
    
    void Start()
    {
        lightComp = Light.GetComponent<Light>();
        VFX_chuva.SetActive(false);
       ChangeState();
    }

    void FixedUpdate()
    {
        if(currentState != state){
            currentState = state;
            switch(currentState){
            case State.RAIN: Rain(); break;
            case State.SUN: Sun(); break;
            }
        }
         
        
    }
    void Rain(){   
       // float fade = 1;    
        VFX_chuva.SetActive(true);
        /*do{
            fade = fade- 0.1f;
            lightComp.intensity = fade;
        }while(lightComp.intensity == 0);*/
    }
    void Sun(){
        //float fade = 0;   
        VFX_chuva.SetActive(false);
        /*do{
            fade = fade + 0.1f;
            lightComp.intensity = fade;
        }while(lightComp.intensity == 1);*/
    }
   
    public void ChangeState(){
        UIManager.instance?.DisplayAction("Trocando de clima");
        int i = Random.Range(0, 100);
        //Debug.Log("Valor do I >>>"+ i + " e "+ i%3);
        if(i <= 15){
         state = State.RAIN;
          UIManager.instance?.DisplayAction("Chovendo");
          //Debug.Log("RAIN");
        }else {
            state = State.SUN;
            UIManager.instance?.DisplayAction("Sol");
            //Debug.Log("Sun");
        }

        //state = (State)(i%3);
      /*  if(currentState == state){
            ChangeState();
        }*/
    }
}
