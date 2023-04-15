using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject messagesPanel;
    [SerializeField] Text messageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayAction(string message)
    {
        Text newMessage = Instantiate(messageText, messagesPanel.transform);
        newMessage.text = message;
        Destroy(newMessage.gameObject, 3f);
    }
}
