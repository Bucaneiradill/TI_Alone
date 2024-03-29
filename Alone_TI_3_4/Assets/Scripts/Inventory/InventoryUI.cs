/**************************************************************
    Jogos Digitais SG
    InventoryUI

    Descrição:  Gerencia a interface e adiciona os itens no InventorySlot.

    Alone - Jogos Digitais SG –  09/04/2022
    Modificado por: 
***************************************************************/

//-------------------------- Bibliotecas Usadas --------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    [SerializeField] public Transform itemsParent;
    public GameObject recipeUI;
    InventorySlot[] slots;

    /*------------------------------------------------------------------------------
    Função:     Awake
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /*------------------------------------------------------------------------------
    Função:     Start
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    void Start(){
        Inventory.instance.onItemChangeCallBack += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //Pega todos os slots que são filhos do InventorySlot.
        UpdateUI();
    }
    /*------------------------------------------------------------------------------
    Função:     UpdateUI
    Descrição:  Atualiza a interface com base nos items da lista.
    Entrada:    -
    Saída:      -
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
    /*------------------------------------------------------------------------------
    Função:     ClearInventory
    Descrição:  Limpa e remove todos os itens do inventário
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void ClearInventory(){
        for(int i = Inventory.instance.items.Count; i >= 0;  i--){ //Loop para passando por todos os slots do inventário.
            slots[i].OnDeletItemInventory(); //Limpa todo o inventário e a lista.
        }
    } 
}

