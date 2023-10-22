using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalIdleState : IState
{
    AnimalMachine Animal;
    float time;
    public AnimalIdleState(AnimalMachine Animal)
    {
        this.Animal=Animal;
    }

    public void Enter()
    {
        time = Time.time+3;
        Debug.Log("idle");
    }
    public void Update()
    {
        if(Animal.HasEnergy==false)
        {
            Debug.Log("cansado");
            Animal.Rest();
        }
        
        if (Animal.HasEnergy==true)
        {
            Debug.Log("patrulhand");
            Animal.SetState(new AnimalPatrolState(Animal));
        }
    }
    public void Exit(){}
}
