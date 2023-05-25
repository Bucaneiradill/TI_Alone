/**************************************************************
    Jogos Digitais SG
    InventoryUI

    Descrição:  Atualiza a UI para que o jogador perceba a mudança.

    Alone - Jogos Digitais SG –  09/04/2022
    Modificado por: Italo 
***************************************************************/

//-------------------------- Bibliotecas Usadas --------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform itemsParent;
    [SerializeField] GameObject inventoryUI;
    InventorySlot[] slots;

    /*------------------------------------------------------------------------------
    Função:     Start
    Descrição:  
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    void Start(){
        Inventory.instance.onItemChangeCallBack += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //Pega todos os slots que são filhos do InventorySlot.
    }
    /*------------------------------------------------------------------------------
    Função:     Update
    Descrição:  Abre e fecha o inventario.
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    void Update(){
        if(Input.GetButtonDown("Inventory")){
            inventoryUI.SetActive(!inventoryUI.activeSelf); //Inverte o estado atual do GameObject e inverte quando a tecla é apertada novamente.
        }
    }
    /*------------------------------------------------------------------------------
    Função:     UpdateUI
    Descrição:  Verifica e atualiza caso um item novo seja adicionado no inventário.
    Entrada:    
    Saída:      
    ------------------------------------------------------------------------------*/
    void UpdateUI(){
        for(int i = 0; i < slots.Length;  i++){ //Loop para passando por todos os slots do inventário.
            if(i < Inventory.instance.items.Count){ //Confere se o quantos items tem no inventário.
                slots[i].AddItemSlot(Inventory.instance.items[i]); //Adiciona o item respectivo ao slot dele.
            }else{
                slots[i].ClearSlot(); //Limpa todos os slots que não possuem items.
            }
        }
    }
}

