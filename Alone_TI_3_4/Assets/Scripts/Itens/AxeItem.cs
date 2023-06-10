using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Axe", menuName = "Inventory/Axe")]
public class AxeItem : Item
{
    public override void PerformAction()
    {
        // Lógica específica para ação do machado
        Debug.Log("Axe action performed");
    }
}
