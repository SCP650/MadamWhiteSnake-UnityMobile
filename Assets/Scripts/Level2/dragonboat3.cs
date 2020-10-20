using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonboat3 : MonoBehaviour
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
            this.transform.position += Vector3.right * Time.deltaTime * 6.0f;
        }
    }
    void move()
    {
        isMoving = true;
    }
}
