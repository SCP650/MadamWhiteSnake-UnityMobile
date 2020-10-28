using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3camera : MonoBehaviour
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
        float y = transform.position.y;
        if (isMoving && y < -148.4f)
        {
            y += 1 * Time.deltaTime;
        }
        transform.position = new Vector3(PlayerLocation.position.x, y, transform.position.z);


    }
    void Move()
    {
        isMoving = true;
        //this.transform.position = new Vector3(PlayerLocation.position.x, -155.0f, transform.position.z);

    }
}
