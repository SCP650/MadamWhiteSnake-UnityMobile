using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nahan : MonoBehaviour
{
    [SerializeField] private AudioClip playJiao;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Managers.Audio.PlaySound(playJiao);
        }
    }
}
