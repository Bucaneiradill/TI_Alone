using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesRespawn : MonoBehaviour
{
    public static ResourcesRespawn instance;
    void Awake(){
        instance = this;
    }
    //Variaveis
    public bool IsBroke;
    public GameObject gameObj;
    
    //Respawn 
    public void Respawn(){
          if(IsBroke == false){
            //por equanto chama nada
            Debug.Log("Ainda possui arvore");
        }else{
            Debug.Log("Respawn da arvore");
           gameObj.SetActive(true);
           IsBroke = false; 
        }
    }
    
    void Update()
    {
       if(!gameObj.activeSelf){
        IsBroke = true;
       } 
    }
}
