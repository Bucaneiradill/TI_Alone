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
    public StatsBar SliderLife;
    public StatsBar SliderHunger;
    public StatsBar SliderThirst;
    public StatsBar SliderTemp;
    public int life = 100;
    private int lifeMax;
    public int hunger = 50;
    private int hungerMax;
    public int thirst = 50;
    private int thirstMax;
    public float tempMin = -50.0f;
    public float tempMax =  50.0f;
    public float tempValue = 0f;
    private int cont = 0;
    private int[] UpdateOfVariable = {2, 2, 2};
    private int[] StatsMin = {0, 0, 0};
    //Variaveis para buscar os sliders
    GameObject findSliderLife;
    GameObject findSliderHunger;
    GameObject findSliderThirst;
    GameObject findSliderTemp;
    GameObject findDirectionalLight;
    GameObject findTempTxt;
    //Variaveis do sistema de dia e noite
    [Header("Variaveis do sistema de dia e noite")]
    [SerializeField] public Transform directionalLight;
    [SerializeField][Tooltip("Duração do dia em segundos")] private int durationDay;
    [SerializeField] private TextMeshProUGUI timeTxt;

    private float seconds;
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
    public void addLife()
    {
         life += 0;
        Hud.instance.UpdateVidaHud(life);
    }
    public void addHunger()
    {
         hunger += 0;
        Hud.instance.UpdateFomeHud(hunger);
    }
    public void addThirst()
    {
        thirst += 0;
        Hud.instance.UpdateSedeHud(thirst);
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
      float rotX = Mathf.Lerp(-90, 270, seconds/86400);
      directionalLight.rotation = Quaternion.Euler(rotX,0,0);
    }
    private void CalcTime(){
       timeTxt.text = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm");
      
    }
    //Atualizçãoes
    private void updateDayCycle(){
        seconds += Time.deltaTime * multiplicador;
        
        if(seconds > 86400){
            seconds = 0;
        }
        cont++;
        if(cont == 3600){
            //Ficar com fome
            hunger -= UpdateOfVariable[0];
            SliderHunger.UpdateStats(hunger);
            //Ficar com sede
            thirst -= UpdateOfVariable[1];
            SliderThirst.UpdateStats(thirst);
           temperaturaTest();
           perdaDeVida();
           cont = 0;
        }

        if(hunger == 0){
            UpdateOfVariable[0] = 0; 
        }
        if(thirst == 0){
            UpdateOfVariable[1] = 0;           
        }
        
    }
    private void perdaDeVida(){
        if(hunger == 0 || hunger == 0){
            if(life == 0){
                UpdateOfVariable[2]= 0;
                Debug.Log("Morreu");
            }
            life -= UpdateOfVariable[2];
            SliderLife.UpdateStats(life);
        }
    }
    private void temperaturaTest(){
        if(tempValue >= 50||tempValue <= -50){
            if(life == 0){
                UpdateOfVariable[2]= 0;
                Debug.Log("Morreu");
            }
            life -= UpdateOfVariable[2];
            SliderLife.UpdateStats(life);
        }
    }
    public void recover(int val){
        if(life == lifeMax){
            Debug.Log("Vida Maxima");
        }else{
            life += val;
            SliderLife.UpdateStats(life);
        }
    }
    public void toEat(int val){
        if(hunger == hungerMax){
            Debug.Log("Cheio");
        }else{
         hunger += val;
         SliderHunger.UpdateStats(hunger);
        }
    }
    public void toDrink(int val){
        if(thirst == thirstMax){
            Debug.Log("Cheio");
        }else{
            thirst += val;
            SliderThirst.UpdateStats(thirst);
        }
    }
    //metodos Start e Update
    void Start()
    {
        findSliderLife = GameObject.Find("Canvas/Slider-Vida");
        SliderLife = findSliderLife.GetComponent<StatsBar>();
        findSliderHunger = GameObject.Find("Canvas/Slider-Fome");
        SliderHunger = findSliderHunger.GetComponent<StatsBar>();
        findSliderThirst = GameObject.Find("Canvas/Slider-Sede");
        SliderThirst = findSliderThirst.GetComponent<StatsBar>();
        findSliderTemp = GameObject.Find("Canvas/Slider-Temp");
        SliderTemp = findSliderTemp.GetComponent<StatsBar>();
        
        findDirectionalLight = GameObject.Find("Directional_Light");
        directionalLight = findDirectionalLight.GetComponent<Transform>();
        findTempTxt = GameObject.Find("Canvas/TempoTxt");
        timeTxt = findTempTxt.GetComponent<TextMeshProUGUI>();

        //Tempo 
        durationDay = 1440;
        multiplicador = 86400/durationDay;
        //Ajustes dos sliders
        addLife();
        addHunger();
        addThirst();
        addTemp();
        //Ajustes de max status
        lifeMax = life;
        hungerMax = hunger;
        thirstMax = thirst;
        
    }
    void Update()
    {
        if(life > lifeMax){
            life = lifeMax;
        }
        if(hunger > hungerMax){
            hunger = hungerMax;
        }
        if(thirst > thirstMax){
            thirst = thirstMax;
        }
        if(hunger < StatsMin[0]){
            hunger = StatsMin[0];
        }
        if(thirst < StatsMin[1]){
            thirst = StatsMin[1];
        }
        updateDayCycle();
        
        prosCeu();
        CalcTime();
    }
    public static void FindSlider(GameObject obj, StatsBar slider, string sliderName){
        obj = GameObject.Find($"Canvas/{sliderName}");
        slider = obj.GetComponent<StatsBar>();
    }
}
