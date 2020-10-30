using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAttackDefense : MonoBehaviour
{
    [SerializeField] GameObject AttackButton;
    [SerializeField] GameObject JumpButton;
    [SerializeField] GameObject dantian;
    [SerializeField] GameObject PowerUp;
    private void OnEnable()
    {
        AttackButton.SetActive(false);
        JumpButton.SetActive(false);
        if(dantian != null && PowerUp != null)
        {
            dantian.SetActive(false);
            PowerUp.SetActive(false);
        }
       
    }
    private void OnDisable()
    {
        AttackButton.SetActive(true);
        JumpButton.SetActive(true);
        if (dantian != null && PowerUp != null)
        {
            dantian.SetActive(true);
            PowerUp.SetActive(true);
        }
    }
}
