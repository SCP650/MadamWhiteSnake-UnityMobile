using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class Blade : MonoBehaviour {


	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

	private CollectPoints dantianController;
	private OnClick ClickController;
	// private Score ScoreController;
	private HideText TextController;
	private CountDown CountController;
	// private LongClickButton LongClickController;

	// private MoveByTouch MoveController;
	Vector2 previousPosition;

	GameObject currentBladeTrail;
	// GameObject R;

	Rigidbody2D rb;
	CircleCollider2D circleCollider;

	private float fixedDeltaTime;
	

	// GameObject scoreText;

	bool finished;
	public GameObject Attack;

	private Animator _animator;
	void Start ()
	{
		///cam = Camera.main;

		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
		dantianController = GetComponent<CollectPoints>();
		ClickController = GetComponent<OnClick>();
		TextController = GetComponent<HideText>();
		CountController = GetComponent<CountDown>();
		// ScoreController = GetComponent<Score>();
		// MoveController = GetComponent<MoveByTouch>();
		Attack = GameObject.Find("AttackBtn");
		// scoreText = GameObject.Find ("Score");
		finished = false;
		circleCollider.enabled = true;
	}


	void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
	

	void Update()
	{
		// COL.enabled = true;
		if(dantianController.CurDanTian() >= 1 )
		{
			ClickController.showbutton();
			TextController.showText();
			
			if( ClickController.CLICK() == true && CountController.curTime() >= 0)
			{
				
				ClickController.hidedbutton();
				TextController.hideText();
				// MoveController.StopDefence();
				CountController.StartCount();

				Time.timeScale = 0.4f;
	

				Cut();
			}
		}
		else
		{
			ClickController.hidedbutton();
			TextController.hideText();
		}

		
		

		if(CountController.curTime() <= 0 && dantianController.CurDanTian() >= 1)
		{
			
			TextController.hideText();
			ClickController.hidedbutton();
			finished = false;
			
			dantianController.ResetDanTian();
			
			
			// Debug.Log("cur dan tian issss " + dantianController.CurDanTian());
			Time.timeScale = 0.99f;
			//MoveController.ReDefence();
			
		}
		//Debug.Log("cur dan tian is " + dantianController.CurDanTian());


		Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
		
	}

	public void StartCutting ()
	{
		Touch touch = Input.GetTouch(0);
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = Camera.main.ScreenToWorldPoint(touch.position);
		circleCollider.enabled = true;
		finished = true;
		
		
		
	}

	public void Cut()
	{
		CountController.StartCount();
		if(Input.touchCount > 0)
        {
			
			finished = true;
            Touch touch = Input.GetTouch(0);
			// these 3 lines
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
            StartCutting();

        }
		

	}


	

	

}