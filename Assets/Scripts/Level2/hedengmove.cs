using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hedengmove : MonoBehaviour
{
    [SerializeField] float Horizontalspeed;
    [SerializeField] float Verticalspeed;
    public Rigidbody2D r1;


    private void Start()
    {
        r1 = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        r1.velocity = new Vector3(-Horizontalspeed, Verticalspeed, 0.0f);

        if (transform.position.y > -122.0f )
        {
            Verticalspeed = Verticalspeed * -1;
        }

        if (transform.position.y < -128.0f)
        {
            Verticalspeed = Verticalspeed * -1;
        }
    }
}
