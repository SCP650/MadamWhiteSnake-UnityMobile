using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRacing : MonoBehaviour
{
    [SerializeField] GameObject LianHua;
    [SerializeField] Text hintText;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LianHua.GetComponent<AttachToLadyWhite>().DetachFromWhite();
            //LianHua.transform.position = transform.position;
            //LianHua.GetComponent<AttachToLadyWhite>().enabled = false;
            collision.gameObject.GetComponent<MoveByTouch>().EndRolling();
            //collision.gameObject.GetComponent<MoveByTouch>().Jump();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            //rb.
            StartCoroutine(showText("白娘子赢得龙舟赛！"));
        }
        else
        {
            StartCoroutine(showText("龙舟挑战失败"));
        }
        Messenger.Broadcast("Maindragonstop");
    }

    IEnumerator showText(string text)
    {
        hintText.text = text;
        hintText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        hintText.gameObject.SetActive(false);
    }
}


