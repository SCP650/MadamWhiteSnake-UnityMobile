using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mountainroad : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            anim.Play("Level1 mountain road");
        }
    }

}
