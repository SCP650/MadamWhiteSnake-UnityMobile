using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyController : MonoBehaviour
{
    [SerializeField] float baseSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] int damageToPlayer = 10;
    [SerializeField] private AudioClip attackSound;
    [Tooltip("玩家的叫声")]
    [SerializeField] private AudioClip playJiao; 

    private Transform target;
    private Collider2D collider;
    private Rigidbody2D rb;
    private Animator _animator;
    private bool isRunning;
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        int LuckNumBase = Random.Range(1, 10);
        float RandomIndexBase = Random.Range(-3f, 5f);
        //baseSpeed += 1f * Time.deltaTime;
        if (LuckNumBase == 5)
        {

            baseSpeed *= 1.5f;
        }
        else
        {
            baseSpeed += RandomIndexBase;
        }

       
        StartCoroutine(Jump());
        isRunning = true;
       
        
    }

    public void ChangeBaseSpeed(float percent)
    {
        baseSpeed *= percent; 
    }

    // Update is called once per frame
    void Update()
    {
       baseSpeed += 1f * Time.deltaTime;
        baseSpeed= Mathf.Clamp(baseSpeed, 5, 16);
        //transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
        if (isRunning)
        {
            //transform.position = Vector3.MoveTowards(transform.position, target.position, baseSpeed * Time.deltaTime);
            // Check the distance between enemies and Player

    
            //transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);



            transform.position = Vector3.MoveTowards(transform.position, target.position, baseSpeed * Time.deltaTime);


        }
        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator Jump()
    {

        while (true)
        {
            float seconds = Random.Range(2.0f, 4.0f);
            float speed = Random.Range(jumpSpeed, jumpSpeed + 10);
            _animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, speed);
            // rb.AddForce(transform.up * 100);
            yield return new WaitForSeconds(0.1f);
            Managers.Audio.PlaySound(attackSound);

            yield return new WaitForSeconds(seconds);

        }

   
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string whatHitMe = collision.gameObject.tag;
        if ( whatHitMe == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, collider,true);
        } else if(whatHitMe == "JumpPoint")
        {
            //Debug.Log("Jump is true");
            rb.AddForce(transform.up * 5.0f, ForceMode2D.Impulse);
            //Debug.Log("Jump is true");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string whatHitMe = collision.gameObject.tag;
        if (whatHitMe == "PlayerHitbox")
        {
       
            Managers.Player.ChangeHealth(-damageToPlayer);
            Managers.Audio.PlaySound(playJiao);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "PlayerHitBox")
    //        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    //}

    public void PushBack()
    {
        StartCoroutine(SlowDown());
    }

    private IEnumerator SlowDown()
    {
        isRunning = false;
        rb.velocity = new Vector2( -baseSpeed/2, rb.velocity.y);
        yield return new WaitForSeconds(1.5f);
        isRunning = true;
    }

}
