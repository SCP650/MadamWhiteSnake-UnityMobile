using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewHoriMove : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    private Rigidbody2D rb;
    private float oldSpeed;
    
    //public bool goleft;
    //public bool goleft1;

    private void Start()
    {
        oldSpeed = speed;
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //goleft = false;
        //goleft1 = false;
    }
    void Update()
    {
        //HorizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * speed);
        //rb.velocity = Vector2.right *speed;

        //if(goleft)
        //{
        //    transform.Translate(Vector3.right * Time.deltaTime * -2*speed);
        //}
        //if (goleft1)
        //{
        //    transform.Translate(Vector3.right * Time.deltaTime * 2 * speed);
        //}
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "left")
    //    {
    //        goleft = true;
    //    }
    //    if (collision.tag == "left1")
    //    {
    //        goleft1 = true;
    //    }

    //}
    public void IncreaseSpeedBy(float percent)
    {
        speed *= percent;
    }

    public void IncreaseFlyingSpeed()
    {
        speed += 3f * Time.deltaTime;
        speed = Mathf.Clamp(speed, oldSpeed, oldSpeed * 2);
    }

    public void ResetSpeed()
    {
        speed = oldSpeed;
    }
  
}
