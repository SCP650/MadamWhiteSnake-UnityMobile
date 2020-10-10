using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [SerializeField] ParticleSystem healthParticle;

    private void Awake()
    {
        Messenger.AddListener(PowerupEvent.HEALTH_INCREASE, PlayHealthParticle);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(PowerupEvent.HEALTH_INCREASE, PlayHealthParticle);
    }
    private void PlayHealthParticle()
    {
        //Debug.Log("play particle");
        //healthParticle.Emit(5);
        healthParticle.Play();
    }
}
