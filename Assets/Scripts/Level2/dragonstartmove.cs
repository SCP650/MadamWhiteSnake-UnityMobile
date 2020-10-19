using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonstartmove : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            Debug.Log("startmoveing");
            BroadcastMessage("dragonmoving");
        }
    }



}
