using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPatrolState : IState
{
    AnimalMachine Animal;
    float time;
    Vector3 dir;

    public AnimalPatrolState(AnimalMachine Animal)
    {
        this.Animal = Animal;
    }
    public void Enter()
    {
        //Debug.Log ("Patrol");
        time = Time.time;
    }
    public void Update()
    {
        
        if(Animal.energy <= 0)
        {
            Animal.SetState(new AnimalIdleState(Animal));
        }
         if(Animal.HasEnergy==true)
        {
            //Debug.Log("patrulhando");
            Animal.Move();
        }

        if(Animal.AnimalTag == "Tiger" && Animal.IsNearTarget())
        {
            Animal.SetState(new AnimalHuntState(Animal));
        }
        else if (Animal.IsNearTarget())
        {
            Animal.SetState(new AnimalChaseState(Animal));
        }
    }
    public void Exit()
    {
        
    }
    

}
