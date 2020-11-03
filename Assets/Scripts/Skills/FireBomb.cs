using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject gb = collision.gameObject;
            if (gb.GetComponent<JumpingEnemyController>())
            {
                gb.GetComponent<JumpingEnemyController>().ChangeBaseSpeed(0.1f);
            }else if (gb.GetComponent<FoxEnemyController>())
            {
                gb.GetComponent<FoxEnemyController>().ChangeBaseSpeed(0.1f);
            }

        }
    }
}
