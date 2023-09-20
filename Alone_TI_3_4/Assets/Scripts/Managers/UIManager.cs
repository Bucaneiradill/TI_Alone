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
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] int maxMessages = 30;
    public GameObject settingsPanel;
    public GameObject inventoryPanel;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gamePanel.activeSelf)
        {
            TimeManager.instance.boolPlay();
            settingsPanel.SetActive(!settingsPanel.activeSelf);
            menuButton.SetActive(!settingsPanel.activeSelf);
        }
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
        newMessage.text = $"{TimeManager.instance.timeString}: {message}";
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
        panel.SetActive(true);
    }

    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
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
