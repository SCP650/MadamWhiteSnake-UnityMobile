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

       

        transform.position = new Vector3(target.position.x-27, target.position.y, target.position.z);
     
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
