using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeHealthBar : MonoBehaviour
{
    [SerializeField] Transform healthBar;
    private Image Bar;

    private void Start()
    {
        Bar = healthBar.GetComponent<Image>();
    }

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
      Bar.fillAmount = (float)Managers.Player.health / Managers.Player.maxHealth;
        //float x =
        //healthBar.localScale = new Vector3(x, healthBar.localScale.y, healthBar.localScale.z);
        
    }
}
