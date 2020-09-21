using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //public float HorizontalInput;
    public float VerticalInput;
    public float speed = 5.0f;
  
    
    void Update()
    {
        //HorizontalInput = Input.GetAxis("Horizontal");

        VerticalInput = Input.GetAxis("Vertical");

        if(Input.GetAxis("Vertical") > 0.0f)
        {
            transform.Translate(Vector3.up * VerticalInput * Time.deltaTime * speed);
            //moveDirection = Input.GetAxis("Vertical") * speed;
            //rigidbody.AddRelativeForce(0, 0, moveDirection);


        }
    }

  
}