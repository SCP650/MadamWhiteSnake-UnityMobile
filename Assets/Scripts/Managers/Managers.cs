using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]      //  类似打包 不用去check的拉进去
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(MissionManager))]
[RequireComponent(typeof(DataManager))]
[RequireComponent(typeof(AudioManager))]

public class Managers : MonoBehaviour
{ 

    public static PlayerManager Player { get; private set; }   //  static  属于整个class  一个模板 
    public static InventoryManager Inventory { get; private set; }
    public static MissionManager mission { get; private set; }
    public static DataManager Data { get; private set; }
    public static AudioManager Audio { get; private set; }

    private List<IGameManager> _startSequence;   //    留一个区域 变成list 

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;   // 手机画面强制变成横版   portal  右的话
        DontDestroyOnLoad(gameObject);      //   希望manager保留在所有的level里面  
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        mission = GetComponent<MissionManager>();
        Data = GetComponent<DataManager>();
        Audio = GetComponent<AudioManager>();

        _startSequence = new List<IGameManager>();   //  
        _startSequence.Add(Inventory);
        _startSequence.Add(Player);
        _startSequence.Add(mission);
        _startSequence.Add(Data);
        _startSequence.Add(Audio);
        StartCoroutine(StartupManager());
    }
    private IEnumerator StartupManager()
    {
        NetworkService network = new NetworkService();   
        foreach(IGameManager manager in _startSequence)  //   for each manager in start sequence
        {
            manager.Startup(network);  
        }
        yield return null;

        //Check if all moduels are set up
        int numModule = _startSequence.Count;   // 得到数量 
        int numReady = 0;

        while (numReady < numModule)  //  确保可以全部开启 
        {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in _startSequence)
            {
                if(manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if(numReady > lastReady)
            {
                Debug.Log("Progress : " + numReady + " / " + numModule);  //  
                Messenger<int, int>.Broadcast(StartupEvent.MANAGERS_PROGRESS, numReady, numModule);

            }
            yield return null;
        }
        Debug.Log("All moduels are set up");
        Messenger.Broadcast(StartupEvent.MANAGERS_STARTED);
    }

   
}
