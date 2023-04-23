using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnVelDay : MonoBehaviour
{
   public int speDay;

   public void OnButtonClick(){
      GameManager.instance?.setSpeedDay(speDay);
   }
}