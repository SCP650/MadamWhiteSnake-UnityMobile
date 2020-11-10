using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float requiredHoldTime;
    public float waveHoldTime;

    //public UnityEvent onLongClick;
    public UnityEvent onLeftLongClick;
    public UnityEvent onRightLongClick;
    public UnityEvent onClick;
    public UnityEvent afterLongClick;
    

    private float Width = Screen.width / 2;
    private float Height = Screen.height / 2;

    private float X;
    private float Y;



    private bool isHolding = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        X = eventData.position.x;
        Y = eventData.position.y;
        if (onClick != null)
        {
            onClick.Invoke();

        }

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
           
                // if (onLongClick != null)
                //     onLongClick.Invoke();
                if(X < Width)
                {
                    Debug.Log("Left long click");
                    if(pointerDownTimer >= waveHoldTime)
                    {
                        if(onLeftLongClick != null)
                        {
                            onLeftLongClick.Invoke();
                        }
                    }
                }
                else if(X > Width)
                {
                    Debug.Log("Right long click");
                    if(onRightLongClick != null)
                    {
                        onRightLongClick.Invoke();
                    }
                }

               
            }
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

}