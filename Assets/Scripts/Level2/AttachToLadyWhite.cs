using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToLadyWhite : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.SetParent(collision.gameObject.transform);
            transform.localPosition = new Vector3(0, -5, 0);
        }
    }
}
