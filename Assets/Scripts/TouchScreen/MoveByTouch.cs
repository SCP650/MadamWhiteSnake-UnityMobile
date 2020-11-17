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
    [SerializeField] AudioClip Attack1Sound;
    [SerializeField] AudioClip Attack2Sound;
    [SerializeField] AudioClip Attack3Sound;
    [SerializeField] Text warningText;
    [SerializeField] private bool IsShield = true;
    [SerializeField] private GameObject AttackArea;
    [SerializeField] private float PlayGravity = 0.5f;

    [SerializeField] private Transform WavePoint;
    [SerializeField] private GameObject WavePrefab;
    //[SerializeField] float jumpHeight = 10f;
  
    private Animator _animator;
    private Vector3 jumpTarget;

   
    private Rigidbody2D rb;
 
    private float width;
    private float MidWidth;
    private float MidHeight;
    private CollectPoints dantianController;

    // private Blade BladeController;

    private float StartPosY;
    private int count = 0;

    private float StartTime;
    private float acumTime = 0;
    private float OldGravity;
    private PlayerViewHoriMove horiSpeed;

    private WAVE waveController;
    private float oldSpeed;
    private bool canJump;
    private float previousAttackTime = 0;
    private float followUpThresholh = 1f;
    private int AttackCounter = 0;

    private bool canFLY = false;
    private bool canWave = false;
    private GameObject X;
    private GameObject Q;

    bool stopShield;
    bool yes;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        width = Screen.width;
        MidWidth = width / 2;
        MidHeight = Screen.height / 2;
        _animator = GetComponent<Animator>();
        dantianController = GetComponent<CollectPoints>();
        waveController = GetComponent<WAVE>();
        // BladeController = GetComponent<Blade>();
        shield.SetActive(false);
        OldGravity = rb.gravityScale;
        horiSpeed = gameObject.GetComponent<PlayerViewHoriMove>();
        // GameObject.Find("WavePoint").SetActive(false);
        X = GameObject.Find("XULI");
        Q = GameObject.Find("QIBO");
    
        X.SetActive(false);
        Q.SetActive(false);

        if (Managers.mission.curLevel == 3)
        {
            IsShield = !Managers.mission.GetPlayerChoice(2);
        }
        stopShield = true;

        
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
            canFLY = false;
            EndFly();
        }else if (dantianController.canUseDanTian())// && CutController.canfly != false)
        {
        
            horiSpeed.IncreaseFlyingSpeed();
            rb.gravityScale = PlayGravity;
            dantianController.FlyingCost();
        }
        else
        {
            canFLY = false;
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
        
        Debug.Log("Wave attack");
        bool finished = false;
        // GameObject XX =  this.transform.Find("XULI").gameObject;
        // GameObject QQ =  this.transform.Find("XULI").gameObject;
        // QQ.SetActive(true);
        // X.SetActive(true);
        // Q.SetActive(true);
        
        
        
        if(dantianController.CurDanTian() >= 1)
        {
            //Debug.Log("CanWave");
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
            X.SetActive(true);
            
            Q.SetActive(true);
            // waveController.Xuli();
            // waveController.Qibo();
            //Instantiate(WavePrefab, transform.position, transform.rotation);
            dantianController.ResetDanTian();

            finished = true;
            // EndWave();
            //Debug.Log("Cur dan tian is " + dantianController.CurDanTian());
            
        }
        
    }

    public void EndWave()
    {
        // GameObject XX =  this.transform.Find("XULI").gameObject;
        // GameObject QQ =  this.transform.Find("XULI").gameObject;
        canWave = false;
        X.SetActive(false);
        Q.SetActive(false);
        // waveController.EndSendWaves();
        // _animator.SetBool("QIBO", false);
    }

    public void CanWave()
    {
        canWave = true;
    }

    public void CANFLY()
    {
        canFLY = false;
    }

    public void CANJUMP()
    {
        canJump = false;
    }
    public void CANShield()
    {
        shield.SetActive(false);
    }

    // public void CheckCut()
    // {
    //     if(dantianController.DanTianMax())
    //     {
    //         canFLY = false;
    //         //canJump = false;
    //         Debug.Log("Ready to cut");
    //         // Debug.Log("ready to cut");
    //         CutController.Cut();
    //     }
    //     // else
    //     // {
    //     //     canFLY = true;
    //     //     canJump = true;

    //     // }
    // }

    

    public void Jump()
    {
        //CheckCut();

        // Debug.Log("onslide is " + BladeController.ONSlide());
       
        if (IsGrounded()) // && BladeController.ONSlide() != true)
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
//        Managers.Audio.PlaySound(jumpSound);
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

    private void OnCollisionStay2D(Collision2D collision)
    {

        // allow jumping again whe nhit ground 
        if (collision.gameObject.tag == "Ground")
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

    // public void StopDefence()
    // {
        
    //     stopShield = true;
        
    
    // }

    // public void ReDefence()
    // {
    
    //     stopShield = false;
    // }
    

    public void AttackOrDefense()
    {
        
       
        if (dantianController.canUseDanTian())
        {
            if(stopShield != true || dantianController.CurDanTian() < 1)
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
        
            // else if(stopShield == true && dantianController.CurDanTian() < 1)
            // {
            //     {
            //         StartCoroutine(ShowWarning("滑切期间无法开伞"));
            //     }
            // }


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
