/**************************************************************
    Jogos Digitais SG
    InventorySlot

    Descrição:  Gerencia quais itens foram adicionados ao inventário e quanto espaço resta no mesmo.

    Alone - Jogos Digitais SG –  09/04/2022
    Modificado por: 
***************************************************************/

//-------------------------- Bibliotecas Usadas --------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon; 
    [SerializeField] Button removeButton;
    Item item;

    /*------------------------------------------------------------------------------
    Função:     AddItemSlot
    Descrição:  Adiciona o item no slot da UI
    Entrada:    Item - Qual item está sendo adicionado no slot do inventario. 
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void AddItemSlot(Item newItem){
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.preserveAspect = true;
        removeButton.interactable = true;
    }
    /*------------------------------------------------------------------------------
    Função:     ClearSlot
    Descrição:  Remove o item no slot da UI
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void ClearSlot(){ 
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    /*------------------------------------------------------------------------------
    Função:     OnRemoveButton
    Descrição:  Remove o item da lista de items
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void OnRemoveButton(){
        if(item.PrefabItem != null){
            Instantiate(item.PrefabItem, Inventory.instance.PlayerPosition.position, Quaternion.identity);
        }
        OnDeletItemInventory();
    }
    /*------------------------------------------------------------------------------
    Função:     OnDropItem
    Descrição:  Dropa o Item
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void OnDeletItemInventory(){
        if (item != null && item.isEquipable)
        {
            int index = EquipmentUI.instance.FindItem(item);
            if (index != -1)
            {
                EquipmentUI.instance.RemoveItem(index);
            }
        }
        Inventory.instance.RemoveItem(item);
    }
    /*------------------------------------------------------------------------------
    Função:     OnClickItem
    Descrição:  Verifica se o usuário clicou no item no inventário
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void OnClickItem()
    {
        if(item != null){
            if (item.isEquipable)
            {
                if (EquipmentUI.instance.FindItem(item) == -1)
                {
                    EquipmentUI.instance.SetItem(item);
                }
            }
            else if (item.isConsumable)
            {
                item.PerformAction();
            }else if (item.isPlaceable)
            {
                PlacementSystem.instance.StartPlacement(item.iD);
                UIManager.instance.Close();
            }
        }
    }
}
