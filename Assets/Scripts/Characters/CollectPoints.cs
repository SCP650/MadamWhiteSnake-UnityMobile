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
    [SerializeField] AudioClip collectSound;

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
            currentNum = Mathf.Clamp(currentNum,0, maxDanTian + 1);
            Destroy(collision.gameObject);
            Managers.Audio.PlaySound(collectSound);
            updateDanTian();
            
        }
    }
 
    
    private void updateDanTian()
    {
        // Debug.Log("maxnum = " + maxDanTian + " cur num = " + currentNum);
        // Debug.Log("fill amount" + danTian.fillAmount);
        danTian.fillAmount = currentNum / maxDanTian;
         
    }
    public bool DanTianMax()
    {
        //Debug.Log("maxnum = " + maxDanTian + " cur num = " + currentNum);
        return danTian.fillAmount >= 1;
    }

    public void ResetDanTian()
    {
        Debug.Log("resetttttttttttttttt");
        currentNum = 0;
        updateDanTian();
    }

    public bool canUseDanTian()
    {
        return currentNum > numNeeded;
    }

    

    public void dantianUsed()
    {
        currentNum -= numNeeded;
        updateDanTian();
    }

    public void FlyingCost()
    {
        currentNum -= 2*Time.deltaTime;
        updateDanTian();
    }
}
