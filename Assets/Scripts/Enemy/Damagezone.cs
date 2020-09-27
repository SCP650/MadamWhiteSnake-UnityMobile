using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagezone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter2D(Collider2D zone)
        {
            PlayerManager damage = zone.GetComponent<PlayerManager>();
            if(damage!= null)
            {
                damage.ChangeHealth(-1);
            }
        }
    }
}
