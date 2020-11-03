using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private MonoBehaviour MovementScript;
    [SerializeField] private AudioClip dieSound;

    private void Start()
    {
        _animator= gameObject.GetComponent<Animator>();
    }

    public void EnemyDie()
    {
        _animator.SetTrigger("Die");
        Destroy(MovementScript);
        if(dieSound != null)
        {
            Managers.Audio.PlaySound(dieSound);
        }
        StartCoroutine(Flicker());

    }

    private IEnumerator Flicker()
    { 
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }
}
