using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform PlayerLocation;
 

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(PlayerLocation.position.x, transform.position.y, transform.position.z);
    }
}
