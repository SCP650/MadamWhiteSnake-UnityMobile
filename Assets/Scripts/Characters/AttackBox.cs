using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
     
            collision.gameObject.GetComponent<Die>().EnemyDie();
            Managers.Player.ChangeScore(100);
        }
    }
  
}
