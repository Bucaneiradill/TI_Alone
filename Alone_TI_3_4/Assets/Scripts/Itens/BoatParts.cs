using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "New Item", menuName = "BoatPart")]
public class BoatParts : Item
{
    // Start is called before the first frame update
   public override void PerformAction(ColectableSource source)
    {
        // L�gica espec�fica para a��o coleta de parte do barco
          GameManager.instance.CollectBoatPart();
       
    }
}
