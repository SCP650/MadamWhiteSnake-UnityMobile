using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRacing : MonoBehaviour
{
    [SerializeField] GameObject LianHua;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LianHua.transform.SetParent( null);
            collision.gameObject.GetComponent<MoveByTouch>().Jump();
        }
    }
}
