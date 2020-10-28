using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] float baseSpeed;
 

    // Update is called once per frame
    void Update()
    {
        baseSpeed += 2f * Time.deltaTime;
        baseSpeed = Mathf.Clamp(baseSpeed, 5, 16);
        transform.position = new Vector3(transform.position.x + baseSpeed * Time.deltaTime, transform.position.y, transform.position.z);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this);
    }
}
