using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyController : MonoBehaviour
{
    [SerializeField] float baseSpeed = 5f;
    [SerializeField] int damageToPlayer = 10;

    private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        baseSpeed += 1f * Time.deltaTime;
        transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
       
    }

   IEnumerator Jump()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    }

}
