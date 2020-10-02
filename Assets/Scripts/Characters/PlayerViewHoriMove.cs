using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewHoriMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(boost());
        
        IEnumerator boost()
        {
            if (other.gameObject.tag == "Boost");
            { 
            speed = 15.0f;
                yield return new WaitForSeconds(1.0f);
            speed = 5.0f;
            }
        }
    }
    void Update()
    {
        //HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }   
}
