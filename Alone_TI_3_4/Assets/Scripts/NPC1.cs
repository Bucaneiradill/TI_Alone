using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour, IObserver
{
    public AnimalMachine Animal;
   
    void Start()
    {
        Subject.instance.AddObserver(this);
        //Debug.Log("this");
    }

    public void Notify()
    {
        Animal.SetState(new AnimalChaseState(Animal));
    }
}
