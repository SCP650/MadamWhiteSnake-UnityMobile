using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewHoriMove : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    private float oldSpeed;

    private void Start()
    {
        oldSpeed = speed;
    }
    void Update()
    {
        //HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    public void IncreaseSpeedBy(float percent)
    {
        speed *= percent;
    }

    public void IncreaseFlyingSpeed()
    {
        speed += 3f * Time.deltaTime;
        speed = Mathf.Clamp(speed, oldSpeed, oldSpeed * 2);
    }

    public void ResetSpeed()
    {
        speed = oldSpeed;
    }
  
}
