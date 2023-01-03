using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Sirenix.OdinInspector;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public static SceneData Instance;
    public List<ObjectScene> ScenesObject;
    public List<TrapCtrl> Traps;
    public List<Door> Doors;
    public List<SentryTower> SentryTowers;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        GameManager.Instance.LoadingSceneState(this);
    }
    
    public void SaveSceneData()
    {
        var dataLevelJson = PlayerPrefs.GetString(Helper.DataLevel, string.Empty);
        var dataLevel = JsonUtility.FromJson<DataLevel>(dataLevelJson);
        
        if(!Directory.Exists(Application.dataPath + "/__game/DataJson/World "+dataLevel.Level))
        {
            Directory.CreateDirectory(Application.dataPath + "/__game/DataJson/World "+dataLevel.Level);
        }
        
        // Save data Object
        var listObject= new ListObject();
        listObject.objects = new List<ObjectFormData>();
        for (int i = 0; i < ScenesObject.Count; i++)
        {
            var data = new ObjectFormData();
            data.Save(ScenesObject[i]);
            listObject.objects.Add(data);
        }
        FileHandler.SaveToJSON<ObjectFormData>(listObject.objects,
            Application.dataPath + "/__game/DataJson/World " + dataLevel.Level + "/ObjectDatas.json");
        
        // Save data Trap
        var listTrap = new ListTrap();
        listTrap.Trap = new List<TrapFormData>();
        for (int i = 0; i < Traps.Count; i++)
        {
            var data = new TrapFormData();
            data.Save(Traps[i]);
            listTrap.Trap.Add(data);
        }
        FileHandler.SaveToJSON<TrapFormData>(listTrap.Trap,
            Application.dataPath + "/__game/DataJson/World " + dataLevel.Level + "/TrapDatas.json");
        
        //Save data Door
        var listDoor = new ListDoor();
        listDoor.Door = new List<DoorFormData>();
        for (int i = 0; i < Doors.Count; i++)
        {
            var data = new DoorFormData();
            data.Save(Doors[i]);
            listDoor.Door.Add(data);
        }
        FileHandler.SaveToJSON<DoorFormData>(listDoor.Door,
            Application.dataPath + "/__game/DataJson/World " + dataLevel.Level + "/DoorDatas.json");
        
        //Save data SentryTower
        var listSentryTower = new ListSentryTower();
        listSentryTower.SentryTower = new List<SentryTowerFormData>();
        for (int i = 0; i < SentryTowers.Count; i++)
        {
            var data = new SentryTowerFormData();
            data.Save(SentryTowers[i]);
            listSentryTower.SentryTower.Add(data);
        }
        FileHandler.SaveToJSON<SentryTowerFormData>(listSentryTower.SentryTower,
            Application.dataPath + "/__game/DataJson/World " + dataLevel.Level + "/SentryTowerDatas.json");
        
        
        
        /*//Save char data
        var listChar = new ListChar();
        listChar.chars = new List<CharFormData>();
        for(int i =0;i<charDatas.Count;i++)
        {
            var data = new CharFormData();
            data.lvHealth = charDatas[i].lvHealth;
            data.lvSpeed = charDatas[i].lvSpeed;
            data.indexDrone = charDatas[i].indexDrone;
            data.indexSkin = charDatas[i].indexSkin;
            data.indexWeapon = charDatas[i].indexWeapon;
        }
        FileHandler.SaveToJSON<CharFormData>(listChar.chars,
            Application.dataPath + "/__game/DataJson/CharDatas.json");
        
        //Save entity data
        var listentity = new ListEntity();
        listentity.Entities = new List<EntityFormData>();
        for(int i =0;i<entityDatas.Count;i++)
        {
            var data = new EntityFormData();
            data.activeSelf = entityDatas[i].gameObject.activeSelf;
            data.level = entityDatas[i].level;
            data.lockState = entityDatas[i].lockState;
            data.cost = entityDatas[i].cost;
        }
        FileHandler.SaveToJSON<EntityFormData>(listentity.Entities,
            Application.dataPath + "/__game/DataJson/"+dataLevel.Level+"/EntityDatas.json");
        

        //Save object data
        var listObject = new ListObject();
        listObject.objects = new List<ObjectFormData>();
        for (int i = 0; i < objectScenes.Count; i++)
        {
            var data = new ObjectFormData();
            data.activeSelf = objectScenes[i].gameObject.activeSelf;
            listObject.objects.Add(data);
        }
        FileHandler.SaveToJSON<ObjectFormData>(listObject.objects,
            Application.dataPath + "/__game/DataJson/" + dataLevel.Level + "/ObjectDatas.json");*/
    }

    public void LoadSceneData()
    {
        var dataLevelJson = PlayerPrefs.GetString(Helper.DataLevel, string.Empty);
        var dataLevel = JsonUtility.FromJson<DataLevel>(dataLevelJson);
        
        if(!Directory.Exists(Application.dataPath + "/__game/DataJson/World "+dataLevel.Level))
        {
            Debug.Log("0 level Load");
            return;
        }
          
        /*
        //Load Char Data
        var charFormDatas = FileHandler.ReadListFromJSON<CharFormData>
            (Application.dataPath + "/__game/DataJson/CharDatas.json");
        for(int i =0;i<charFormDatas.Count;i++)
        {
            charDatas[i].lvHealth = charFormDatas[i].lvHealth;
            charDatas[i].lvSpeed = charFormDatas[i].lvSpeed;
            charDatas[i].indexDrone = charFormDatas[i].indexDrone;
            charDatas[i].indexSkin = charFormDatas[i].indexSkin;
            charDatas[i].indexWeapon = charFormDatas[i].indexWeapon;
        }

        //Load entity data
        var entityFormDatas = FileHandler.ReadListFromJSON<EntityFormData>
            (Application.dataPath + "/__game/DataJson/"+dataLevel.Level+"/EntityDatas.json");
        for(int i =0;i<entityFormDatas.Count;i++)
        {
            entityDatas[i].gameObject.SetActive(entityFormDatas[i].activeSelf);
            entityDatas[i].level = entityFormDatas[i].level;
            entityDatas[i].lockState = entityFormDatas[i].lockState;
            entityDatas[i].cost = entityFormDatas[i].cost;
        }
        */
      
        //Load Object Data
        var objectFormDatas = FileHandler.ReadListFromJSON<ObjectFormData>
            (Application.dataPath + "/__game/DataJson/World "+dataLevel.Level+"/ObjectDatas.json");
        for(int i =0;i<objectFormDatas.Count;i++)
        {
            objectFormDatas[i].Load(ScenesObject[i]);
        }
        
        //Load Trap Data
        var trapFormDatas = FileHandler.ReadListFromJSON<TrapFormData>
            (Application.dataPath + "/__game/DataJson/World "+dataLevel.Level+"/TrapDatas.json");
        for(int i =0;i<trapFormDatas.Count;i++)
        {
            trapFormDatas[i].Load(Traps[i]);
        }
        
        
        //Load Door Data
        var doorFormDatas = FileHandler.ReadListFromJSON<DoorFormData>
            (Application.dataPath + "/__game/DataJson/World "+dataLevel.Level+"/DoorDatas.json");
        for(int i =0;i<doorFormDatas.Count;i++)
        {
            doorFormDatas[i].Load(Doors[i]);
        }
        
        //Load SentryTower Data
        var sentryTowerFormDatas = FileHandler.ReadListFromJSON<SentryTowerFormData>
            (Application.dataPath + "/__game/DataJson/World "+dataLevel.Level+"/SentryTowerDatas.json");
        for(int i =0;i<sentryTowerFormDatas.Count;i++)
        {
            sentryTowerFormDatas[i].Load(SentryTowers[i]);
        }


    }
    
#if UNITY_EDITOR
    [Button]
    public void LoadList()
    {
        IEnumerable<ObjectScene> sceneObject = FindObjectsOfType<ObjectScene>(true);
        ScenesObject = new List<ObjectScene>(sceneObject);
        
        IEnumerable<TrapCtrl>trap = FindObjectsOfType<TrapCtrl>(true);
        Traps = new List<TrapCtrl>(trap);

        IEnumerable<Door>door = FindObjectsOfType<Door>(true);
        Doors = new List<Door>(door);
        
        IEnumerable<SentryTower>sentryTower = FindObjectsOfType<SentryTower>(true);
        SentryTowers = new List<SentryTower>(sentryTower);

    }
#endif
}


