using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject JumpingEnemy;

    [SerializeField] float spawnTime = 2;

    private Transform player;
    void Start()
    {

        float ScreenHeight = 2 * Camera.main.orthographicSize;
        float ScreenWidth = ScreenHeight * Camera.main.aspect;
       
        float left = -ScreenWidth / 2 - 12;
        player = GameObject.Find("PlayerCharacter").transform;

        transform.localPosition = new Vector3(left, transform.localPosition.y, transform.localPosition.z);
        StartCoroutine(SpawnEnemy());

    }

    IEnumerator SpawnEnemy()
    {

    
        while (true)
        {

            float PlayerPos = player.position.x;
            int num = Random.Range(1, 100);
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 1.0f)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(PlayerPos + 1, 0)).x);

            float wait = Random.Range(5f, 8f);
  
            //float time = Random.Range(10.0f, 20.0f);
            //ExecuteAfterTime(time);
            GameObject enemy = Instantiate(JumpingEnemy);
            if (num > 50)
            {
                enemy.transform.position = new Vector2(spawnX, spawnY);
            }
            else
            {
                enemy.transform.position = transform.position;
            }

            yield return new WaitForSeconds(wait);
            //yield return null;


        }
    }





}
