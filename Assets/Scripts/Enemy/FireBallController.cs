using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] float baseSpeed;
    [SerializeField] AudioClip playJiao;

    // Update is called once per frame
    void Update()
    {
        baseSpeed += 2f * Time.deltaTime;
        baseSpeed = Mathf.Clamp(baseSpeed, 5, 16);
        transform.position = new Vector3(transform.position.x + baseSpeed * Time.deltaTime, transform.position.y, transform.position.z);

    }

  
    void OnTriggerEnter2D(Collider2D collision)
    {
        string whatHitMe = collision.gameObject.tag;
        if (whatHitMe == "PlayerHitbox")
        {

            Managers.Player.ChangeHealth(-5);
            Managers.Player.ChangeScore(-50);
            Managers.Audio.PlaySound(playJiao);
        }

        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
