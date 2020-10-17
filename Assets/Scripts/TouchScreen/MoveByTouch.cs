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
 
    private float width;
    private float MidWidth;
    private float MidHeight;
    private CollectPoints dantianController;

    private float StartPosY;
    private int count = 0;

    private float StartTime;
    private float acumTime = 0;
    private float holdTime = 0.5f;
    private float OldGravity;
    private PlayerViewHoriMove horiSpeed;
    private float oldSpeed;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        width = Screen.width;
        MidWidth = width / 2;
        MidHeight = Screen.height / 2;
        _animator = GetComponent<Animator>();
        dantianController = GetComponent<CollectPoints>();
        shield.SetActive(false);
        OldGravity = rb.gravityScale;
        horiSpeed = gameObject.GetComponent<PlayerViewHoriMove>();
        oldSpeed = horiSpeed.speed;
        //StartPosY =  0.1947699f;
    }

    bool IsGrounded() 
    {
        Vector2 position = transform.position;
        Vector2 positionLeft = new Vector2(transform.position.x+0.9f,transform.position.y);
        Vector2 positionRight = new Vector2(transform.position.x - 0.9f, transform.position.y);
        Vector2 direction = Vector2.down;
        float distance = 1.9f;


        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance);
      
        if (hit && hit.collider.tag == "Ground")
        {
            return true;
        }
        else
        {
            hit = Physics2D.Raycast(positionLeft, direction, distance);
            if (hit && hit.collider.tag == "Ground")
            {
                return true;
            }
            else
            {
                hit = Physics2D.Raycast(positionRight, direction, distance);
                if(hit) return hit.collider.tag == "Ground";
            }
        }
        return false;

 
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {

            acumTime += Input.GetTouch(0).deltaTime;
            Debug.Log(acumTime);
            if (acumTime >= holdTime)
            {

                StartFly();
            }


            if (Input.GetTouch(0).phase == TouchPhase.Ended || IsGrounded())
            {
                acumTime = 0;
                EndFly();
            }
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            StartTime = Time.time;


            if (touchPos.x < MidWidth && CheckID())
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
            else if (touchPos.x > MidWidth)
            {
                Jump();



            }

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
        else if (Input.GetKeyDown("w")) // For editor testing
        {
            Jump();
        }
        else if (Input.GetKey("w"))
        {
            StartFly();
        }
        else if (Input.GetKeyUp("w") || IsGrounded())
        {
            EndFly();
        }


        
    }


  

    private void StartFly()
    {
        if (dantianController.canUseDanTian())
        {
            dantianController.canUseDanTian();
            horiSpeed.speed += 3f * Time.deltaTime;
            horiSpeed.speed = Mathf.Clamp(horiSpeed.speed, oldSpeed, oldSpeed * 2);
            rb.gravityScale = 0.5f;
            dantianController.FlyingCost();
        }
        else
        {
            StartCoroutine(ShowWarning("丹田不足，无法滑翔"));
            EndFly();
        }

      
    }

    private void EndFly()
    {
        horiSpeed.speed = oldSpeed;
        rb.gravityScale = OldGravity;
    }

    private void Jump()
    {
      
        if (IsGrounded())
        {
            count = 1;

            SingleJump();
        } else if (count == 1) // not on ground
        {
            Debug.Log("Second Jump");
            count++;
            SingleJump();

        }
        if ( count >= 2)
        {
            count = 0;
        }
    }

    private void SingleJump()
    {

        
        //Debug.Log("start time is " + StartTime + "  cur time is " + CurTime);
       _animator.SetBool("Jumping", true);

        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        //Vector3 curr = transform.position;
        //jumpTarget = new Vector3(curr.x, curr.y + jumpHeight, curr.z);
        Managers.Audio.PlaySound(jumpSound);
        //shouldJump = true;
    }

    private bool CheckID()
    {

        return !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
          
        
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        // allow jumping again whe nhit ground 
        if (col.gameObject.tag == "Ground")
        {
       
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
       
    }

    private IEnumerator ShowWarning(string text)
    {
        warningText.text = text;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        warningText.gameObject.SetActive(false);

    }
}
