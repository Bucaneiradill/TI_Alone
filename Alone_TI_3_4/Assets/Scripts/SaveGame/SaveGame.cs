using UnityEngine;
using System.IO;
using System.Text.Json;
using Palmmedia.ReportGenerator.Core.Common;

class SceneData{
   public GameManagerData gameManager;
   public TimeManagerData timeManager;
   public PlayerData playerData;
   public InventoryData inventoryData;
   public EnemyData[] enemyData;
   //public BuildsData builds;
}

public class SaveGame : MonoBehaviour
{
    public static SaveGame instance;
    public GameObject[] animals;

    string path;
    void Awake(){
        path = Application.dataPath + "/save.txt";
         if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.S)){
            Save();
        }
        
    }
    

    public void Save(){
        SceneData data = new SceneData();
        //NPCs
        EnemySave[] enemies = FindObjectsOfType<EnemySave>();
        data.enemyData = new EnemyData[enemies.Length];
        for(int i=0; i< enemies.Length; i++){
            data.enemyData[i] = new EnemyAdapter(enemies[i]);
        }
        //GameManager
        data.gameManager = GameManager.instance.GetGameManager();
        //TimeManger
        data.timeManager = TimeManager.instance.GetTimeManagerData();
        //Player
        PlayerActions player = FindObjectOfType<PlayerActions>();
        data.playerData = new PlayerAdapter(player);
        //Inventory
        data.inventoryData = Inventory.instance.GetInventoryData();
        //builds
        //data.builds = ObjectPlacer.instance.GetPlacedObj();
        //Debug.Log(data.builds.ToString());
        //-------------------------
        string s = JsonUtility.ToJson(data, true);
        Debug.Log("S");
        File.WriteAllText(path, s);
    }
    public void Load(){
        //player locate        
        PlayerActions player = FindObjectOfType<PlayerActions>();
        player.agent.ResetPath();
        string s =File.ReadAllText(path);
        SceneData data = JsonUtility.FromJson<SceneData>(s);
        //GameManager
        GameManager.instance.SetGameManagerData(data.gameManager);
        //TimeManager
        TimeManager.instance.SetTimeManagerData(data.timeManager);
        //player
        player.transform.position = data.playerData.position; 
        player.transform.eulerAngles = data.playerData.rotation;        
        //NPCs
        EnemySave[] enemies = FindObjectsOfType<EnemySave>();
        foreach(EnemySave e in enemies){
            Destroy(e.gameObject);
        }
        Instantiate(animals[1],data.enemyData[1].position,data.enemyData[1].rotation);
        Instantiate(animals[0],data.enemyData[0].position,data.enemyData[0].rotation);
        //Inventory
        InventoryUI.instance.ClearInventory();
        Inventory.instance.SetInventoryData(data.inventoryData);
        //builds
        //foreach(BuildsData build in data.builds){
        //GameObject objPrefab = Resources.Load<GameObject>(build.name);
    }

    
}
