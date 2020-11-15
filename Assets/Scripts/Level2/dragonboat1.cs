using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonboat1 : MonoBehaviour
{
    public bool isMoving;
    public float Speed;
    void Awake()
    {     
        Messenger.AddListener("dragonmoving", move);        
    }   
    void Update()
    {
        if (isMoving) 
        {
            this.transform.position += Vector3.right * Time.deltaTime * Speed;
        }
    }
    void move()
    {
        isMoving = true;
    }
}
