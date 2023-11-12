using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalChaseState : IState
{
    AnimalMachine Animal;
    Transform target;
    Vector3 dir;

    public AnimalChaseState(AnimalMachine Animal )
    {
        this.Animal = Animal;
        
    }

    public void Enter()
    {
        Debug.Log("Chase");
    }

    public void Update()
    {
        if(Animal.AnimalTag==("Crocodile"))
        {
            Animal.Chase(3);
        }
        if(Animal.AnimalTag==("Tiger"))
        {
            Animal.Chase(5);
        }
        
        if(Animal.HasEnergy==false)
        {
            Animal.SetState(new AnimalIdleState(Animal));
        }
        if(!Animal.IsNearTarget())
        {
            Animal.SetState(new AnimalChaseState(Animal));
        }       
    }
     public void Exit(){}
}
