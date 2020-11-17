using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnjiaoDamage : MonoBehaviour
{
    [SerializeField] int damageToPlayer = 10;
    void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Player")
        {
            Managers.Player.ChangeHealth(-damageToPlayer);            
        }
    }
}
