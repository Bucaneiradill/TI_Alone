using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject messagesPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] Text messageText;
    [SerializeField] float messageDuration;

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
        if(Input.GetKeyDown(KeyCode.Escape))
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

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void HideSettings()
    {
        settingsPanel.SetActive(false);
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
