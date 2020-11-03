using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonboat1 : MonoBehaviour
{
    public bool isMoving;
    void Awake()
    {     
        Messenger.AddListener("dragonmoving", move);        
    }   
    void Update()
    {
        if (isMoving) 
        {
            this.transform.position += Vector3.right * Time.deltaTime * 0.8f;
        }
    }
    void move()
    {
        isMoving = true;
    }
}
