/**************************************************************
    Jogos Digitais SG
    Inventory

    Descrição:  Gerencia quais itens foram adicionados ao inventário e quanto espaço resta no mesmo.

    Alone - Jogos Digitais SG –  09/04/2022
    Modificado por: 
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
    /*------------------------------------------------------------------------------
    Função:     Start
    Descrição:  Verifica se o script do inventário existe e pega o tamanho do inventário;
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    private void Start()
    {
        if(InventoryUI.instance != null) inventorySpace = InventoryUI.instance.itemsParent.childCount;
    }
    public void AddItem(Item item)
    {
        CheckAndAddItem(item);
    }
    /*------------------------------------------------------------------------------
    Função:     CheckAndAddItem
    Descrição:  Adiciona o item ao inventario.
    Entrada:    Item - Qual item está sendo adicionado ao inventario. 
    Saída:      Bool - Retorna se o inventario está cheio ou não.
    ------------------------------------------------------------------------------*/
    public bool CheckAndAddItem(Item item){
        if(!item.isDefaultItem){
            if(items.Count >= inventorySpace){
                Debug.Log("Inventario Cheio");
                return false;
            }
            items.Add(item);
            //EquipmentUI.instance.SetItem(item);
            if(onItemChangeCallBack != null) onItemChangeCallBack.Invoke(); 
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
        if(onItemChangeCallBack != null) onItemChangeCallBack.Invoke(); 
    }
    /*------------------------------------------------------------------------------
    Função:     SearchItem
    Descrição:  Verifica se o item existe no inventário
    Entrada:    Item - Qual item está sendo procurado no inventário
    Saída:      bool - Retorna se o item existe ou não.
    ------------------------------------------------------------------------------*/
    public bool SearchItem(Item item)
    {
        return items.Contains(item);
    }
}
