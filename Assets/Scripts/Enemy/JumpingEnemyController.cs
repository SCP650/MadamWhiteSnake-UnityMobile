using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyController : MonoBehaviour
{
    [SerializeField] float baseSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        baseSpeed += 1f * Time.deltaTime;
        transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
       
    }

   IEnumerator Jump()
    {
        while (true)
        {
            float seconds = Random.Range(0.0f, 2.0f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
            yield return new WaitForSeconds(seconds);

        }
    }


}
