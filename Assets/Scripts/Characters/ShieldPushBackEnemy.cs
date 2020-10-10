using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPushBackEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PushEnemy(collision.gameObject);
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    PushEnemy(collision.gameObject);
    //}

    private void PushEnemy(GameObject gb)
    {
        if (gb.gameObject.tag == "Enemy")
        {
           
            gb.gameObject.GetComponent<JumpingEnemyController>().PushBack();
        }
    }
}
