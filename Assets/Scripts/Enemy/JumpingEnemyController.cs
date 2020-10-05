using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyController : MonoBehaviour
{
    [SerializeField] float baseSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] int damageToPlayer = 10;
    private Transform target;

    private Collider2D collider;
    private Rigidbody2D rb;
    private Animator _animator;
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        StartCoroutine(Jump());
       
        
    }

    // Update is called once per frame
    void Update()
    {
        baseSpeed += 1f * Time.deltaTime;
        baseSpeed= Mathf.Clamp(baseSpeed, 5, 15);
        //transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, target.position, baseSpeed*Time.deltaTime);

    }

   IEnumerator Jump()
    {
      
        while (true)
        {
            float seconds = Random.Range(2.0f, 7.0f);
            float speed = Random.Range(jumpSpeed - 2, jumpSpeed + 2);
            _animator.SetTrigger("jump");
            // rb.AddForce(transform.up * 100);
            yield return null;
            rb.velocity = new Vector2(rb.velocity.x,speed);
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
