﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonboat1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.right * Time.deltaTime;
    }
}
