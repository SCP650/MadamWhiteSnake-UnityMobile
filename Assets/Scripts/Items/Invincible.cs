using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player");
        Destroy(gameObject); 
        //  用哪个mltp map 什么应该可以 限制health在一个范围  
    }
}
