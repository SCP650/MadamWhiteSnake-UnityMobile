using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform PlayerLocation;
    [SerializeField] Vector2 cameraspeed;
    public bool isMoving;
    private Transform cameraTransform;
    private Vector3 lastPlayerPosition;

    // Update is called once per frame

    void Awake()
    {
        Messenger.AddListener("cameramove", Move);
    }
    private void Start()
    {
        cameraTransform = PlayerLocation.transform;
        lastPlayerPosition = cameraTransform.position;
    }
    private void LateUpdate()
    {
        Vector3 delatMovment = cameraTransform.position - lastPlayerPosition;
        transform.position += new Vector3(delatMovment.x * cameraspeed.x, delatMovment.y * cameraspeed.y, 0);
    }
    void Update()
    {  
        transform.position = new Vector3(PlayerLocation.position.x, PlayerLocation.position.y + 9.8f, transform.position.z);

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
