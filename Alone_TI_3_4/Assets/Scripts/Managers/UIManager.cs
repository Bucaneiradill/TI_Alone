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
    [SerializeField] public GameObject settingsPanel;

    [SerializeField] Text messageText;
    [SerializeField] float messageDuration;
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

    public void DisplayAction(string message)
    {
        Text newMessage = Instantiate(messageText, messagesPanel.transform);
        newMessage.text = message;
        Destroy(newMessage.gameObject, messageDuration);
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
