using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachLianHua : MonoBehaviour
{
    [SerializeField] AttachToLadyWhite LianHua;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LianHua.startMoving();
        }
    }
}
