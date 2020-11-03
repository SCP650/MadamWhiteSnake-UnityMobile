using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonboat6 : MonoBehaviour
{
    public bool isMoving;
    void Awake()
    {
        Messenger.AddListener("dragonmoving2", move);
    }
    void Update()
    {
        if (isMoving)
        {
            this.transform.position += Vector3.right * Time.deltaTime * 2.3f;
        }
    }
    void move()
    {
        isMoving = true;
    }
}
