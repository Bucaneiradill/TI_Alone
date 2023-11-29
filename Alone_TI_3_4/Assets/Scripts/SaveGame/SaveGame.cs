using UnityEngine;
using System.IO;

class SceneData{
   public GameManagerData gameManager;
   public TimeManagerData timeManager;
   public PlayerData playerData;
}

public class SaveGame : MonoBehaviour
{
    string path;
    void Awake(){
        path = Application.dataPath + "/save.txt";
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.S)){
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L)){
            Load();
        }
    }

    void Save(){
        SceneData data = new SceneData();

        data.gameManager = GameManager.instance.GetGameManager();
        data.timeManager = TimeManager.instance.GetTimeManagerData();
        PlayerActions player = FindObjectOfType<PlayerActions>();
        data.playerData = new PlayerAdapter(player);
       
        string s = JsonUtility.ToJson(data, true);
        Debug.Log("S");
        File.WriteAllText(path, s);
    }
    void Load(){
        PlayerActions player = FindObjectOfType<PlayerActions>();
        player.target = null;

        string s =File.ReadAllText(path);
        SceneData data = JsonUtility.FromJson<SceneData>(s);
        GameManager.instance.SetGameManagerData(data.gameManager);
        TimeManager.instance.SetTimeManagerData(data.timeManager);
        player.transform.position = data.playerData.position; 
        player.transform.eulerAngles = data.playerData.rotation;
    }
}
