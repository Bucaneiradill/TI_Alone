using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Barra_Status SliderVida;
    public Barra_Status SliderFome;
    public Barra_Status SliderSede;
    public Barra_Status SliderTemp;
    

    public int vida = 100;
    public int fome = 50;
    public int sede = 50;
    public float tempMin = -50.00f;
    public float tempMax =  50.00f;
    
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void addVida()
    {
        vida += 1;
        Hud.instance.UpdateVidaHud(vida);
    }
    public void addFome()
    {
        fome += 0;
        Hud.instance.UpdateFomeHud(fome);
    }
    public void addSede()
    {
        sede += 0;
        Hud.instance.UpdateSedeHud(sede);
    }
    public void addTemp()
    {
        tempMax += 0f;
        tempMin -= 0f;
        Hud.instance.UpdateTempHud(tempMax, tempMin);
    }
    void Start()
    {
        addVida();
        addFome();
        addSede();
        addTemp();
    
    }

    void Update()
    {
        //estrutura exemplo de condição de dano e testes
        if(Input.GetKeyDown(KeyCode.D)){
            vida -= 10;
            SliderVida.AlterarStatus(vida);
        }
         if(Input.GetKeyDown(KeyCode.E)){
            vida += 10;
            SliderVida.AlterarStatus(vida);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            fome -= 10;
            SliderFome.AlterarStatus(fome);
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            fome += 10;
            SliderFome.AlterarStatus(fome);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            sede -= 10;
           SliderSede.AlterarStatus(sede);
        }
        if(Input.GetKeyDown(KeyCode.W)){
            sede += 10;
            SliderSede.AlterarStatus(sede);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            tempMax += 5f;
            SliderTemp.AlterarStatusFlo(tempMax);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            tempMax -= 5f;
            SliderTemp.AlterarStatusFlo(tempMax);
        }
    }
}
