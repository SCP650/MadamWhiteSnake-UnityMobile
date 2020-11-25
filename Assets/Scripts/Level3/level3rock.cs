using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3rock : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float thrust = 100.0f;

    void Start()
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        transform.position = new Vector3(-97.54f, -151.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.AddForce(transform.forward * thrust, ForceMode2D.Impulse);
    }
}
