using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private void Start()
    {

        Managers.Player.UpdataData(100, 100);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Managers.Player.ChangeHealth(-10);
        }
    }
}
