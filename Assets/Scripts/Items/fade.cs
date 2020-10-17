using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{ 
    public Animator anim;  
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("richrich");
            anim.Play("level2 虚化");
        }            
    }
}
