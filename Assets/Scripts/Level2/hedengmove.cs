using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hedengmove : MonoBehaviour
{
    [SerializeField] float Horizontalspeed;
    [SerializeField] float Frequency;
    [SerializeField] float Magnitude;
    [SerializeField] float Waittime;
    public bool isMoving;
    public Rigidbody2D r1;
   void Awake()
    {
        Messenger.AddListener("hedengmoving", move);
    }
    private void Start()
    {
        r1 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMoving)
        {
            StartCoroutine("hedengMove");
        }
    }
    IEnumerator hedengMove()
    {
        yield return new WaitForSeconds(Waittime);
        r1.velocity = new Vector3(-Horizontalspeed, Mathf.Sin(Time.time * Frequency) * Magnitude, 0.0f);
    }

    void move()
    {
        isMoving = true;
    }
}
