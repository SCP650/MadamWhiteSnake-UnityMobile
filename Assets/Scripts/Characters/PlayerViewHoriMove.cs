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
        StartCoroutine(Invincible());

        IEnumerator Invincible()
        {
            if (other.gameObject.tag == "Invincible");
            {
                Mathf.Clamp(Managers.Player.health, Managers.Player.health, 100);
                yield return new WaitForSeconds(3.0f);
                Mathf.Clamp(Managers.Player.health, 0, 100);
            }           
        }

    }
    void Update()
    {
        //HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }   
}
