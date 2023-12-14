using UnityEngine;
[System.Serializable]
public class GameObjectData 
{
    public string gameObjectName;
    public Vector3 pos;
    public Quaternion rot;
    public GameObjectData(GameObject obj)
    {
        // Extraia os dados relevantes do GameObject e armazene nos campos
        gameObjectName = obj.name;
        pos = obj.transform.position;
        rot = obj.transform.rotation;
        // Adicione mais campos conforme necessário
    }
}
