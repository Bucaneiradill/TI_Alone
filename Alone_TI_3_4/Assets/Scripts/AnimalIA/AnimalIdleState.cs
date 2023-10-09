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
        if (Time.time>time)
        {
            Animal.SetState(new AnimalPatrolState(Animal));
        }
    }
    public void Exit(){}
}
