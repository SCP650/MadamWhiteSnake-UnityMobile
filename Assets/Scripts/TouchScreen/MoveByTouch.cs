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
    [SerializeField] private bool IsShield = true;
    [SerializeField] private GameObject AttackArea;
    [SerializeField] private float PlayGravity = 0.5f;
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
    private float OldGravity;
    private PlayerViewHoriMove horiSpeed;
    private float oldSpeed;
    private bool canJump;
    private float previousAttackTime = 0;
    private float followUpThresholh = 1f;
    private int AttackCounter = 0;

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

        //StartPosY =  0.1947699f;
    }

    bool IsGrounded() 
    {
        return canJump;
        //Vector2 position = transform.position;
        //Vector2 positionLeft = new Vector2(transform.position.x+0.9f,transform.position.y);
        //Vector2 positionRight = new Vector2(transform.position.x - 0.9f, transform.position.y);
        //Vector2 direction = Vector2.down;
        //float distance = 1.9f;


        //RaycastHit2D hit = Physics2D.Raycast(position, direction, distance);
      
        //if (hit && hit.collider.tag == "Ground")
        //{
        //    return true;
        //}
        //else
        //{
        //    hit = Physics2D.Raycast(positionLeft, direction, distance);
        //    if (hit && hit.collider.tag == "Ground")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        hit = Physics2D.Raycast(positionRight, direction, distance);
        //        if(hit) return hit.collider.tag == "Ground";
        //    }
        //}
        //return false;

 
    } 
  

    public void StartFly()
    {
  
        _animator.SetBool("IsFlying", true);
        if (IsGrounded())
        {
            EndFly();
        }else if (dantianController.canUseDanTian())
        {
           
            horiSpeed.IncreaseFlyingSpeed();
            rb.gravityScale = PlayGravity;
            dantianController.FlyingCost();
        }
        else
        {
            StartCoroutine(ShowWarning("丹田不足，无法滑翔"));
            EndFly();
        }

      
    }

    public void EndFly()
    {
        horiSpeed.ResetSpeed();
        _animator.SetBool("IsFlying",false);
        rb.gravityScale = OldGravity;
    }

    public void Jump()
    {
      
        if (IsGrounded())
        {
            count = 1;

            SingleJump();
        } else if (count == 1) // not on ground
        {
            //Debug.Log("Second Jump");
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
        //Managers.Audio.PlaySound(jumpSound);
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
            canJump = true;
        }


    }

    private IEnumerator Shield()
    {
        _animator.SetTrigger("Defense");
        Managers.Audio.PlaySound(shieldSound);
        shield.SetActive(true);
        yield return new WaitForSeconds(1f);
        shield.SetActive(false);
       

    }

    public void AttackOrDefense()
    {
        if (dantianController.canUseDanTian())
        {
            if (IsShield)
            {
                StartCoroutine(Shield());
                dantianController.dantianUsed();
            }
            else
            {

                UmbrellaSword();
            }


        }
        else
        {
            StartCoroutine(ShowWarning("丹田不足，无法开伞"));
        }
    }

    private void UmbrellaSword()
    {
        if (Time.time - previousAttackTime > followUpThresholh)
        {
            AttackCounter = 0;
        }
        StartCoroutine(SingleSwordHit(AttackCounter));
        AttackCounter++;
        previousAttackTime = Time.time;
      
       if(AttackCounter >= 3)
        {
            AttackCounter = 0;
        }

    }

    private IEnumerator SingleSwordHit(int type)
    {

        _animator.SetTrigger($"Attack{type}");
        yield return new WaitForSeconds(0.1f);
        AttackArea.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        AttackArea.SetActive(false);

    }

    private IEnumerator ShowWarning(string text)
    {
        warningText.text = text;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        warningText.gameObject.SetActive(false);

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }



}
