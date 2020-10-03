using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewHoriMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] int AddHealthToPlayer = 30;


private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boost") {
            Destroy(other.gameObject);
            StartCoroutine(Addspeed());             
         }

        if (other.gameObject.tag == "Invincible"){ 
        Destroy(other.gameObject);
        StartCoroutine(Power());
         }

        if (other.gameObject.tag == "Heart"){
         Destroy(other.gameObject);
         StartCoroutine(Addhealth());
         }
    }
        IEnumerator Addspeed()
        {           
        speed = 15.0f;
        yield return new WaitForSeconds(1.0f);
        speed = 5.0f;    
         }

        IEnumerator Power()
        {
         gameObject.tag = "Untagged";
         yield return new WaitForSeconds(3.0f);
         gameObject.tag = "Player";
         }
        IEnumerator Addhealth()
        {
         Managers.Player.ChangeHealth(AddHealthToPlayer);        
         yield return null;
         }



void Update()
    {
        //HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }   
}
