using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPoints : MonoBehaviour
{
    [Tooltip("Number of dots needed to do an attack")]
    [SerializeField] private float numNeeded;
    [Tooltip("Number attacks in a full danTian")]
    [SerializeField] private float totalAttack;
    [SerializeField] Image danTian;

    private float currentNum;
    private float maxDanTian;

    private void Start()
    {
        currentNum = 0;
        danTian.fillAmount = 0;
      maxDanTian = numNeeded * totalAttack;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dots")
        {
      
            currentNum += 1;
            Destroy(collision.gameObject);
            updateDanTian();
        }
    }
 
    private void updateDanTian()
    {
        danTian.fillAmount = currentNum / maxDanTian;
    }
}
