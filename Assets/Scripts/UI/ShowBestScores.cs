using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBestScores : MonoBehaviour
{
    [SerializeField] Text[] texts;//length 3

    private void OnEnable()
    {
        texts[0].text = $"最高分: {PlayerPrefs.GetInt("Level1", 0)}";
        texts[1].text = $"最高分: {PlayerPrefs.GetInt("Level2", 0)}";
        texts[2].text = $"最高分: {PlayerPrefs.GetInt("Level3", 0)}";
    }
}
