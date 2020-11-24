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
    float clickdelay = 0.5f;
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

        onClick.Invoke();// can be commented
;
        if (Time.time - lastTimeClick > clickdelay)
        {
            // Debug.Log(" the time gap is " + (Time.time - lastTimeClick) );
            curclicked = 0;
            
        }
        
        curclicked++;
        lastTimeClick = Time.time;
        //StartCoroutine(Shield(curclicked));

        if(curclicked >= 2)
        {
            curclicked = 0;
            
        }
    

    }

    private IEnumerator Shield(int type)
    {
        switch (type)
        {
            case 0:
                onClick.Invoke();
                break;
            case 1:
                onClick.Invoke();
                break;
            case 2:
                LeftDoubleClick.Invoke();
                break;

        }
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
           Debug.Log(" long click pointer down");
           
          
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