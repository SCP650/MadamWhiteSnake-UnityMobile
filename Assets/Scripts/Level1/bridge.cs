using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour
{
    [SerializeField] float Waittime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine("Fall");
        }
    }    
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(Waittime);
        GetComponent<SpringJoint2D>().enabled = false;
    }                                 
}
