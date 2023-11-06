using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHuntState : IState
{
   AnimalMachine Animal;

   
   public  AnimalHuntState(AnimalMachine Animal)
   {
         this.Animal = Animal;
   }

   public void Enter()
   {
    Debug.Log("Hunting");
   }

   public void Update()
   {
    Animal.Hunt();
    if(Animal.HasEnergy==false)
    {
        Animal.SetState(new AnimalIdleState(Animal));
    }
    if(PlayerActions.PlayerInstance.IsWalking == false)
    {
        Animal.SetState(new AnimalChaseState(Animal));
    }
   }

   public void Exit()
   {

   }
}   
