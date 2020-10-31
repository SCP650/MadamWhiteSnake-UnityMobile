using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3cameraa : MonoBehaviour
{
    [SerializeField] Transform PlayerLocation;
    public bool issMoving;
    void Start()
    {
        Messenger.AddListener("cameramovee", Movee);
    }

    // Update is called once per frame
    void Update()
    {
        float y = transform.position.y;
        if (issMoving && y > -152.9f)
        {
            y -= 1 * Time.deltaTime;
        }
        transform.position = new Vector3(PlayerLocation.position.x, y, transform.position.z);
    }
    void Movee()
    {
        issMoving = true;
    }
}
