using UnityEngine;
using UnityEngine.UI; using System.Collections;
public class UIController : MonoBehaviour
{
    [SerializeField] private Text healthLabel;

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
        string message = "Health: " + Managers.Player.health + "/" + Managers.
        Player.maxHealth; healthLabel.text = message;
    }
}