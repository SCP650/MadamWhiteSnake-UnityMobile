using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachLianHua : MonoBehaviour
{
    [SerializeField] AttachToLadyWhite LianHua;
    [SerializeField] Text hintText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LianHua.startMoving();
            StartCoroutine(blockEnemy());
            StartCoroutine(ShowHintText());
        }
    }
    IEnumerator ShowHintText()
    {
        yield return new WaitForSeconds(1);
        hintText.text = "点击左边加速，点击右边跳跃，赢下龙舟大赛！";
        hintText.gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        hintText.gameObject.SetActive(false);

    }

    IEnumerator blockEnemy()
    {
        yield return new WaitForSeconds(2);
        transform.GetComponent<Collider2D>().isTrigger = false;
    }
}
