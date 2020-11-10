using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update\
    public Text Mytext;
    private CollectPoints dantianController;
    float timeLeft;
    float maxtime;

    bool canStop;

    private bool ShouldStop = false;
    
    void Start()
    {
        Text TT = Mytext.GetComponent<Text>();
        TT.enabled = false;
        timeLeft = 2.0f;
        maxtime = 2.0f;
        dantianController = GetComponent<CollectPoints>();
        canStop = false;
        
    }

    // Update is called once per frame
    public void StartCount()
    {
        
        Text TT = Mytext.GetComponent<Text>();
        TT.enabled = true;

        
         timeLeft -= Time.deltaTime;
         TT.text = "Time Left:" + Mathf.Round(timeLeft);
         if(timeLeft <= 0 && dantianController.CurDanTian() >= 1)
         {
             //Debug.Log("stop counting and cur dan tian is " + dantianController.CurDanTian());
            StopCount();
            ShouldStop = true;
         }
         else //if(0.0f < timeLeft  && timeLeft < maxtime)
         {
            canStop = false;
            ShouldStop = false;
         }

    }

    public bool TimeIsZero()
    {
        return ShouldStop;
    }

    public void StopCount()
    {
        Text TT = Mytext.GetComponent<Text>();
        // TT.text = "Time End";
        TT.enabled = false;
        canStop = true;
    }
    public void HandyReduceTime()
    {
        timeLeft -= Time.deltaTime;
    }


    public bool STOP()
    {
        // Debug.Log("canstop is " + canStop);
        return canStop;
    }

    public float curTime()
    {
        return timeLeft;
    }



}
