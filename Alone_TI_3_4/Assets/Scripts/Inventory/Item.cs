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

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}