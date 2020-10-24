using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Blade : MonoBehaviour {

	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

	

	Vector2 previousPosition;

	GameObject currentBladeTrail;

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	void Start ()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
	}


	void StartCutting ()
	{
		
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
	}



    // Update is called once per frame
    void Update()
    {
        // Touch touch = Input.GetTouch(0);
            // Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        if(Input.touchCount > 0)
        {
           
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition; 
            StartCutting();			
        }


		
    }

	

}