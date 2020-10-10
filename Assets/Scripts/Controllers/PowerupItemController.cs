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
            int i  = (int) Random.Range(1, 3);
            StartCoroutine(GetRandomPowerup(i,collision.gameObject));
           
        }
    }

    private IEnumerator GetRandomPowerup(int i, GameObject player)
    {
        switch (i)
        {
            case 1:
                //give health 
                //Debug.Log("health");
                Messenger.Broadcast(PowerupEvent.HEALTH_INCREASE);
                Managers.Player.ChangeHealth(20);
                break;
            case 2:
                //add speed 

                player.GetComponent<PlayerViewHoriMove>().speed *= 1.5f;
                yield return new WaitForSeconds(5);
                player.GetComponent<PlayerViewHoriMove>().speed *= 1/1.5f;
                break;
            default:
                Debug.Log("Empty Power up");
                break;
        }

    }

}
