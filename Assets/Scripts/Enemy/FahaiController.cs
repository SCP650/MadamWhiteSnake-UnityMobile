using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FahaiController : MonoBehaviour
{
    [SerializeField] float baseSpeed = 10;
    [SerializeField] GameObject FireBallPrefb;
    [SerializeField] PlayerViewHoriMove playerSpeed;

    private Transform target;
    private Animator _animator;
    private Rigidbody2D rb;
    private Vector2 RaycastBoxSize;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        RaycastBoxSize = new Vector2(3f, 3f);
        StartCoroutine(StartAttacking());


    }

    // Update is called once per frame
    void Update()
    {

        //var hit = Physics2D.BoxCast(transform.position, RaycastBoxSize, 0, Vector2.right,3);
        //if (hit)
        //{

        //    if(hit.transform.tag == "Ground")
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, 10);
        //    }

        ////}
        //if (transform.eulerAngles.z > 45 || transform.eulerAngles.z < -45)
        //{

        //    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.time * 5);
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //}

        transform.position = new Vector3(transform.position.x + playerSpeed.speed*Time.deltaTime, target.position.y, target.position.z);
     
    }

    private IEnumerator StartAttacking()
    {
        while (true)
        {
            _animator.SetTrigger("FireBallAttack");
            GameObject gb =  Instantiate(FireBallPrefb);
            gb.transform.position = transform.position;
            yield return new WaitForSeconds(2);
        }
       
    }
}
