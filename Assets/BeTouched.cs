using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeTouched : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                
                var rig = hitInfo.collider.GetComponent<Rigidbody>();
                
                Debug.Log("hit");
                TouchDestroy();
                
            }
    }

    void TouchDestroy()
    {
        // Destroy the gameObject after clicking on it
        Destroy(gameObject);
    }
}
