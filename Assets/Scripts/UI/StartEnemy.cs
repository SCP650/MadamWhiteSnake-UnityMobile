using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnemy : MonoBehaviour
{
    [SerializeField] GameObject EnemySpawer;
    [SerializeField] private string level1BGMLocation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EnemySpawer.SetActive(true);
            Managers.Audio.PlayBGM(Resources.Load(level1BGMLocation) as AudioClip);
        }
    }
}
