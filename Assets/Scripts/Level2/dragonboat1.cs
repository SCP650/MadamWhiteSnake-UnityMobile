using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonboat1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {     
        Messenger.AddListener("dragonmoving", move);
    }
    // Update is called once per frame
    void move()
    {
        Debug.Log("hihihi");
        this.transform.position += Vector3.right * Time.deltaTime * 3.0f;
    }
}
