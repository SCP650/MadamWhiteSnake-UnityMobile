using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyController : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] float baseSpeed = 5f;
=======
    [SerializeField] float baseSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    float RaceSpeed = 5f;
>>>>>>> Stashed changes
    [SerializeField] int damageToPlayer = 10;

    private Collider2D collider;
<<<<<<< Updated upstream
    public Rigidbody2D rb;
    
=======
    private Rigidbody2D rb;
    private Animator _animator;
>>>>>>> Stashed changes

    private AudioSource musicSource;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        StartCoroutine(Jump());
<<<<<<< Updated upstream
        rb = GetComponent<Rigidbody2D>();
        
=======
       
        musicSource = GetComponent<AudioSource>();
>>>>>>> Stashed changes
    }

    

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        baseSpeed += 1f * Time.deltaTime;
        transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
       
=======
        // Check the distance between enemies and Player

        int LuckNumBase = Random.Range(1, 100000);
        float RandomIndexBase = Random.Range(5f, 12f); 
        float PlayerPos = GameObject.Find("PlayerCharacter").transform.position.x;
        float EnemyPos = GameObject.Find("EnemySpawnLocation").transform.position.x;
        Debug.Log("Enemy is at " + EnemyPos);
        Debug.Log("Player is at " + PlayerPos);
        //baseSpeed += 1f * Time.deltaTime;
        if(LuckNumBase == 12)
        {
            Debug.Log("Lucky Bro");
            baseSpeed += 1f * Time.deltaTime * 5f;
        }
        else
        {
            baseSpeed += 1f * Time.deltaTime + RandomIndexBase;
        }

        baseSpeed= Mathf.Clamp(baseSpeed, 5, 15);
        //transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
        
        if(PlayerPos - EnemyPos > 31f & LuckNumBase > 88888)
        {
            // make it faster
            Debug.Log("Faster");
            baseSpeed += 8.0f;
        }
        
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, baseSpeed*Time.deltaTime);
        
            
        
        
>>>>>>> Stashed changes
    }

    IEnumerator Jump()
    {
<<<<<<< Updated upstream
        Debug.Log("INNNN");
        while (true)
        {
            float seconds = Random.Range(0.0f, 2.0f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
            yield return new WaitForSeconds(seconds);

=======
        int LuckNumJump = Random.Range(1, 1000);
        float wait = Random.Range(3f, 8f);
        float Force = Random.Range(2f, 4f);
        bool START = true;
        while (START)
        {
            wait = Random.Range(3f, 8f);
            float seconds = Random.Range(2.0f, 7.0f);
            float speed = Random.Range(jumpSpeed - 2, jumpSpeed + 5);
            
            
            
            _animator.SetTrigger("jump");
            // rb.AddForce(transform.up * 100);
            yield return null;
            if(LuckNumJump > 888)
            {
                speed += 5.0f;
            }
            rb.velocity = new Vector2(rb.velocity.x*Force,speed);
            yield return new WaitForSeconds(wait);
>>>>>>> Stashed changes
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
        else if(whatHitMe == "Bullet")
        {
            Debug.Log("Make a sound");
            musicSource.Play();
        }
    }


}
