using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Dragon1move : MonoBehaviour
{
    UnityEvent dragon = new UnityEvent();

    void Start()
    {
        dragon.AddListener(dragonmoving);
    }
    void Update()
    {
        if(dragon != null)
        {
            this.transform.position += Vector3.right * Time.deltaTime;
        }
    }
    void dragonmoving()
    {

    }
}
