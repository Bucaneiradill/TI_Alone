using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public static ObjectPlacer instance;
    [SerializeField]
    private List<GameObject> placedGameObjects = new();

    void Awake(){
        instance = this;
    }
    public int PlaceObject(Item item, Vector3 position)
    {
        GameObject newObject = Instantiate(item.PrefabItem);
        newObject.transform.position = position;
        placedGameObjects.Add(newObject);
        Inventory.instance.RemoveItem(item);
        PlacementSystem.instance.StopPlacement();
        Debug.Log("Placed");
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
    public BuildsData GetPlacedObj(){
        BuildsData data = new BuildsData(placedGameObjects);
        return data;
    }
    public void SetPlacedObj(List<GameObject> placed){
        
        if(placedGameObjects != null){
            int i = 0;
            while(placedGameObjects != null){
                RemoveObjectAt(i);
                i++;
            }   
        }   
        for(int j = 0; j <= placed.Count;j++){
            PlaceObject(placed[j].GetComponent<Item>(),placed[j].GetComponent<Transform>().position);
        }
    }
}