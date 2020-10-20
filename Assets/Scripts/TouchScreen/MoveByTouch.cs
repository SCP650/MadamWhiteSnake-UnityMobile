using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private CollectPoints dantianController;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        width = Screen.width;
        MidWidth = width / 2;
        _animator = GetComponent<Animator>();
        dantianController = GetComponent<CollectPoints>();
        shield.SetActive(false);
    }
    void Update()
    {

       
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            

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
              
                if (canJump)
                {
                    Jump();
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

    private void Jump()
    {
       _animator.SetBool("Jumping", true);

        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        //Vector3 curr = transform.position;
        //jumpTarget = new Vector3(curr.x, curr.y + jumpHeight, curr.z);
        canJump = false;
        Managers.Audio.PlaySound(jumpSound);
        //shouldJump = true;
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
        //Debug.Log($"Attack{type}");
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
        yield return new WaitForSeconds(4);
        warningText.gameObject.SetActive(false);

    }
}
