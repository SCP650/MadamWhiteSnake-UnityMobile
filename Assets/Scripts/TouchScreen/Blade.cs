using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Blade : MonoBehaviour {


	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

	private CollectPoints dantianController;
	private MoveByTouch MoveController;
	private Score ScoreController;
	Vector2 previousPosition;

	GameObject currentBladeTrail;
	// GameObject R;

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	//public bool canfly = true;
	private float fixedDeltaTime;
	

	GameObject scoreText;

	private bool finished;

	//public GameObject Slidepoint;

	void Start ()
	{
		///cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
		dantianController = GetComponent<CollectPoints>();
		MoveController = GetComponent<MoveByTouch>();
		ScoreController = GetComponent<Score>();
		scoreText = GameObject.Find ("Score");
		finished = false;
		
	}

	

	void Update()
	{
		//var PlayerPos = player.transform.position;
		// Debug.Log("player pos is " + MoveController.gameObject.transform.position.x);

		
		if(dantianController.DanTianMax() )
		{
			//R.SetActive(true);
			
            Time.timeScale = 0.5f;
			// canfly = false;
			//Debug.Log("ready to cut");
			Cut();
			scoreText.GetComponent<Score>().getScore();
			
			// scoreText.GetComponent<Score>().incrementScore(1);
			
 			
			
			
		}
		else
		{
			// BLADE.SetActive(false);
			Time.timeScale = 1.0f;
			// finished = false;
		}

		
		Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;

		scoreText.GetComponent<Score>().HideText();

		if(finished)
		{
			Debug.Log("finishedeee");
			dantianController.ResetDanTian();
			
		}
		
		
		
	}

<<<<<<< Updated upstream

	void StartCutting ()
=======
	void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

	

	public void StartCutting ()
>>>>>>> Stashed changes
	{
		
		Touch touch = Input.GetTouch(0);
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(touch.position);
		circleCollider.enabled = false;
		finished = true;
	}



    // Update is called once per frame
    // void Update()
    // {
    //     // Touch touch = Input.GetTouch(0);
    //         // Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    //     Cut();

    // }

	public void Cut()
	{

		// Debug.Log("CUTTT");
		if(Input.touchCount > 0)
        {
		
            Touch touch = Input.GetTouch(0);
			// these 3 lines
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
<<<<<<< Updated upstream
            transform.position = touchPosition; 
            StartCutting();			
=======
            transform.position = touchPosition;
            StartCutting();
			//finished = true;

			

			// ScoreController.Show();
			
>>>>>>> Stashed changes
        }
	}


<<<<<<< Updated upstream
		
    }
=======
	
>>>>>>> Stashed changes

	

}