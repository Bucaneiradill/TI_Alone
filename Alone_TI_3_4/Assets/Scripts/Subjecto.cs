
using System.Collections.Generic;
using UnityEngine;

public class Subjecto : MonoBehaviour
{
    public static Subjecto instance;
    public List<IObserver>list=new List<IObserver>();
    void Awake()
    {
        instance = this;
    }

    public void AddObserver(IObserver obs)
    {
        list.Add(obs);
    }

    public void NotifyAll()
    {
        foreach(IObserver obs in list)
        {
            obs.Notify();
        }
    }
}
