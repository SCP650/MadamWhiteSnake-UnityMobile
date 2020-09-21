using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    float i;
    public Rigidbody enemy6;
    public Transform enemy66;
    private Rigidbody rbb;
    void Start()
    {
        rbb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i > 0.5f)
        {
            Rigidbody enemy666;
            enemy666 = Instantiate(enemy6, enemy66.position, enemy66.rotation) as Rigidbody;
            enemy666.AddForce(enemy66.up * 1.0f);
            i = 0;
        }
        i += Time.deltaTime;
        
    }
}
