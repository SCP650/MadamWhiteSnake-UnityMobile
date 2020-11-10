using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update\
    public Text Mytext;
    private CountDown CountController;
    float score;

    bool canStop;
    
    void Start()
    {
        Text TT = Mytext.GetComponent<Text>();
        TT.enabled = false;
        score = 0.0f;
        CountController = GetComponent<CountDown>();
        canStop = false;
        
    }

    // Update is called once per frame
    public void StartCount()
    {
        
        Text TT = Mytext.GetComponent<Text>();
        TT.enabled = true;

        
         score += Time.deltaTime;
         TT.text = "Time Left:" + Mathf.Round(score);
        //  if(CountController.curTime() <= 0 )
        //  {
        //     StopCount();
        //  }
        //  else
        //  {
        //     canStop = false;
        //  }

    }

    // IEnumerator waiter()
    // {
    //     Debug.Log("wait wait wait");
    //     yield return new WaitForSeconds(20);
    // }

    public void StopCount()
    {
        Text TT = Mytext.GetComponent<Text>();
        // TT.text = "Time End";
        TT.enabled = false;
        canStop = true;
    }
    public void HandyReduceScore()
    {
        score -= Time.deltaTime;
    }


    public bool STOP()
    {
        // Debug.Log("canstop is " + canStop);
        return canStop;
    }

    public float curTime()
    {
        return score;
    }



}
