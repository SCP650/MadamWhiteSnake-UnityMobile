using UnityEngine;
using System.Collections;



public class ScrollingScript : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private float width;

    private float speed = -3f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = boxCollider.size.x;
        rb.velocity = new Vector2(speed, 0);


    }

    void Update()
    {
        if(transform.position.x < -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);

        transform.position = (Vector2) transform.position + vector;

    }
}













// public class ScrollingScript : MonoBehaviour
// {
//     public float speed = 4f;
//     private Vector3 newPosition;

//     void Start(){
//         newPosition = transform.position;
//     }

//     void Update()
//     {
//         newPosition.x -= Time.deltaTime * speed;
//         transform.position = newPosition;

//     }


// }





// public class ScrollingScript : MonoBehaviour
// {
 
//     /// <summary>
//     /// Scrolling speed
//     /// </summary>
//     public Vector2 speed = new Vector2(2, 2);

//     /// <summary>
//     /// Moving direction
//     /// </summary>
//     public Vector2 direction = new Vector2(-1, 0);

//     /// <summary>
//     /// Movement should be applied to camera
//     /// </summary>
//     public bool isLinkedToCamera = false;

//     void Update()
//     {
//         // Movement
//         Vector3 movement = new Vector3(
//           speed.x * direction.x,
//           speed.y * direction.y,
//           0);

//         movement *= Time.deltaTime;
//         transform.Translate(movement);

//         // Move the camera
//         if (isLinkedToCamera)
//         {
//             Camera.main.transform.Translate(movement);
//         }
//     }
// }