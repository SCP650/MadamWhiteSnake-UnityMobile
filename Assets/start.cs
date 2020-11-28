using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    Collision2D col;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.gameObject.tag == "Player")
        {
            // Disables the Collider2D component
            Debug.Log("sai");
            audioSource.enabled = true;
            
        }
    }

    // void Update()
    // {
    //     Debug.Log(col.gameObject.tag);
        
    //     if(col.gameObject.tag == "Player")
    //     {
    //         audioSource.enabled = true;
    //         Debug.Log("sai");
    //         audioSource.Play();
    //     }
    // }
}
