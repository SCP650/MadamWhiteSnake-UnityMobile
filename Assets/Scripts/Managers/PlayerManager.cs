using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int health { get; private set; }
    public int maxHealth { get; private set; }
    public int score { get; private set; }
    private NetworkService _network;

    public void Startup(NetworkService network)
    {
        Debug.Log("Player Manage is starting up...");
        _network = network;
        UpdataData(100, 100);
        status = ManagerStatus.Started;
    
        StartCoroutine(slowLoading());

    }

    //This is super uncessary
    private IEnumerator slowLoading()
    {
        yield return new WaitForSeconds(0.5f); //intentional slow the loading process to show case loading screen

        status = ManagerStatus.Started;
    }

    public void UpdataData(int health, int maxHealth)
    {
        this.health = health;
        this.maxHealth = maxHealth;
    }
    public void ChangeScore(int value)
    {
        score += value;
    
        Messenger<int>.Broadcast(GameEvent.SCORE_UPDATED,value);
        
    }
    public void ChangeHealth(int value)
    {
        health += value;

        if(health >= maxHealth)
        {
            health = maxHealth;
        }
        else if(health <= 0)
        {
            Messenger.Broadcast(GameEvent.LEVEL_FAILED);
            health = 0;

        }
        Debug.Log("Health: " + health + " / " + maxHealth);
        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    }
    public void Respawn()
    {
        UpdataData(100, 100);
        score = 0;
    }


}
