using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewHoriMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    void Update()
    {
        //HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
