using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float xlength = transform.localScale;
    Event event = new Event();


    void Start()
    {
      xlength = gameObject.GetComponent<transform.localScale>();
      event.AddListener(losehealth);
        }

    void Update() 
    
    if  (CharacterController.Button("damage")&& event != null)
          { 
         event.Invoke();  // 需要加RemoveListener 吗
}
    {
        xlength = Mathf.Clamp(xlength, 0, 1);

    void losehealth()
         transform.localScale = transform.localScale + new Vector3(-0.001f, 0, 0);
    }
}
