using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct PowerUpKinds
{
    public const int EMPTY =-1;
    public const int MORE_HEALTH = 0;
    public const int SPEED_UP = 1;
    public const int FIRE_BOMB = 2;

}

public class PowerupController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ParticleSystem healthParticle;
    [SerializeField] Button releasePowerup;
    [SerializeField] GameObject furnianceAnimation;
    [Tooltip("Refer to PowerUpKinds for index")]
    [SerializeField] Sprite[] icons;
    [SerializeField] Image secondPowerImg;
    [SerializeField] GameObject FireBombPrefb;
    [SerializeField] Sprite EmptySprite;


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
            secondPowerImg.sprite = icons[secondPower];
            secondPowerImg.gameObject.SetActive(true);
        }

    }

    private IEnumerator ChangeUIIcon(Sprite sprite )
    {
        releasePowerup.gameObject.SetActive(true);
        furnianceAnimation.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        furnianceAnimation.SetActive(false);
        powerIcon.sprite = sprite;

    }

    public void TriggerPower()
    {
        if(firstPower != PowerUpKinds.EMPTY)
        {
            StartCoroutine(ImplementPower(firstPower));
            firstPower = secondPower;
            secondPower = PowerUpKinds.EMPTY;
            secondPowerImg.gameObject.SetActive(false);

            if (firstPower == PowerUpKinds.EMPTY)
            {
                powerIcon.sprite = EmptySprite;
                releasePowerup.gameObject.SetActive(false);
            }
            else
            {
                powerIcon.sprite = icons[firstPower];
            }
           
        }
    }



    private int GetPower()
    {
        int i = Random.Range(1, icons.Length+1);
        i = 2;//for testing
        switch (i)
        {
            case 1:
                return PowerUpKinds.MORE_HEALTH;
            case 2:
                return PowerUpKinds.SPEED_UP;
            case 3:
                return PowerUpKinds.FIRE_BOMB;
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
                player.GetComponent<PlayerViewHoriMove>().IncreaseSpeedBy(1.5f);
                yield return new WaitForSeconds(5);
                player.GetComponent<PlayerViewHoriMove>().ResetSpeed();
                break;
            case PowerUpKinds.FIRE_BOMB:
                GameObject gb = Instantiate(FireBombPrefb);
                gb.transform.position = player.transform.position;
                gb.transform.Rotate(0, 0, 45);
                break;
            default:
                Debug.Log("Empty Power up");
                break;
        }
       
    }
}
