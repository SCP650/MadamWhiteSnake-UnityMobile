﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame

    // Jump
    private Rigidbody2D rb;
    public float jumpSpeed;
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
    }
    void Update()
    {
        width = Screen.width;
        MidWidth = width /2;
       
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
                    canJump = false;
                    shouldJump = true;
                }
                

            }
            
        }
    }

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

    private void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
