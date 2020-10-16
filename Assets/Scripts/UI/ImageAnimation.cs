﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{

    public Sprite[] sprites;
    public int spritePerFrame = 6;
    public bool loop = true;
    public bool destroyOnEnd = false;
    public int loopNum = 2;

    private int index = 0;
    private Image image;
    private int frame = 0;
    private int currNum = 0;

    void Awake()
    {
        image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        index = 0;
        image.sprite = sprites[index];
    }
 

    void Update()
    {
        if (!loop && index == sprites.Length) return;
        frame++;
        if (frame < spritePerFrame) return;
        image.sprite = sprites[index];
        frame = 0;
        index++;
        if (index >= sprites.Length)
        {
            currNum++;
            if (loop && currNum <= loopNum) index = 0;

            if (destroyOnEnd) Destroy(gameObject);
        }
    }
}