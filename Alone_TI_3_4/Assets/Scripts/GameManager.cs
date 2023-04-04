using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    //Variavel que instancia o GameManager
    public static GameManager instance;

    //Variaveis do sistema de status
    [Header("Variaveis do sistema de status")]
    public Barra_Status SliderVida;
    public Barra_Status SliderFome;
    public Barra_Status SliderSede;
    public Barra_Status SliderTemp;
    public int vida = 100;
    private int vidaMax;
    public int fome = 50;
    private int fomeMax;
    public int sede = 50;
    private int sedeMax;
    public float tempMin = -50.0f;
    public float tempMax =  50.0f;
    public float tempValue = 0f;
    private int cont = 0;
    private int[] AtualizacaoDeVariavel = {2, 2, 2};
    
    //Variaveis do sistema de dia e noite
    [Header("Variaveis do sistema de dia e noite")]
    [SerializeField] public Transform luzDirecional;
    [SerializeField][Tooltip("Duração do dia em segundos")] private int duracaoDia;
    [SerializeField] private TextMeshProUGUI horarioTxt;

    private float segundos;
    private float multiplicador;

    //methods
    //metodo de preservar o GameManger
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    //metodos do sistema de status
    public void addVida()
    {
         vida += 0;
        Hud.instance.UpdateVidaHud(vida);
    }
    public void addFome()
    {
        this.fome += fome;
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
        Hud.instance.UpdateTempHud(tempMax, tempMin, tempValue);
    }
    //Metodos do sistema de dia e noite
    private void prosCeu()
    {
      float rotX = Mathf.Lerp(-90, 270, segundos/86400);
      luzDirecional.rotation = Quaternion.Euler(rotX,0,0);
    }
    private void CalcHora(){
       horarioTxt.text = TimeSpan.FromSeconds(segundos).ToString(@"hh\:mm");
      
    }
    //Atualizçãoes
    private void atualizacaoDeCiclo(){
        segundos += Time.deltaTime * multiplicador;
        
        if(segundos > 86400){
            segundos = 0;
        }
        cont++;
        if(cont == 3600){
            //Ficar com fome
            fome -= AtualizacaoDeVariavel[0];
            SliderFome.AlterarStatus(fome);
            //Ficar com sede
            sede -= AtualizacaoDeVariavel[1];
            SliderSede.AlterarStatus(sede);
           temperaturaTest();
           perdaDeVida();
           cont = 0;
        }

        if(fome == 0){
            AtualizacaoDeVariavel[0] = 0; 
        }
        if(sede == 0){
            AtualizacaoDeVariavel[1] = 0;           
        }
        
    }
    private void perdaDeVida(){
        if(sede == 0 || fome == 0){
            if(vida == 0){
                AtualizacaoDeVariavel[2]= 0;
                Debug.Log("Morreu");
            }
            vida -= AtualizacaoDeVariavel[2];
            SliderVida.AlterarStatus(vida);
        }
    }
    private void temperaturaTest(){
        if(tempValue >= 50||tempValue <= -50){
            if(vida == 0){
                AtualizacaoDeVariavel[2]= 0;
                Debug.Log("Morreu");
            }
            vida -= AtualizacaoDeVariavel[2];
            SliderVida.AlterarStatus(vida);
        }
    }
    public void recover(int val){
        if(vida == vidaMax){
            Debug.Log("Vida Maxima");
        }else{
            vida += val;
            SliderVida.AlterarStatus(vida);
        }
    }
    public  void Comer(int val){
        if(fome == fomeMax){
            Debug.Log("Cheio");
        }else{
         fome += val;
         SliderFome.AlterarStatus(fome);
        }
    }
   public  void Beber(int val){
        if(sede == sedeMax){
            Debug.Log("Cheio");
        }else{
            sede += val;
            SliderSede.AlterarStatus(sede);
        }
    }
    //metodos Start e Update
    void Start()
    {
        multiplicador = 86400/duracaoDia;
        addVida();
        addFome();
        addSede();
        addTemp();
        vidaMax = vida;
        fomeMax = fome;
        sedeMax = sede;
        
    }
    void Update()
    {
        if(vida > vidaMax){
            vida = vidaMax;
        }
        if(fome > fomeMax){
            fome = fomeMax;
        }
        if(sede > sedeMax){
            sede = sedeMax;
        }
        atualizacaoDeCiclo();
        
        prosCeu();
        CalcHora();
    }
}
