using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Blade : MonoBehaviour {

	[SerializeField] Text warningText;

	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;
	private CollectPoints dantianController;
	// private CountDown CountController;
	

	Vector2 previousPosition;

	GameObject currentBladeTrail;

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	private GameObject Player;

	bool CUT;
	bool pointerDown;

	float Timeleft = 5.0f;

	Vector2 pos;
	// Touch touch;

	void Start ()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
		dantianController = GetComponent<CollectPoints>();
		// CountController = GetComponent<CountDown>();
	}

	void StartCutting ()
	{
		
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
		dantianController.dantianUsed();
	}



    // Update is called once per frame
    // void Update()
	public void StartCUT()
    {
		// CUT = true;

		// if(dantianController.CurDanTian() >= 1)
		// {
		// 	StartCoroutine(ShowWarning("可以开始滑切"));
		// }
		// else
		// {
		// 	StartCoroutine(ShowWarning("丹田不足，不可滑切"));
		// }

		if(dantianController.CurDanTian() >= 1 && Timeleft > 0.0f && CUT == true)
		{
			

			while(Timeleft > 0 | pointerDown)
			{
				Time.timeScale = 0.4f;
				Debug.Log("INNNNNNN");
				Debug.Log("Time left is " + Timeleft);
				StartCoroutine(ShowWarning(Timeleft.ToString()));
				Timeleft -= 1.0f;
				
				
				Touch touch = Input.GetTouch(0);
				// these 3 lines
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				touchPosition.z = 0f;
				transform.position = touchPosition;
				StartCutting();
				dantianController.dantianUsed();
				

				
			}
			

			
		}
		if(Timeleft <= 0.0f)
		{
			// StartCoroutine(ShowWarning("滑切结束"));
			//dantianController.ResetDanTian();
			Timeleft = 5.0f;
			Time.timeScale = 0.999999f;
			CUT = false;
		}

    }

	public void Cancut()
	{
		CUT = true;
		Debug.Log("touch count is " + Input.touchCount);
		// touch = Input.touches[0];
		if(dantianController.CurDanTian() >= 1)
		{
			StartCoroutine(ShowWarning("可以开始滑切"));
		}
		else
		{
			StartCoroutine(ShowWarning("丹田不足，不可滑切"));
		}
		StartCUT();

	}

	public void StopCut()
	{
		CUT = false;
	}

	// public void Cut()
	// {
	// 	Touch touch = Input.GetTouch(0);
	// 	// these 3 lines
	// 	Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
	// 	touchPosition.z = 0f;
	// 	transform.position = touchPosition;
	// 	StartCutting();
	// }

	private IEnumerator ShowWarning(string text)
    {
        warningText.text = text;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        warningText.gameObject.SetActive(false);
		

    }


	public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
		pos = eventData.position;
	}

	public void OnPointerUp(PointerEventData eventData)
    {
		pointerDown = false;
	}

}