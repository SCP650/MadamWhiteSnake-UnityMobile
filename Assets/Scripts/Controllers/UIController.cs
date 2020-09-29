using UnityEngine;
using UnityEngine.UI; using System.Collections;
public class UIController : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }
    void OnDestroy()
    {

        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }
 
     
private void OnHealthUpdated()
    {

        Debug.Log("Change the UI!!!!");
        float newX = ((float)Managers.Player.health) / Managers.
        Player.maxHealth;
        Debug.Log(newX);
        healthBar.transform.localScale   = new Vector3(newX,transform.localScale.y,transform.localScale.z);
    }
}