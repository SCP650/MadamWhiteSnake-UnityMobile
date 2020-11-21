using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maindragon : MonoBehaviour
{
    [SerializeField] Transform target;
    private bool isMoving;
    private bool issMoving;
    private float Speed = 8;
    private float oldSpeed;
    private float Waittime = 0.3f;
    private void Start()
    {
        oldSpeed = Speed;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.right * Speed*Time.deltaTime);
        }
    }
    void Awake()
    {
        Messenger.AddListener("Maindragon", move);
        Messenger.AddListener("Maindragonstop", stop);
    }
    
 
    IEnumerator DragonMove()
    {
        while (true)
        {
            float delta = transform.position.x - target.position.x;
            if (delta < -20)
            {
                Speed *= 1.5f;
            }else if (delta < -10)
            {
                Speed = oldSpeed*1.2f;
            }
   
            else
            {
                Speed = oldSpeed;
            }
            
            yield return new WaitForSeconds(Waittime);
            //this.transform.position += Vector3.right * Time.deltaTime * Speed;
            //rb.AddForce(Vector2.right * 100, ForceMode2D.Impulse);
        }

    }


    void move()
    {
        StartCoroutine("DragonMove");
        isMoving = true;
    }
    void stop()
    {
        StopAllCoroutines();
        Speed = 0;
        isMoving = false;
    }
}

