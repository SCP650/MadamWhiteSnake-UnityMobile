using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform PlayerLocation;
    public bool isMoving;

    // Update is called once per frame

    void Awake()
    {
        Messenger.AddListener("cameramove", Move);
    }
    void Update()
    {
        transform.position = new Vector3(PlayerLocation.position.x, PlayerLocation.position.y + 10.8f, transform.position.z);
        float y = transform.position.y;
        if (isMoving && y > -155.0f)
        {
            y -= 5 * Time.deltaTime;
            transform.position = new Vector3(PlayerLocation.position.x, y, transform.position.z);
        }
    }
    void Move()
    {
        isMoving = true;
        //this.transform.position = new Vector3(PlayerLocation.position.x, -155.0f, transform.position.z);

    }
}
