using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFaHaiWater : MonoBehaviour
{

    private SpriteRenderer _spriteRender;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Awake()
    {
        Messenger.AddListener("KillFaHai", KillFaHaiNow);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener("KillFaHai", KillFaHaiNow);
    }
    void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        _spriteRender.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }
 

    private void KillFaHaiNow()
    {
        Debug.Log("Tryign to kill fahai");
        _spriteRender.enabled = true;
        rb.velocity = new Vector3(0, -20, 0);
        StartCoroutine(FaHaiDie());

    }

    IEnumerator FaHaiDie()
    {
        yield return new WaitForSeconds(2);
        GetComponentInParent<FahaiController>().StopAllCoroutines();
        GetComponentInParent<FahaiController>().enabled = false;

    }

  
}
