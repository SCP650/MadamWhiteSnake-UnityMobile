﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.Audio.BGMVolume = 1;
        Managers.Audio.PlayLevelMusic(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
