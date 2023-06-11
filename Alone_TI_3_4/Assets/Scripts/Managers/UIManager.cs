using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject messagesPanel;
    [SerializeField] GameObject gameOverPanel;
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

    public void BackToMenu()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
