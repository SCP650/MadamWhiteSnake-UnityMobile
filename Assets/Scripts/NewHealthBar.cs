using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHealthBar : MonoBehaviour
{
    void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, Damage);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, Damage);
    }

    private void Damage()
    {
        Debug.Log("Deal the damage");
        transform.localScale = transform.localScale + new Vector3(-0.001f, 0, 0);
    }

}
