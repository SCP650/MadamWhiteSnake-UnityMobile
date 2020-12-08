using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxEnemyController : MonoBehaviour
{
   

    [SerializeField] int damageToPlayer = 10;
    [SerializeField] private AudioClip attackSound;
    [Tooltip("玩家的叫声")]
    [SerializeField] private AudioClip playJiao; 

    private Transform target;
    private Collider2D collider;
    private Rigidbody2D rb;
    private Animator _animator;
    private bool isRunning;
    private float baseSpeed = 2f;
    private float oldSpeed;
    private Vector2 RaycastBoxSize;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        baseSpeed = target.gameObject.GetComponent<PlayerViewHoriMove>().speed+1;
        int LuckNumBase = Random.Range(1, 10);
        float RandomIndexBase = Random.Range(-3f, 5f);
        //baseSpeed += 1f * Time.deltaTime;
        oldSpeed = baseSpeed;

        RaycastBoxSize = new Vector2(3f, 3f);
        StartCoroutine(Attack());
        isRunning = true;
       
        
    }

    public void ChangeBaseSpeed(float percent)
    {
        baseSpeed *= percent; 
    }

    // Update is called once per frame
    void Update()
    {
      

      
        if (isRunning)
        {

            //transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.position, baseSpeed * Time.deltaTime);
            var hit = Physics2D.BoxCast(transform.position, RaycastBoxSize, 0, Vector2.right,3);
            if (hit)
            {

                if (hit.transform.tag == "Ground")
                {
                    rb.velocity = new Vector2(rb.velocity.x, 10);
                }
            }

                if (transform.eulerAngles.z > 45 || transform.eulerAngles.z < -45)
                {

                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.time * 5);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            

        }
        if (transform.position.y < -168)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator Attack()
    {

        while (true)
        {
            float seconds = Random.Range(3.0f, 4.0f);
         
            _animator.SetTrigger("Attack");
            baseSpeed *= 2;
            // rb.AddForce(transform.up * 100);
            yield return new WaitForSeconds(1f);
            Managers.Audio.PlaySound(attackSound);
            baseSpeed = oldSpeed;
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
            Managers.Player.ChangeScore(-50);
            Managers.Audio.PlaySound(playJiao);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "PlayerHitBox")
    //        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    //}

   

    private IEnumerator SlowDown()
    {
        isRunning = false;
        rb.velocity = new Vector2( -baseSpeed/2, rb.velocity.y);
        yield return new WaitForSeconds(1.5f);
        isRunning = true;
    }

}
