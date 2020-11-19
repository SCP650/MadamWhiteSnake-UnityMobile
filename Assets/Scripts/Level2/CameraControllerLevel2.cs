using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerLevel2 : MonoBehaviour
{
    [SerializeField] Transform PlayerLocation;
    [SerializeField] Vector2 cameraspeed;
    public bool isMoving;
    [SerializeField] float multiplier;
    void Awake()
    {
        Messenger.AddListener("cameramove3", Move);
    }
    void Update()
    {
        float Dif= PlayerLocation.transform.position.y - Camera.main.transform.position.y;                        
        transform.position = new Vector3 (PlayerLocation.position.x, PlayerLocation.position.y * (1- Dif * multiplier) + 6.8f , transform.position.z);       
        float y = transform.position.y;
        if (isMoving && y > -119.82f)
        {           
            y -=2 * Time.deltaTime;                                   
        }
        transform.position = new Vector3(PlayerLocation.position.x, y, transform.position.z);
    }
    void Move()
    {
        isMoving = true;        
    }
}
