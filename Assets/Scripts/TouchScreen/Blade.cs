using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

	float Timeleft = 2.0f;

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
    void Update()
    {
        // Touch touch = Input.GetTouch(0);
            // Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        if(Input.touchCount > 0)
        {
           	if(dantianController.CurDanTian() >= 1 && Timeleft >= 0.0f && Cancut() == true)
			{
				// CountController.StartCount();
				// while(dantianController.CurDanTian() > 0)
				// {
					Debug.Log("cur dqn tian is " + dantianController.CurDanTian());
					StartCoroutine(ShowWarning(Timeleft.ToString()));
					Timeleft -= 1.0f;
					Time.timeScale = 0.4f;
					Cut();
				// }
				
			}
			else
			{
				// StartCoroutine(ShowWarning("丹田不足，无法滑切"));
			}
        }
		else if(Input.touchCount == 0 && Timeleft <= 0.0f)
		{
			StartCoroutine(ShowWarning("滑切结束"));
			//dantianController.ResetDanTian();
			Timeleft = 2.0f;
			Time.timeScale = 0.999999f;
		}

    }

	public bool Cancut()
	{
		return true;
	}

	public void Cut()
	{
		Touch touch = Input.GetTouch(0);
		// these 3 lines
		Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
		touchPosition.z = 0f;
		transform.position = touchPosition;
		StartCutting();
	}

	private IEnumerator ShowWarning(string text)
    {
        warningText.text = text;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        warningText.gameObject.SetActive(false);

    }

}