using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] stepOnBoat;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Managers.Audio.PlaySound(stepOnBoat[Random.Range(0, stepOnBoat.Length)]);
        }
    }


}
