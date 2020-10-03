using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    // Jump
    //public float jumpSpeed;
    [SerializeField] float jumpHeight;
    private Vector3 jumpTarget;

   
    private Rigidbody2D rb;

    private bool shouldJump;
    private bool canJump;
 
    // Start is called before the first frame update
    

    // Screen Split
    private float width;
    private float MidWidth;

    // shoot
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        Debug.Log("in");
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        width = Screen.width;
        MidWidth = width / 2;
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
                Debug.Log("Left click");
                Fire();
                
            }
            else if(touchPos.x > MidWidth)
            {
                //attack
                Debug.Log("Right click");
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
            Fire();
        }
    }

    private void Jump()
    {
        Vector3 curr = transform.position;
        jumpTarget = new Vector3(curr.x, curr.y + jumpHeight, curr.z);
        canJump = false;
        shouldJump = true;
    }

    private void FixedUpdate()
    {

        // jump
        if (shouldJump)
        {
            //Call juming animation 
            Vector3 delta = jumpTarget - transform.position;
            transform.position += delta * 0.1f;
            //Debug.Log(delta.y);
            //rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            shouldJump &= delta.y > 3f;


        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        // allow jumping again whe nhit ground 
        canJump |= col.gameObject.tag == "Ground";


    }

    private void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
