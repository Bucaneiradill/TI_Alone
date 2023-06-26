using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void OnPress()
    {
        UIManager.instance.settingsPanel.SetActive(false);
        UIManager.instance.inventoryPanel.SetActive(false);
        GameManager.instance.reset();
    }

}
