using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToLadyWhite : MonoBehaviour
{
    [SerializeField] GameObject player;
    private bool isMoving = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.SetParent(collision.gameObject.transform);
            transform.localPosition = new Vector3(0, -5, 0);
            isMoving = false;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position,1f*Time.deltaTime);
        }
    }

    public void startMoving()
    {
        isMoving = true;
    }
}
