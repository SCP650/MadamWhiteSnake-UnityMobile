using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginRolling : MonoBehaviour
{
    //[SerializeField]  Bow1
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<MoveByTouch>().StartRolling();
            Messenger.Broadcast("Maindragon");
        }
    }
}
