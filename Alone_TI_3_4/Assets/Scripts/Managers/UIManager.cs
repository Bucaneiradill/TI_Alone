using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Panels")]
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject messagesPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject inventoryButton;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] int maxMessages = 30;
    public GameObject settingsPanel;
    public GameObject inventoryPanel;
    public Text questTitle;
    public TextMeshProUGUI questDescription;


    public GameObject[] panels;
    public KeyCode[] keys;
    public Stack<int> openIDs = new Stack<int>();
    public bool open = false;
    public bool stack = false;
    int settings = 0;
    int keyCurrent = -1;


    [SerializeField] Text messageText;
    public TextMeshProUGUI timeTxt;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    /*------------------------------------------------------------------------------
    Função:     Update
    Descrição:  Verifica qual tecla foi apertada
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    private void Update()
    {
        for (int i = settings + 1; i < keys.Length; i++){
            if (Input.GetKeyDown(keys[i])){
                Open(i);
            }  
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            Close();
        }
    }
    /*------------------------------------------------------------------------------
    Função:     Close
    Descrição:  Fecha o painel regente
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void Close(){
        if (openIDs.Count == 0){ //Verifica se tem algum painel aberto, caso não tenha abra asa configurações e saia do codigo
            Open(settings); 
            return;  
        }
        if(openIDs.Count > 0){
            int i = openIDs.Pop(); //Desempilha o ultimo elemento do Stack
            panels[i].SetActive(false); 
            //TimeManager.instance.boolPlay();
            if(openIDs.Count == 0) open = false; //Caso ele tenha desempilhado o ultimo painel diga que não tem mais nada aberto
        }
    }
    /*------------------------------------------------------------------------------
    Função:     Open
    Descrição:  abre os paineis
    Entrada:    int - qual tecla foi apertada
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void Open(int i){
        if(i != settings) keyCurrent = i; //caso o estado futuro seja diferente da tela de cofigurações atualize o estado atual  
        if(keyCurrent == i && panels[keyCurrent].activeSelf){ //verifica se a mesma tecla foi apertada duas vezes caso tenha sido fecha o painel regente e saia do open
            keyCurrent = -1;
            Close();
            return;
        }
        if(open && (!stack))return; //Condição que verifica se tem paineis que foram estacados e se tem algum painel aberto
        //TimeManager.instance.boolPlay();
        openIDs.Push(i); //coloca o painel na lista
        panels[i].SetActive(true); //ativa o painel
        open = true; //diz que tem algum painel ativo no momento
    }
    /*------------------------------------------------------------------------------
    Função:     CloseAll
    Descrição:  Fecha todos os paineis
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void CloseAll() {
        openIDs.Clear();
        foreach (var w in panels) w.SetActive(false);
        open = false;
    }

    public void LoadScene()
    {
        gamePanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void LoadMenu()
    {
        gamePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void ShowControls(){
        gamePanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void ExitControlsScreen(){
        controlsPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void ShowCredits(){
        gamePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void ExitCreditsScreen(){
        creditsPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void DisplayAction(string message)
    {
        Text newMessage = Instantiate(messageText, messagesPanel.transform);
        newMessage.text = $"{TimeManager.instance?.timeString}: {message}";
        if(messagesPanel.transform.childCount >= maxMessages)
        {
            Destroy(messagesPanel.transform.GetChild(0).gameObject);
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void HidePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void BackToMenu()
    {
        gamePanel.SetActive(false);
        menuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void QuitCame()
    {
        Application.Quit();
    }
    
        
}
