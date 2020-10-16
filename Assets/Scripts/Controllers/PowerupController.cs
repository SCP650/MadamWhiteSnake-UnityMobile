using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct PowerUpKinds
{
    public const int EMPTY =-1;
    public const int MORE_HEALTH = 0;
    public const int SPEED_UP = 1; 

}

public class PowerupController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ParticleSystem healthParticle;
    [SerializeField] Button releasePowerup;
    [Tooltip("Refer to PowerUpKinds for index")]
    [SerializeField] Sprite[] icons;
   


    private int firstPower;
    private int secondPower;
    private Image powerIcon;
  

    private void Awake()
    {
        Messenger.AddListener(PowerupEvent.PICKUP_POWERUP, PickupPowerup);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(PowerupEvent.PICKUP_POWERUP, PickupPowerup);
    }
    private void Start()
    {
        firstPower = PowerUpKinds.EMPTY;
        secondPower = PowerUpKinds.EMPTY;
        releasePowerup.gameObject.SetActive(false);
        powerIcon = releasePowerup.GetComponent<Image>();
      
    }
    private void PickupPowerup()
    {

        if(firstPower == PowerUpKinds.EMPTY)
        {
            firstPower = GetPower();
            StartCoroutine(ChangeUIIcon(icons[firstPower]));
        }
        else if(secondPower == PowerUpKinds.EMPTY)
        {
            secondPower = GetPower();
        }

    }

    private IEnumerator ChangeUIIcon(Sprite sprite )
    {
        releasePowerup.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        powerIcon.sprite = sprite;
    }

    public void TriggerPower()
    {
        if(firstPower != PowerUpKinds.EMPTY)
        {
            StartCoroutine(ImplementPower(firstPower));
            firstPower = secondPower;
            secondPower = PowerUpKinds.EMPTY;
            if(firstPower == PowerUpKinds.EMPTY)
            {
                releasePowerup.gameObject.SetActive(false);
            }
        }
    }



    private int GetPower()
    {
        int i = Random.Range(1, 3);
        switch (i)
        {
            case 1:
                return PowerUpKinds.MORE_HEALTH;
            case 2:
                return PowerUpKinds.SPEED_UP;
            default:
                return PowerUpKinds.EMPTY;//this should not happen
        }
    }

    private IEnumerator ImplementPower(int power)
    {
        switch (power)
        {
            case PowerUpKinds.MORE_HEALTH:
                healthParticle.Play();
                Managers.Player.ChangeHealth(20);
                break;
            case PowerUpKinds.SPEED_UP:
                player.GetComponent<PlayerViewHoriMove>().speed *= 1.5f;
                yield return new WaitForSeconds(5);
                player.GetComponent<PlayerViewHoriMove>().speed *= 1 / 1.5f;
                break;
            default:
                Debug.Log("Empty Power up");
                break;
        }
       
    }
}
