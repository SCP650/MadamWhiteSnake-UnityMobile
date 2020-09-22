using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpMove : MonoBehaviour
{
    public float jumpSpeed;
    private bool shouldJump;
    private bool canJump;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetAxis("Vertical") > 0.0f)
        {
            canJump = false;
            shouldJump = true;
        }
    }
    // apply physics movement based on input values
    private void FixedUpdate()
    {

        // jump
        if (shouldJump)
        {
            //Call juming animation 
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            shouldJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // allow jumping again whe nhit ground 
        //should also check whether col is ground
        canJump = true;
      
    }
}
