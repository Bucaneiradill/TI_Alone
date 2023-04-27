using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnVelDay : MonoBehaviour
{
   public int speDay;

   public void OnButtonClick(){
      TimeManager.instance?.setSpeedDay(speDay);
   }
}