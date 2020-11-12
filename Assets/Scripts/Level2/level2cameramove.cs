using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2cameramove : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D dragon)
    {
        if (dragon.tag == "Player")
        {
            Debug.Log("hi");
            Messenger.Broadcast("level2move");
        }
    }
}
