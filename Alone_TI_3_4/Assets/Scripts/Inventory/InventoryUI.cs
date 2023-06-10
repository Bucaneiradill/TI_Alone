using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    [SerializeField] public Transform itemsParent;
    [SerializeField] GameObject inventoryUI;
    public GameObject recipeUI;
    InventorySlot[] slots;

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

    void Start(){
        Inventory.instance.onItemChangeCallBack += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //Pega todos os slots que são filhos do InventorySlot.
    }

    void Update(){
        if(Input.GetButtonDown("Inventory")){
            inventoryUI.SetActive(!inventoryUI.activeSelf); //Inverte o estado atual do GameObject e inverte quando a tecla é apertada novamente.
        }
    }

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

