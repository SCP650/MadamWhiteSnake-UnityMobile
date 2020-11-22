using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishmove : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D dragon)
    {
        if (dragon.tag == "Player")
        {
            Messenger.Broadcast("fishmoving");
        }
    }
}
