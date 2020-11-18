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
            LianHua.GetComponent<AttachToLadyWhite>().DetachFromWhite();
            //LianHua.transform.position = transform.position;
            //LianHua.GetComponent<AttachToLadyWhite>().enabled = false;
            collision.gameObject.GetComponent<MoveByTouch>().EndRolling();
            //collision.gameObject.GetComponent<MoveByTouch>().Jump();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            //rb.
        }
        Messenger.Broadcast("Maindragonstop");
    }
}
