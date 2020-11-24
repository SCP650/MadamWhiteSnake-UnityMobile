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

    private float HoldTime;
    public float waveHoldTime;

    public UnityEvent onLeftLongClick;
    public UnityEvent onRightLongClick;
    public UnityEvent onClick;
    public UnityEvent afterLongClick;

    public UnityEvent LeftDoubleClick;

    // private Animator _animator;
    

    private float Width = Screen.width / 2;
    private float Height = Screen.height / 2;

    private float X;
    private float Y;
    float clicked = 1;

<<<<<<< HEAD
    int curclicked = 0;
=======
    float curclicked = 0;
    float clicktime = 0;
>>>>>>> parent of 8b51342... 11
    float clickdelay = 0.5f;
    bool single = false;
    float timer = 0.0f;
    float lastTimeClick = 0f;



    private bool isHolding = false;
    public GameObject Xu;
    private Vector3 scaleChange, curScale;


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        curclicked++;
        X = eventData.position.x;
        Y = eventData.position.y;

<<<<<<< HEAD
        pointerDownTimer += Time.deltaTime;

        onClick.Invoke();// can be commented
;
        if (Time.time - lastTimeClick > clickdelay)
=======
        // Debug.Log(" click ");
        if (onClick != null)
>>>>>>> parent of 8b51342... 11
        {
            // onClick.Invoke();
            // Debug.Log(" click ");
            
<<<<<<< HEAD
        }
        else
        {
            curclicked++;
        }
        StartCoroutine(Shield(curclicked));
        
        lastTimeClick = Time.time;
<<<<<<< HEAD
        //StartCoroutine(Shield(curclicked));
=======
>>>>>>> parent of 8b6c153... 1

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
=======
            // clicktime = Time.time;
            float currentTimeClick = Time.time;

            Debug.Log("timer is " + (currentTimeClick - lastTimeClick));
            if(currentTimeClick - lastTimeClick > 0.5f) // single clicked
            {
            //     Debug.Log(" single click + " + curclicked);
                onClick.Invoke();
                clicktime = Time.time;
                
            }
            if(currentTimeClick - lastTimeClick < 0.2f) // double clicked here
            {
                Debug.Log(" double click + " + curclicked);
                // curclicked = 0;
                // clicktime = 0;
                LeftDoubleClick.Invoke();
            }

            lastTimeClick = currentTimeClick;
           
            
            
            
            
            
        }
        

>>>>>>> parent of 8b51342... 11
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
        // Xu = GameObject.Find("XULI");
        // Xu.SetActive(false);
        // curScale = Xu.transform.localScale;
        // scaleChange = new Vector3(0.05f, 0.05f, 0.05f);

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
                    // Debug.Log(" long click pointer down");
                    Xu.SetActive(true);
                    Xu.transform.localScale += scaleChange;
                    
                    if(pointerDownTimer >= waveHoldTime)
                    {
                        HoldTime = pointerDownTimer;
                        if(onLeftLongClick != null)
                        {
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
                // Xu.SetActive(false);
                // Xu.transform.localScale = curScale;
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