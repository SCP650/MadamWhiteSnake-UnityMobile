using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagezone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Managers.Player.ChangeHealth(-10);
        }

        //PlayerManager damage = other.GetComponent<PlayerManager>();
            //if(damage!= null)
            //{
            //    damage.ChangeHealth(-1);
            //}
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }



}
