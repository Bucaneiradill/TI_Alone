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
    [SerializeField] GameObject settingsPanel;

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
        if(Input.GetKeyDown(KeyCode.Escape) && gamePanel.active)
        {
            settingsPanel.SetActive(!settingsPanel.active);
        }
    }

    public void LoadScene()
    {
        gamePanel.SetActive(true);
        menuPanel.SetActive(false);
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
}
