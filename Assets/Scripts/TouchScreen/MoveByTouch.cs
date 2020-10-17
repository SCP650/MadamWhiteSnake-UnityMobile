using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveByTouch : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    // Jump
    //public float jumpSpeed;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] private GameObject shield;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip shieldSound;
    [SerializeField] Text warningText;
    //[SerializeField] float jumpHeight = 10f;
  
    private Animator _animator;
    private Vector3 jumpTarget;

   
    private Rigidbody2D rb;

    private bool shouldJump;
    private bool canJump;
 
    // Start is called before the first frame update
    

    // Screen Split
    private float width;
    private float MidWidth;
    private float MidHeight;
    private CollectPoints dantianController;

    public LayerMask groundLayer;

    private float StartPosY;
    private int count = 0;

    private float StartTime;
    private float CurTime;
   

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        width = Screen.width;
        MidWidth = width / 2;
        MidHeight = Screen.height / 2;
        _animator = GetComponent<Animator>();
        dantianController = GetComponent<CollectPoints>();
        shield.SetActive(false);
        //StartPosY =  0.1947699f;
    }

    bool IsGrounded() 
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 5.0f;
        
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        // if(hit)
        // {
        //     Debug.Log("HIT");
        // }
        // else
        // {
        //     Debug.Log("Not on ground");
        // }
		// //RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        

        //RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit) {
            //Debug.Log("Touched object " + hit.transform.gameObject.name + " layer is " + hit.transform.gameObject.layer);
            return true;
        }
        else
        {
            //Debug.Log("Nottt  on Ground ");
        }
        
        return false;
    }
    void Update()
    {

        
        
        if(!IsGrounded())
        {
            //Debug.Log("Not on ground");
        }
        else{
            //Debug.Log("On ground");
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            StartTime = Time.time;
            

            if(touchPos.x < MidWidth)
            {
                //jump
                if (dantianController.canUseDanTian())
                {
                    StartCoroutine(Shield());
                    dantianController.dantianUsed();
                }
                else
                {
                    StartCoroutine(ShowWarning("丹田不足，无法开伞"));
                }


            }
            else if(touchPos.x > MidWidth)
            {
                //attack
                // int yMovement = (int) Input.GetAxisRaw("Vertical");
                // if (yMovement == 1) {
                    // Jump();
                // }
                // if (canJump)
                // {
                //     Jump();
                // }
                
                
                //float CurY = rb.position.y;

                // Debug.Log("In");
                // Debug.Log("Pos now " + rb.position.y + " start pos " + StartPosY);
                
                // if(touch.phase == TouchPhase.Began)
                // {
                //     StartTime = Time.time;                    
                // }
                


                // Debug.Log("start time is " + StartTime + "  cur time is " + CurTime);

                if(touch.position.y < MidHeight)
                {
                    if(IsGrounded() && count < 2)// do first jump
                    {
                        count++;
                        
                        Jump();
                        
                    }
                    else if(count < 2) // not on ground
                    {
                        Debug.Log("Second Jump");
                        count++;
                        // Debug.Log("Pppppos now " + rb.position.y);
                        Jump();
                        // Debug.Log("Pos now " + rb.position.y);
                        
                    }
                     if(IsGrounded() && count >= 2)
                    {
                        //Debug.Log("INNNNN");
                        // Debug.Log("Pos now " + rb.position.y);
                        count = 0;
                        //Jump();
                    }
                }
                else
                {
                    //Debug.Log("time to fly");
                    // fly
                    fly();

                }

        

               
                
                
        
               

            } 
            
        }
        else if(canJump && Input.GetAxis("Vertical") > 0.0f) // For editor testing
        {
            Jump();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            //jump
            if (dantianController.canUseDanTian())
            {
                StartCoroutine(Shield());
                dantianController.dantianUsed();
            }
            else
            {
                StartCoroutine(ShowWarning("丹田不足，无法开伞"));
            }

        }
        
    }

    private void checktime()
    {
        CurTime = Time.time;
    }

    private void fly()
    {
        Debug.Log("fly");
        
        rb.velocity = new Vector2(rb.velocity.x * 2.5f, jumpSpeed * 2.0f);
        rb.gravityScale = (float)(0.5);
        int count  = 0;
        while(count < 15)
        {
            rb.gravityScale += (float)(0.1);
            count++;
        }
        rb.gravityScale = 2.0f;
        
        
        // rb.gravityScale = 2.0f;
        
    }

    private void Jump()
    {
        //checktime();
        
        //Debug.Log("start time is " + StartTime + "  cur time is " + CurTime);
       _animator.SetBool("Jumping", true);

        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        //Vector3 curr = transform.position;
        //jumpTarget = new Vector3(curr.x, curr.y + jumpHeight, curr.z);
        canJump = false;
        Managers.Audio.PlaySound(jumpSound);
        //shouldJump = true;
    }

    private void CheckID()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if finger is over a UI element
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Touched the UI");
            }
        }
    }

    //private void FixedUpdate()
    //{

    //    // jump
    //    if (shouldJump)
    //    {
    //        //Call juming animation 
    //        Vector3 delta = jumpTarget - transform.position;
    //        transform.position += delta * 0.1f;
    //        //Debug.Log(delta.y);
    //        //rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    //        shouldJump &= delta.y > 3f;


    //    }
    //}


    private void OnCollisionEnter2D(Collision2D col)
    {
        // allow jumping again whe nhit ground 
        if (col.gameObject.tag == "Ground")
        {
            canJump = true;
            _animator.SetBool("Jumping", false);
        }


    }

    private IEnumerator Shield()
    {
        _animator.SetTrigger("Attacking");
        Managers.Audio.PlaySound(shieldSound);
        shield.SetActive(true);
        yield return new WaitForSeconds(1f);
        shield.SetActive(false);
       
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private IEnumerator ShowWarning(string text)
    {
        warningText.text = text;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        warningText.gameObject.SetActive(false);

    }
}
