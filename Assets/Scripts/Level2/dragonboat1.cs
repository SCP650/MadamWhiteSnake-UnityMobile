using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonboat1 : MonoBehaviour
{
    public bool isMoving;
    public float Speed;
    [SerializeField] float Waittime;
    void Awake()
    {     
        Messenger.AddListener("dragonmoving", move);        
    }   
    void Update()
    {
        if (isMoving) 
        {
            StartCoroutine("DragonMove");
        }
    }
    IEnumerator DragonMove()
    {
        yield return new WaitForSeconds(Waittime);
        this.transform.position += Vector3.right * Time.deltaTime * Speed;
    }
    void move()
    {
        isMoving = true;
    }
}
