﻿using System.Collections;
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
    [SerializeField] AudioClip Attack1Sound;
    [SerializeField] AudioClip Attack2Sound;
    [SerializeField] AudioClip Attack3Sound;
    [SerializeField] GameObject landBtn;
    [SerializeField] Animator DustAnimator;
    [SerializeField] GameObject LineObject;
    [SerializeField] Text warningText;
    [SerializeField] private bool IsShield = true;
    [SerializeField] private GameObject AttackArea;
    [SerializeField] private float PlayGravity = 0.5f;
    //[SerializeField] float jumpHeight = 10f;

    public bool isRolling;
  
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

    private bool canWave = false;
    private GameObject X;
    private GameObject Q;

    private float QIBOTimer;
    private float XULITimer;

    private Vector3 scaleChange, curScale, positionChange, curPosition;

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

        X = GameObject.Find("XULI");
        Q = GameObject.Find("QIBO");
    
        X.SetActive(false);
        Q.SetActive(false);

        if (Managers.mission.curLevel == 3)
        {
            IsShield = !Managers.mission.GetPlayerChoice(2);
        }
        // stopShield = true;

        curScale = Q.transform.localScale;
        scaleChange = new Vector3(0.05f, 0.05f, 0.05f);

        curPosition = Q.transform.position;
        positionChange = new Vector3(-0.03f, 0.0f, 0.0f);
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

    public void StartRolling()
    {
        horiSpeed.IncreaseSpeedBy(0);//set speed to zero
        isRolling = true;
    }

    public void EndRolling()
    {
        horiSpeed.ResetSpeed();
        isRolling = false;
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

    public void WaveAttack()
    {
        
        bool finished = false;
        
        Debug.Log("wave attack");
        if(dantianController.CurDanTian() >= 1)
        {
            // X.SetActive(true);
            StartCoroutine(ShowWarning("长按左边屏幕，发动光波"));
            CanWave();
            
        }
        else if(dantianController.CurDanTian() < 1)
        {
            if(finished)
            {
                EndWave();
            }
            
            StartCoroutine(ShowWarning("丹田不足，无法达成蓄力发动光波"));
            finished = false;
        }
        

        if(IsGrounded() && canWave)
        {
            _animator.SetBool("XULI", true);
            // X.SetActive(true);
            QIBOTimer += Time.deltaTime;
            
            // Debug.Log("qibo timer is " + QIBOTimer);
            if(QIBOTimer < 3.0f)
            {
                
<<<<<<< HEAD
                presstime += Time.deltaTime;
                // Debug.Log("touching + presstime is " + presstime);
                // toucheed = true;
            }

            
            if(QIBOTimer < presstime && dantianController.canUseDanTian())
            {
                X.SetActive(false);
                _animator.SetBool("XULI", true);
=======
>>>>>>> parent of 8b51342... 11
                Q.SetActive(true);
                Q.transform.localScale += scaleChange;
                Q.transform.position += positionChange;
                QIBOTimer += Time.deltaTime;

            }

            if(QIBOTimer + 0.1f >= 3.0f)
            {
                EndWave();
                dantianController.ResetDanTian();

                finished = true;
                

            }
            
        }
        
    }

    public void EndWave()
    {
        // GameObject XX =  this.transform.Find("XULI").gameObject;
        // GameObject QQ =  this.transform.Find("XULI").gameObject;
        canWave = false;
        X.SetActive(false);
        Q.SetActive(false);
        Q.transform.localScale = curScale;
        Q.transform.position -= positionChange * 2;
        _animator.SetBool("XULI", false);
        QIBOTimer = 0.0f;




        // waveController.EndSendWaves();
        // _animator.SetBool("QIBO", false);
    }

    public void CanWave()
    {
        canWave = true;
    }

    public void Land()
    {
        LineObject.SetActive(true);
        rb.AddForce(Vector2.down * 130, ForceMode2D.Impulse);
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

        landBtn.SetActive(true);
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
            landBtn.SetActive(false);
            LineObject.SetActive(false);
            DustAnimator.SetTrigger("Land");
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
        if (isRolling)
        {
            //UmbrellaSword();
            StartCoroutine(Shield());

            rb.AddForce(Vector2.right * 100, ForceMode2D.Impulse);
            return;
        }
       
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
                dantianController.dantianUsed();
            }


        }
        else
        {
            StartCoroutine(ShowWarning("丹田不足，无法开伞/滑切"));
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
        switch (type)
        {
            case 0:
                Managers.Audio.PlaySound(Attack1Sound);
                break;
            case 1:
                Managers.Audio.PlaySound(Attack2Sound);
                break;
            case 2:
                Managers.Audio.PlaySound(Attack3Sound);
                break;

        }
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
