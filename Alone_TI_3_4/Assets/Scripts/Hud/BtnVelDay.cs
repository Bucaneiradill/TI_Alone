using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnVelDay : MonoBehaviour
{
    public List<GameObject> buttons;
    public GameObject button;
    public int speDay;
    

    void OnEnable()
    {
        Ressetbtn(); 
    }
    
    void Ressetbtn(){
        Color col = button.GetComponent<Image>().color;
        for(int i = 0; i<3; i++){
            if(i == 0){
                col.a = 1f;
                buttons[i].GetComponent<Image>().color = col; 
            }else{
                col.a = .5f;
                buttons[i].GetComponent<Image>().color = col; 
            }
        }  
    }

    public void OnButtonClick(){
        TimeManager.instance?.setSpeedDay(speDay);
        Color col = button.GetComponent<Image>().color;

        foreach (var b in buttons)
        {
            if(b == button)
            {
                Debug.Log("Entrou if");
                col.a = 1f;
                b.GetComponent<Image>().color = col;
                return;
            } else
            {
                Debug.Log("Entrou else");
                col.a = .5f;
                b.GetComponent<Image>().color = col;
            }
        }
    }
}