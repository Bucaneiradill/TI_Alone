using UnityEngine;
using System.IO;

class SceneData{
   public GameManagerData gameManager;
   public TimeManagerData timeManager;
   public PlayerData playerData;
   public InventoryData inventoryData;
   public EnemyData[] enemyData;
   public BuildsData[] builds;
}

public class SaveGame : MonoBehaviour
{
    public static SaveGame instance;
    public GameObject[] animals;
    public GameObject[] contructions;
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
        BuildSave[] builds = FindObjectsOfType<BuildSave>();
        data.builds = new BuildsData[builds.Length];
        for(int i = 0; i < builds.Length; i++){
            data.builds[i] = new BuildsAdapter(builds[i]);
        }
        //-------------------------
        string s = JsonUtility.ToJson(data, true);
        Debug.Log("S");
        File.WriteAllText(path, s);
    }
    public void Load(){
        if(path != null){
        //find save.txt
        string s =File.ReadAllText(path);   
        SceneData data = JsonUtility.FromJson<SceneData>(s);
        //player locate        
        PlayerActions player = FindObjectOfType<PlayerActions>();
        player.agent.ResetPath();
        //player
        player.transform.position = data.playerData.position; 
        player.transform.eulerAngles = data.playerData.rotation;
        //GameManager
        GameManager.instance.SetGameManagerData(data.gameManager);
        //TimeManager
        TimeManager.instance.SetTimeManagerData(data.timeManager);
               
        //NPCs
        EnemySave[] enemies = FindObjectsOfType<EnemySave>();
        foreach(EnemySave e in enemies){
            Destroy(e.gameObject);
        }
        for(int i = 0; i <data.enemyData.Length;i++){
            if(data.enemyData[i].name == "CrocodilePrefab"){
               Instantiate(animals[1],data.enemyData[i].position,data.enemyData[i].rotation);
            }
            if(data.enemyData[i].name == "TigerPrefab"){
               Instantiate(animals[0],data.enemyData[i].position,data.enemyData[i].rotation);
            }
        }    
        //Inventory
        InventoryUI.instance.ClearInventory();
        Inventory.instance.SetInventoryData(data.inventoryData);
        //builds
        BuildSave[] builds = FindObjectsOfType<BuildSave>();
        foreach(BuildSave e in builds){
            Destroy(e.gameObject);
        }
        for(int i = 0; i < data.builds.Length;i++){
            if(data.builds[i].gameObjectName == "Campfire(Clone)"){
            Instantiate(contructions[0],data.builds[i].pos,data.builds[i].rot);
            }  //Shelter(Clone)
            if(data.builds[i].gameObjectName == "Shelter(Clone)"){
            Instantiate(contructions[1],data.builds[i].pos,data.builds[i].rot);
            }
                 
        }
        }
        
    }
}
