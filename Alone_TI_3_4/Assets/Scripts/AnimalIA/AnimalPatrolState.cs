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
        Debug.Log ("Patrol");
        time = Time.time;
    }
    public void Update()
    {
        Animal.Move();
        if(Animal.energy <= 0)
        {
            Animal.SetState(new AnimalIdleState(Animal));
        }
        else if(Animal.IsNearTarget())
        {
            Animal.SetState(new AnimalChaseState(Animal));
        }
    }
    public void Exit(){}
    

}
