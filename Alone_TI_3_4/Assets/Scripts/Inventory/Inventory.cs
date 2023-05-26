/**************************************************************
    Jogos Digitais SG
    Inventory

    Descrição:  Gerencia quais itens foram adicionados ao inventário e quanto espaço resta no mesmo.

    Alone - Jogos Digitais SG –  09/04/2022
    Modificado por: Italo 
***************************************************************/

//-------------------------- Bibliotecas Usadas --------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int inventorySpace = 2;
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallBack;
    //public InventorySlot IventorySlots;

    /*------------------------------------------------------------------------------
    Função:     Awake
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        inventorySpace = InventoryUI.instance.itemsParent.childCount;
    }
    /*------------------------------------------------------------------------------
    Função:     AddItem
    Descrição:  Adiciona o item ao inventario.
    Entrada:    Item - Qual item está sendo adicionado ao inventario. 
    Saída:      Bool - Retorna se o inventario está cheio ou não.
    ------------------------------------------------------------------------------*/
    public void AddItem(Item item)
    {
        CheckAndAddItem(item);
    }
    public bool CheckAndAddItem(Item item){
        if(!item.isDefaultItem){
           // if(CoinstainItem){
               // if(InventorySlots.RoomLeftInStack(amountToAdd)){
                    //InventorySlots.AddStackSlot(amountToAdd);
                    //return true;
               // }
          //  }
            if(items.Count >= inventorySpace){
                Debug.Log("Inventario Cheio");
                return false;
            }
            items.Add(item);
            if(onItemChangeCallBack != null) onItemChangeCallBack.Invoke(); //não sei pra que quer serve preciso ver com rock
        }
        return true;
    }
    /*------------------------------------------------------------------------------
    Função:     RemoveItem
    Descrição:  Remove o item do inventario
    Entrada:    Item - Qual item está sendo removido do inventario 
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void RemoveItem(Item item){
        items.Remove(item);
        if(onItemChangeCallBack != null) onItemChangeCallBack.Invoke(); //não sei pra que quer serve preciso ver com rock
    }

    public bool SearchItem(Item item)
    {
        return items.Contains(item);
    }
}
