using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAttackDefense : MonoBehaviour
{
    [SerializeField] GameObject AttackButton;
    [SerializeField] GameObject JumpButton;
    private void OnEnable()
    {
        AttackButton.SetActive(false);
        JumpButton.SetActive(false);
    }
    private void OnDisable()
    {
        AttackButton.SetActive(true);
        JumpButton.SetActive(true);
    }
}
