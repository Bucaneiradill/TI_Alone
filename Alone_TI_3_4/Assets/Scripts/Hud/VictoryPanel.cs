using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{

    public GameObject panel;

    void Awake()
    {
        panel = GameObject.Find("InGame");
        panel.SetActive(false);
        UIManager.instance.ShowVictoryPanel();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
