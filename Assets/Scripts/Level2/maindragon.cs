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
        Messenger.AddListener("aindragonstop", stop);
    }
    void Update()
    {
        if (isMoving)
        {
            StartCoroutine("DragonMove");
        }
        if (issMoving)
        {
            StartCoroutine("Dragonstop");
        }
    }
    IEnumerator DragonMove()
    {
        yield return new WaitForSeconds(Waittime);
        this.transform.position += Vector3.right * Time.deltaTime * Speed;
    }
    IEnumerator Dragonstop()
    {        
        this.transform.position -= Vector3.right * Time.deltaTime * Speed;
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

