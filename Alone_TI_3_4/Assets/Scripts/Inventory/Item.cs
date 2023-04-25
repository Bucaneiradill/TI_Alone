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
    
    public int iD;
    new public string name = "New Item";
    public Sprite icon = null;
    [TextArea(4, 4)]
    public string Derscription;
    public bool isDefaultItem = false;
    public int maxStackSize;

}