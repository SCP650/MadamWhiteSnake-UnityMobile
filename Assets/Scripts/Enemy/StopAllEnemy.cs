using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllEnemy : MonoBehaviour
{
    [SerializeField] private GameObject EnemySpawnLocation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EnemySpawnLocation.SetActive(false);
        }
    }
}
