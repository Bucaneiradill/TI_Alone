using UnityEngine;
using System.IO;

class SceneData{
   public GameManagerData gameManager;
   public TimeManagerData timeManager;
   public PlayerData playerData;
   public InventoryData inventoryData;
   //public HotBarData[] hotBarData;
   public EnemyData[] enemyData;
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
    public void OnButtonEnter(){
        
    }

    void Save(){
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
        //data.inventoryData = EquipmentUI.instance.GetHotBar();
        //-------------------------
        string s = JsonUtility.ToJson(data, true);
        Debug.Log("S");
        File.WriteAllText(path, s);
    }
    void Load(){
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
        for(int i = 0; i < data.enemyData.Length; i++){
            enemies[i].transform.position = data.enemyData[i].position;
            enemies[i].transform.eulerAngles = data.enemyData[i].position;
        }
        //Inventory
        InventoryUI.instance.ClearInventory();
        Inventory.instance.SetInventoryData(data.inventoryData);
        //EquipmentUI.instance.SetHotBar(data.hotBarData);
    }
}
