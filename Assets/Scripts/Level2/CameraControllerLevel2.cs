using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerLevel2 : MonoBehaviour
{
    [SerializeField] Transform PlayerLocation;
    [SerializeField] Vector2 cameraspeed;
    public bool isMoving;
    public bool issMoving;
    [SerializeField] float multiplier;
    private float initDIff;
    void Awake()
    {
        Messenger.AddListener("cameramove3", Move);
        Messenger.AddListener("cameramove4", Movee);
        initDIff = PlayerLocation.transform.position.y - Camera.main.transform.position.y;
    }
    void Update()
    {
        float Dif= PlayerLocation.transform.position.y - Camera.main.transform.position.y - initDIff;                        
        transform.position = new Vector3 (PlayerLocation.position.x, transform.position.y + (Dif * multiplier), transform.position.z);       
        float y = transform.position.y;
        if (isMoving && y > -119.82f)
        {
            Debug.Log("Lower camera");
            y -=2 * Time.deltaTime;
            transform.position = new Vector3(PlayerLocation.position.x, y, transform.position.z);
        }
        if (issMoving && y < -111.0f)
        {
            Debug.Log("Higher camera");
            y += 2 * Time.deltaTime;
            transform.position = new Vector3(PlayerLocation.position.x, y, transform.position.z);
            isMoving = false;
        }

    }
    void Move()
    {
        isMoving = true;        
    }
    void Movee()
    {
        issMoving = true;
    }
}
