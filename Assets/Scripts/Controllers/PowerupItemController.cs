using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItemController : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("pick up power up");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //TODO: Play rolling animation 
            Messenger.Broadcast(PowerupEvent.PICKUP_POWERUP);
            Managers.Player.ChangeScore(30);
           
        }
    }



}
