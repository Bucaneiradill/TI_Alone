/**************************************************************
    Jogos Digitais SG
    InventorySlot

    Descrição:  Gerencia as interações de adicionar e remover itens do inventário

    Alone - Jogos Digitais SG –  09/04/2022
    Modificado por: Italo 
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
    [SerializeField] int stackSize;
    Item item;

    /*------------------------------------------------------------------------------
    Função:     AddItemSlot
    Descrição:  Adiciona o item a um slot vazio e ordenado.
    Entrada:    Item - Qual item foi pego pelo usuário.
    Saída:      
    ------------------------------------------------------------------------------*/
    public void AddItemSlot(Item newItem){
        item = newItem;
        icon.sprite = item.icon; // Pega a imagem do item e armazena na variavel sprite do slot para que seja visivel qual item foi adicionado
        icon.enabled = true; 
        removeButton.interactable = true; //Ativa a intereção com o botão de remover o item
    }
    /*------------------------------------------------------------------------------
    Função:     ClearSlot
    Descrição:  Limpa o slot. 
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    public void ClearSlot(){ 
        item = null;
       // stackSize = -1;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    /*------------------------------------------------------------------------------
    Função:     OnRemoveButton
    Descrição:  Remove o item quando o usuário clica no botão "x".
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    public void OnRemoveButton(){
        stackSize -= 1;
        if(stackSize <= 0){
            Inventory.instance.RemoveItem(item);
        }
    }
    /*------------------------------------------------------------------------------
    Função:     RoomLeftInStack
    Descrição: 
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    public bool RoomLeftInStack(int AmountToAdd, out int AmountRemaining){
        AmountRemaining = item.maxStackSize - stackSize;
        return RoomLeftInStack (AmountToAdd);
    }
    /*------------------------------------------------------------------------------
    Função:     RoomLeftInStack
    Descrição:  
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    public bool RoomLeftInStack(int AmountToAdd){
        if(stackSize + AmountToAdd <= item.maxStackSize) return true;
        else return false;
    }
    /*------------------------------------------------------------------------------
    Função:     AddStackSlot
    Descrição:  
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    public void AddStackSlot(int stackAdd){
        stackSize -= stackAdd;
    }
    /*------------------------------------------------------------------------------
    Função:     RemoveStackSlot
    Descrição:  
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    public void RemoveStackSlot(int stackRemove){
        stackSize -= stackRemove;
    }

    public void UseItem()
    {
        if(item.iD == 1)
        {
            GameManager.instance.toDrink(10);
            GameManager.instance.toEat(10);
            OnRemoveButton();
        }
    }
}
