using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToLadyWhite : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    private bool isMoving = false;

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag == "Player")
        {
          
            transform.SetParent(collision.gameObject.transform);
            transform.localPosition = new Vector3(1, -5, 0);
            //StartCoroutine(StartRolling());
            isMoving = false;
            //enabled = false;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position,10f*Time.deltaTime);
        }
    }

    public void startMoving()
    {
        isMoving = true;
    }

    public void DetachFromWhite()
    {
        transform.SetParent(null);
        transform.position = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z);
    }

    //IEnumerator StartRolling()
    //{
    //    yield return new WaitForSeconds(2);
    //    player.GetComponent<MoveByTouch>().StartRolling();
    //}
}
