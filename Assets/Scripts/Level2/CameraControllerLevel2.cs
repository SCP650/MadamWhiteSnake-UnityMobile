using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerLevel2 : MonoBehaviour
{
    [SerializeField] Transform PlayerLocation;
    [SerializeField] Vector2 cameraspeed;
    public bool isMoving;
    private Transform cameraTransform;
    private Vector3 lastPlayerPosition;

    // Update is called once per frame


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
        transform.position = new Vector3(PlayerLocation.position.x, PlayerLocation.position.y + 6.8f, transform.position.z);
    }

}
