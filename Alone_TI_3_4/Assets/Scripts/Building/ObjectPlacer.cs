using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameObjects = new();

    public int PlaceObject(Item item, Vector3 position)
    {
        GameObject newObject = Instantiate(item.PrefabItem);
        newObject.transform.position = position;
        placedGameObjects.Add(newObject);
        Inventory.instance.RemoveItem(item);
        PlacementSystem.instance.StopPlacement();
        return placedGameObjects.Count - 1;
    }

    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameObjects.Count <= gameObjectIndex
            || placedGameObjects[gameObjectIndex] == null)
            return;
        Destroy(placedGameObjects[gameObjectIndex]);
        placedGameObjects[gameObjectIndex] = null;
    }
}