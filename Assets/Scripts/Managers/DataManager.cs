using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager : MonoBehaviour, IGameManager
{   
    public ManagerStatus status { get; private set; }
    private string _filename;
    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Data Manager Starting...");
        _network = service;
        _filename = Path.Combine(Application.persistentDataPath,"game.dat");  //  储存玩家数据，文件夹名字是gamedat，位置是中间的
        //full file path is constructed using Application.persistent- DataPath,
        // a location Unity provides to store data in.exact location differs in different platform
        status = ManagerStatus.Started;
    }

    public void SaveGameState()
    {
        Dictionary<string, object> gamestate = new Dictionary<string, object>();  //  object 可以是很多  
        gamestate.Add("inventory", Managers.Inventory.GetData());  
        gamestate.Add("maxHealth", Managers.Player.health);
        gamestate.Add("curLevel", Managers.mission.curLevel);
        gamestate.Add("maxLevel", Managers.mission.maxLevel);

        FileStream stream = File.Create(_filename);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, gamestate);
        stream.Close();
    }

    public void LoadGameState()
    {
        if (!File.Exists(_filename))
        {
            Debug.Log("No Saved Game");
            return;
        }

        Dictionary<string, object> gamestate;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(_filename,FileMode.Open);
        gamestate = formatter.Deserialize(stream) as Dictionary<string, object>;
        stream.Close();

        Managers.Inventory.UpdateData((Dictionary<string, int>)gamestate["inventory"]);
        Managers.Player.UpdataData((int)gamestate["health"], (int)gamestate["maxHealth"]);
        Managers.mission.UpdateData((int)gamestate["curLevel"], (int)gamestate["maxLevel"]);
        Managers.mission.RestartCurrent();
    }
}
