using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
          
            collision.gameObject.GetComponent<JumpingEnemyController>().ChangeBaseSpeed(0.1f);
        }
    }
}
