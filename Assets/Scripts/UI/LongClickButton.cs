using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float requiredHoldTime;

    private float HoldTime;
    public float waveHoldTime;

    public UnityEvent onLeftLongClick;
    public UnityEvent onRightLongClick;
    public UnityEvent onClick;
    public UnityEvent afterLongClick;


    public UnityEvent LeftDoubleClick;
    private float check = 1f;

    // private Animator _animator;
    

    private float Width = Screen.width / 2;
    private float Height = Screen.height / 2;

    private float X;
    private float Y;
    float clicked = 1;

    int curclicked = 0;
    float clickdelay = 1f;
    bool single = false;
    float timer = 0.0f;
    float lastTimeClick = 0f;



    private bool isHolding = false;
    public GameObject Xu;
    private Vector3 scaleChange, curScale;

    bool stopShield = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        curclicked++;
        X = eventData.position.x;
        Y = eventData.position.y;

        pointerDownTimer += Time.deltaTime;

        if (Time.time - lastTimeClick > clickdelay)
        {
            // Debug.Log(" the time gap is " + (Time.time - lastTimeClick) );
            curclicked = 0;
            
        }
        else
        {
            curclicked++;
        }
        StartCoroutine(Shield(curclicked));
        
        lastTimeClick = Time.time;

        if(curclicked >= 2)
        {
            Debug.Log("double clicked");
            stopShield = true;
            LeftDoubleClick.Invoke();
            // curclicked = 0;
            // stopShield = false;
            
        }
        else{
            StartCoroutine(Shield(curclicked));
        }
    

    }

    private IEnumerator Shield(int type)
    {
        onClick.Invoke();
        yield return new WaitForSeconds(0.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
  
        if (isHolding)
        {
            isHolding = false;
            if (afterLongClick != null)
                afterLongClick.Invoke();
        }
    }
   
    private void Update()
    {
        if (pointerDown)
        {
           // Debug.Log(" long click pointer down");
           
          
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                isHolding = true;

                if(X < Width)
                {
                    Xu.SetActive(true);
                    Xu.transform.localScale += scaleChange;
                    
                    if(pointerDownTimer >= waveHoldTime)
                    {
                        HoldTime = pointerDownTimer;
                        if(onLeftLongClick != null)
                        {
                            // Xu.SetActive(false);
                            onLeftLongClick.Invoke();
                        }
                    }
                }
                else if(X > Width)
                {
                    if(onRightLongClick != null)
                    {
                        onRightLongClick.Invoke();
                    }
                }

               
            }
            else
            {
                // if(onClick != null)
                // {
                //     onClick.Invoke();
                // }
            }
        }
        else{
            // Xu.SetActive(false);
            // Xu.transform.localScale = curScale;
            
        }
        
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    public float Hold()
    {
        return HoldTime;
    }


    

}