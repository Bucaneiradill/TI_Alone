using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenResCount : MonoBehaviour
{
    //Lista de objs
    public static ItenResCount instance;
    public SpawnerItem[] list;
    void Start()
    {
        list = FindObjectsByType<SpawnerItem>(FindObjectsSortMode.None);
        Invoke("UpdateSpawner",1f);
    }

    void UpdateSpawner()
    {
        foreach (SpawnerItem i in list){
            if (!i.obj.activeSelf){
                if (Time.time > i.time){
                    i.Active();
                }
            }
        }
        Invoke("UpdateSpawner", 1f);
    }

}
