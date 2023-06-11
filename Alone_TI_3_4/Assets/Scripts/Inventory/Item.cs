/**************************************************************
    Jogos Digitais SG
    Item

    Descrição:  Armazena o nome e icone do item.

    Alone - Jogos Digitais SG –  09/04/2022
    Modificado por: Italo 
***************************************************************/

//-------------------------- Bibliotecas Usadas --------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Axe,
    Food,
    Foraging
}

public abstract class Item : ScriptableObject
{
    public abstract void PerformAction(ColectableSource source);
    public ItemType itemType;
    public int iD;
    new public string name = "New Item";
    public Sprite icon = null;
    [TextArea(4, 4)]
    public string Derscription;
    public bool isDefaultItem = false;
    public bool isEquipable = false;
    public bool isConsumable = false;
    public int maxStackSize;
    public List<Item> ingredients;
}
