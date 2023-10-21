using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void OnPress()
    {
        UIManager.instance.CloseAll();
        UIManager.instance.HideGameOver();
        GameManager.instance.reset();
    }

}
