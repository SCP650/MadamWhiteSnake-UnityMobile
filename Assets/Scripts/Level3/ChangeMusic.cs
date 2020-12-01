using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{ 
    [SerializeField] string Level3EndMusic;
    private AudioClip audio;

    private void Start()
    {
        audio = Resources.Load(Level3EndMusic) as AudioClip;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          
            Managers.Audio.PlayBGM(audio);
            //Managers.Audio.PlayLevelMusic(1);
        }
    }
}
