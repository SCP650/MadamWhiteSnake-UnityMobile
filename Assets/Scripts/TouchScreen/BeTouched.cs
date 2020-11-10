// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class BeTouched : MonoBehaviour
// {
//     // Start is called before the first frame update
//     // void Start()
//     // {
        
//     // }

//     // Update is called once per frame
//     //public GameObject Peach;
//     public Text displayText;
    

//     Collider Peach;

//     bool touched;

//     void Start() {
//         displayText.text = "";
        
//     }
//     void Update()
//     {
        
//         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hitInfo;
//         if (Physics.Raycast(ray, out hitInfo))
//         {
            
//             var rig = hitInfo.collider.GetComponent<Rigidbody>();
            
//             Debug.Log("hit");
//             DisplayText();

//             OnCollisionEnter(Peach);

//             if(touched == true)
//             {
//                 Debug.Log("trueeee");
//             }
//             else
//             {
//                 Debug.Log("False");
//             }

            
            
//             //TouchDestroy();
//             //Peach.GetComponent<TextMesh>().text = "Hello World";

            
//         }
        
//     }

//     void TouchDestroy()
//     {
//         // Destroy the gameObject after clicking on it
//         Destroy(gameObject);
//     }

//     public void DisplayText() {
//        displayText.text = "BossKill";
       
//     }

//     private void OnCollisionEnter (Collider other) 
//     {
//         GameObject scoreText = GameObject.Find ("Score");
//         scoreText.GetComponent<ShowScore> ().incrementScore (1);
        
//         if (other.gameObject.tag == "SlidePoint")
//         {
//             Debug.Log("Here");
//             touched = true;
//         }
        
//     }
//     // private void wait()
//     // {
//     //     yield return new WaitForSeconds(1f);
//     // }
// }
