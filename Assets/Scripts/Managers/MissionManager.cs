using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int curLevel { get; private set; }
    public int maxLevel { get; private set; }

    public int curTransition { get; private set; }
    public int maxTransition { get; private set; }
    public List<bool> PlayerChoice = new List<bool>();

    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Mission manager starting..");
        _network = service;
        UpdateData(0, 3);
        this.curTransition = 0;
        this.maxTransition = 3;
        status = ManagerStatus.Started;
    }

    public void UpdateData(int curLevel, int maxLevel)
    {
        this.curLevel = curLevel;
        this.maxLevel = maxLevel;

    }

    public void GoToNextLevel()
    {
        if(curLevel < maxLevel)
        {
            Managers.Player.Respawn();
            curLevel++;
            string name = "Level" + curLevel;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
        else
        {
            Messenger.Broadcast(GameEvent.GAME_COMPLETE);
            Debug.Log("Last Level");

        }
    }

    public void GoToLevel(int i)
    {
        if (i <= maxLevel)
        {
         
            string name = "Level" + i;
            curLevel = i;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
        else
        {
            Messenger.Broadcast(GameEvent.GAME_COMPLETE);
            Debug.Log("Last Level");

        }
    }
    public void GoToTransition(int i)
    {
        if (i <= maxLevel)
        {

            string name = "Transition" + i;
            curTransition = i;
            curLevel = i-1;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
        else
        {
            Messenger.Broadcast(GameEvent.GAME_COMPLETE);
            Debug.Log("Last Level");

        }
    }

    public void GoToStartUp()
    {
        SceneManager.LoadScene("Startup");
    }

    public void GoToNextTransitionScene()
    {
        if (curTransition < maxTransition)
        {
            curTransition++;
            string name = "Transition" + curTransition;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
        else
        {
            Messenger.Broadcast(GameEvent.GAME_COMPLETE);
            Debug.Log("Last Level");

        }
    }

    public void ReachObjective()
    {
        // could have logic to handle multiple objectives
        Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
    }

    public void RestartCurrent()
    {
        string name = "Level" + curLevel;
        Debug.Log("Loading ..." + name);
        SceneManager.LoadScene(name);
    }
    public void SetLevelChoice(bool choice)
    {
        PlayerChoice.Add(choice);
//for level1: true- truthful, false-hide
//Level2: true - lover, false - 报恩
    }

    public bool GetPlayerChoice(int level)
    {
        return PlayerChoice[level-1];
    }
}
