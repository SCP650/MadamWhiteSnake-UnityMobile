using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3camera : MonoBehaviour
{
    [SerializeField] Transform PlayerLocation;
    public bool isMoving;
    public bool issMoving;

    // Update is called once per frame

    void Awake()
    {
        Messenger.AddListener("cameramove", Move);
        Messenger.AddListener("cameramovee", Movee);
    }
    void Update()
    {
        float y = transform.position.y;
        if (isMoving && y < -148.4f)
        {
            Debug.Log("hihihihi");
            y += 1 * Time.deltaTime;
        }       
        if (issMoving && y > -152.9f)
        {
            Debug.Log("hihihihi2");
            y -= 1 * Time.deltaTime;
            isMoving = false;
        }
        transform.position = new Vector3(PlayerLocation.position.x, y, transform.position.z);

    }
    void Move()
    {
        isMoving = true;
        //this.transform.position = new Vector3(PlayerLocation.position.x, -155.0f, transform.position.z);
    }
    void Movee()
    {
        issMoving = true;
    }
}
