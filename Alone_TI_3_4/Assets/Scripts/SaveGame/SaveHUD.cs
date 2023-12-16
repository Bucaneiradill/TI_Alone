using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHUD : MonoBehaviour
{
    public void OnButtonEnterSave(){
        SaveGame.instance.Save();
        
    }
    public void OnButtonEnterLoad(){
        SaveGame.instance.Load();
    }
}
