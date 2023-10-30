using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public static Subject instance;
    public List<IObserver> list = new List<IObserver>();
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddObserver(IObserver obs)
    {
        list.Add(obs);
    }

    public void NotifyAll()
    {
        foreach (IObserver obs in list)
        {
            obs.Notify();
        }
    }
}
