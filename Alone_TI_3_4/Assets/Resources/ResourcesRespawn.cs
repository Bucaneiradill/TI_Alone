using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesRespawn : MonoBehaviour
{
    //Variaveis
    protected bool IsBroke = false;
    public GameObject go;
    
    //Respawn 
    public void Respawn(){
          if(IsBroke == false){
            //por equanto chama nada
            Debug.Log("Ainda possui arvore");
        }else{
            Debug.Log("Respawn da arvore");
           go.SetActive(true);
           IsBroke = false; 
        }
    }
}
