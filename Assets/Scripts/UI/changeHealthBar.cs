using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeHealthBar : MonoBehaviour
{
    [SerializeField] Transform healthBar;
    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, ChangeHealthBar);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, ChangeHealthBar);
    }
    private void ChangeHealthBar()
    {
        float x = (float) Managers.Player.health / Managers.Player.maxHealth;
        Debug.Log(x);
        healthBar.localScale = new Vector3(x, healthBar.localScale.y, healthBar.localScale.z);
    }
}
