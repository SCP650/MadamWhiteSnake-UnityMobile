using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maindragon : MonoBehaviour
{
    public bool isMoving;
    void Awake()
    {
        Messenger.AddListener("dragonmoving3", move);
    }
    void Update()
    {
        if (isMoving)
        {
            this.transform.position += Vector3.right * Time.deltaTime * 12.0f;
        }
    }
    void move()
    {
        isMoving = true;
    }
}
