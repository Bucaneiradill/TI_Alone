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
    Light lightComp;
    
    void Awake(){
        instance = this;
    }
    
    void Start()
    {
        lightComp = Light.GetComponent<Light>();
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
        
        lightComp.intensity = 0;
        //state = State.SUN;
        Invoke("ChangeState", 8.0f);
    }
    void Sun(){
        
        lightComp.intensity = 1;
      Invoke("ChangeState", 8.0f);
    }
   
    public void ChangeState(){
        UIManager.instance?.DisplayAction("Trocando de clima");
        int i = Random.Range(0, 100);
        //Debug.Log("Valor do I >>>"+ i + " e "+ i%3);
        if(i <= 50){
         state = State.RAIN;
          UIManager.instance?.DisplayAction("Chovendo");
          Debug.Log("RAIN");
        }else {
            state = State.SUN;
            UIManager.instance?.DisplayAction("Sol");
            Debug.Log("Sun");
        }

        //state = (State)(i%3);
      /*  if(currentState == state){
            ChangeState();
        }*/
    }
}
