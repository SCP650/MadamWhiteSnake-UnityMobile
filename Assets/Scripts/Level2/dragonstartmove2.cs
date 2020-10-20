using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonstartmove2 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D dragon)
    {
        if (dragon.tag == "Player")
        {
            Messenger.Broadcast("dragonmoving2");
        }
    }
}
