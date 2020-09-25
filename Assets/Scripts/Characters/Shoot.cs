using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
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

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;


  

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}