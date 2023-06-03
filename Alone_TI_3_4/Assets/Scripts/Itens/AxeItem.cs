using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Axe", menuName = "Inventory/Axe")]
public class AxeItem : Item
{
    public override void PerformAction()
    {
        // L�gica espec�fica para a��o do machado
        Debug.Log("Axe action performed");
    }
}
