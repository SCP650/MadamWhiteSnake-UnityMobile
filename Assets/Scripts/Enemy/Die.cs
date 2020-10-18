using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private MonoBehaviour MovementScript;

    private void Start()
    {
        _animator= gameObject.GetComponent<Animator>();
    }

    public void EnemyDie()
    {
        _animator.SetTrigger("Die");
        Destroy(MovementScript);
        StartCoroutine(Flicker());

    }

    private IEnumerator Flicker()
    { 
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }
}
