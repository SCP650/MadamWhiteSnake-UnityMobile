using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maindragon : MonoBehaviour
{
    public bool isMoving;
    public bool issMoving;
    public float Speed;
    [SerializeField] float Waittime;
    void Awake()
    {
        Messenger.AddListener("Maindragon", move);
        Messenger.AddListener("Maindragonstop", stop);
    }
    void Update()
    {
        if (isMoving)
        {
            StartCoroutine("DragonMove");
        }
        if (issMoving)
        {
            Speed = 0;
        }
    }
    IEnumerator DragonMove()
    {
        yield return new WaitForSeconds(Waittime);
        this.transform.position += Vector3.right * Time.deltaTime * Speed;
    }


    void move()
    {
        isMoving = true;
    }
    void stop()
    {
        issMoving = true;
    }
}

