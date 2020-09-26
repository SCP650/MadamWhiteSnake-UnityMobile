using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int health { get; private set; }
    public int maxHealth { get; private set; }
    private NetworkService _network;

    public void Startup(NetworkService network)
    {
        Debug.Log("Player Manage is starting up...");
        _network = network;
        UpdataData(50, 100);   //   初始血量  和最高血量
        status = ManagerStatus.Started;

    }

    public void UpdataData(int health, int maxHealth)
    {
        this.health = health;  //  指的是自己 
        this.maxHealth = maxHealth;
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
            Messenger.Broadcast(GameEvent.LEVEL_FAILED);  // Broadcast  
            health = 0;

        }
        Debug.Log("Health: " + health + " / " + maxHealth);
        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    }
    public void Respawn()
    {
        UpdataData(50, 100);
    }


}
