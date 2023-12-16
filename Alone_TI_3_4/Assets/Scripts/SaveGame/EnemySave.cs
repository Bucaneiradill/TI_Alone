using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySave : MonoBehaviour
{
    public static EnemySave instance;
    void Awake()
    {
        instance = this;
    }
    //serve unicamente para pegar a pos dos inimigos
   
}
