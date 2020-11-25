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
            //Debug.Log(currentNum);
            currentNum += 2;
            currentNum = Mathf.Clamp(currentNum,0, maxDanTian + 1);
            Destroy(collision.gameObject);
            Managers.Audio.PlaySound(collectSound);
            updateDanTian();
            Managers.Player.ChangeScore(10);
        }
    }
 
    private void updateDanTian()
    {
        
        danTian.fillAmount = currentNum / maxDanTian;
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
        currentNum -= 5*Time.deltaTime;
        updateDanTian();
    }
}
