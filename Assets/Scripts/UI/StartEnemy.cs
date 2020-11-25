using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnemy : MonoBehaviour
{
    [SerializeField] GameObject EnemySpawer;
    [SerializeField] string Level1MidMusic;
    private AudioClip audio;

    private void Start()
    {
        audio = Resources.Load(Level1MidMusic) as AudioClip;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EnemySpawer.SetActive(true);
            Managers.Audio.PlayBGM(audio);
            //Managers.Audio.PlayLevelMusic(1);
        }
    }
}
