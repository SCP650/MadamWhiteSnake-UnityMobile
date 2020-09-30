using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] int AddHealthToPlayer = 30;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player");
        Managers.Player.ChangeHealth(AddHealthToPlayer);
        Destroy(gameObject);
    }

}




