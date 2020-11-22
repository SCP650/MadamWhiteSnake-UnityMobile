using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFish : MonoBehaviour
{
    public float Speed;
    public bool isMoving;
    [SerializeField] float Waittime;
    void Awake()
    {
        Messenger.AddListener("fishmoving", move);
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            StartCoroutine("fishmoving");
        }
    }
    IEnumerator fishmoving()
    {
        yield return new WaitForSeconds(Waittime);
        this.transform.Translate(Vector3.right * Time.deltaTime * Speed);
    }


    // Update is called once per frame




    void move()
    {
        isMoving = true;
    }
}