using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyController : MonoBehaviour
{
    [SerializeField] float baseSpeed = 5f;
    [SerializeField] int damageToPlayer = 10;

    private Collider2D collider;
    public Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        StartCoroutine(Jump());
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        baseSpeed += 1f * Time.deltaTime;
        transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
       
    }

   IEnumerator Jump()
    {
        Debug.Log("INNNN");
        while (true)
        {
            float seconds = Random.Range(0.0f, 2.0f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
            yield return new WaitForSeconds(seconds);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string whatHitMe = collision.gameObject.tag;
        if ( whatHitMe == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, collider,true);
        } else if(whatHitMe == "Player")
        {
            Managers.Player.ChangeHealth(-damageToPlayer);
        }
        else if(whatHitMe == "JumpPoint")
        {
            Debug.Log("Jump is true");
            rb.AddForce(transform.up * 5.0f, ForceMode2D.Impulse);
            Debug.Log("Jump is true");
        }
    }


}
