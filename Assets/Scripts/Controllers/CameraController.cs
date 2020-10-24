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
        transform.position = new Vector3(PlayerLocation.position.x, transform.position.y, transform.position.z);

        if (isMoving)
        {
            this.transform.position = new Vector3(PlayerLocation.position.x, -155.0f, transform.position.z);
        }
    }
    void Move()
    {
        isMoving = true;
    }
}
