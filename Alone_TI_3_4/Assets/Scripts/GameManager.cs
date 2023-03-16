using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Barra_Status barraVida;
    public Barra_Status barraFome;
    public Barra_Status barraSede;
    public Barra_Status barra_Temp;
    

    public int vida = 100;
    public int fome = 50;
    public int sede = 50;
    public float tempMin = -50.00f;
    public float tempMax =  50.00f;
    /*void atualizarTemp(){
        if(Hud != null){
            Hud.instance.UpdateHud(tempMax);
            if(instance == null){
                instance = this;
            }else{
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }*/
    void Start()
    {
        vida = 100;
        barraVida.ColocarStatusMaxima(vida);
        fome = 50;
        barraFome.ColocarStatusMaxima(fome);
        sede = 50;
        barraSede.ColocarStatusMaxima(sede);
        tempMin = -50.00f;
        tempMax =  50.00f;
        barra_Temp.ColocarTempMaxima(tempMax);
        barra_Temp.ColocarTempMinimo(tempMin);
    }

    // Update is called once per frame
    void Update()
    {
        //estrutura exemplo de condição de dano e testes
        if(Input.GetKeyDown(KeyCode.D)){
            vida -= 10;
            barraVida.AlterarStatus(vida);
        }
         if(Input.GetKeyDown(KeyCode.E)){
            vida += 10;
            barraVida.AlterarStatus(vida);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            fome -= 10;
            barraFome.AlterarStatus(fome);
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            fome += 10;
            barraFome.AlterarStatus(fome);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            sede -= 10;
            barraSede.AlterarStatus(sede);
        }
        if(Input.GetKeyDown(KeyCode.W)){
            sede += 10;
            barraSede.AlterarStatus(sede);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            tempMax += 10f;
            barra_Temp.AlterarStatusFlo(tempMax);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            tempMax -= 10f;
            barra_Temp.AlterarStatusFlo(tempMax);
        }
    }
}
