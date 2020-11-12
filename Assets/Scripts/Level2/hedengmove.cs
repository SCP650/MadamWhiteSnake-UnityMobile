using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hedengmove : MonoBehaviour
{
    [SerializeField] float Horizontalspeed;
    [SerializeField] float Frequency;
    [SerializeField] float Magnitude;
    public Rigidbody2D r1;


    private void Start()
    {
        r1 = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        r1.velocity = new Vector3(-Horizontalspeed, Mathf.Sin(Time.time*Frequency)* Magnitude, 0.0f);

    }
}
