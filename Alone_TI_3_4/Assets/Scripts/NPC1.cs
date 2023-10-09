using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour, IObserver
{
    public AnimalMachine Animal;
   


    void Start()
    {
        Subjecto.instance.AddObserver(this);
        Debug.Log("this");
      
    }

    // Update is called once per frame
    public void Notify()
    {
       Animal.SetState(new AnimalChaseState(Animal));
    }
}
