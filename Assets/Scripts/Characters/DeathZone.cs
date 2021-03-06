﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] AudioClip waterSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gb = collision.gameObject;
        if (gb.tag == "Player")
        {
            Managers.Audio.PlaySound(waterSound);
            gb.GetComponent<Animator>().SetBool("Jumping", true);
            gb.transform.position = new Vector3(gb.transform.position.x, gb.transform.position.y + 35,gb.transform.position.z);
            Managers.Player.ChangeHealth(-Managers.Player.health/3);
            Managers.Player.ChangeScore(-Managers.Player.score / 3);
        }
        else if (gb.tag == "Enemy"){
            Destroy(gb);
        }
    }
}
