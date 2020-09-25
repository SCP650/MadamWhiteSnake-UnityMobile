using UnityEngine;
using System.Collections;

//public class Intanciate : MonoBehaviour
//{
//    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
//    public GameObject myPrefab;

//    // This script will simply instantiate the Prefab when the game starts.
//    void Start()
//    {
//        // Instantiate at position (0, 0, 0) and zero rotation.
//        Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
//    }
//}


// Instantiate a rigidbody then set the velocity

public class Intanciate : MonoBehaviour
{
    // Assign a Rigidbody component in the inspector to instantiate

    public Rigidbody projectile;
    public Transform barrelEnd;

    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody ProjectileInstance;
            ProjectileInstance = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            ProjectileInstance.AddForce(barrelEnd.forward * 5000);
            //Rigidbody clone;
            // clone = Instantiate(projectile, transform.position, transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            //   clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        }
    }
}