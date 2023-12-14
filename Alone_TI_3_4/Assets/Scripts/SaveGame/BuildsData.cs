using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildsData 
{
    /*public List<GameObjectData> placedObjectsData;

    public BuildsData(List<GameObject> placedObjects){
        placedObjectsData = new List<GameObjectData>();

        foreach (GameObject obj in placedObjects)
        {
            // Crie uma instância de GameObjectData para cada objeto e adicione à lista
            placedObjectsData.Add(new GameObjectData(obj));
        }
    }*/
    public string[] gameObjectName;
    public Vector3[] pos;
    public Quaternion[] rot;
    public BuildsData(List<GameObject> obj)
    {
        int i = 0;
        // Extraia os dados relevantes do GameObject e armazene nos campos
        foreach(GameObject e in obj){
            gameObjectName[i] = e.name;
            pos[i] = e.transform.position;
            rot[i] = e.transform.rotation;
            i++;
        }
        
        // Adicione mais campos conforme necessário
    }
}
