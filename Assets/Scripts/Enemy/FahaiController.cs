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
    private float waitForBeforeNextFireBall = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        RaycastBoxSize = new Vector2(3f, 3f);
        StartCoroutine(StartAttacking());
        StartCoroutine(ChangeFireSpeed());

    }

    // Update is called once per frame
    void Update()
    {
 
        transform.position = new Vector3(target.position.x-27, target.position.y, target.position.z);
     
    }
    private IEnumerator ChangeFireSpeed()
    {
        yield return new WaitForSeconds(10);
        waitForBeforeNextFireBall -= 1;
        yield return new WaitForSeconds(20);
        waitForBeforeNextFireBall -= 1.5f;
        yield return new WaitForSeconds(20);
        waitForBeforeNextFireBall -= 0.5f;
    }

    private IEnumerator StartAttacking()
    {
        while (true)
        {
            _animator.SetTrigger("FireBallAttack");
            GameObject gb =  Instantiate(FireBallPrefb);
            gb.transform.position = transform.position;
            yield return new WaitForSeconds(waitForBeforeNextFireBall);
        }
       
    }
}
