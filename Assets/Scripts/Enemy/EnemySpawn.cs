using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject JumpingEnemy;

    [SerializeField] float spawnTime = 2;
    void Start()
    {

        float ScreenHeight = 2 * Camera.main.orthographicSize;
        float ScreenWidth = ScreenHeight * Camera.main.aspect;
        float width = 0.5f;
        float left = -ScreenWidth / 2 - width / 2;
       
        transform.localPosition = new Vector3(left, transform.localPosition.y, transform.localPosition.z);
        StartCoroutine(SpawnEnemy());

    }

    IEnumerator SpawnEnemy()
    {

        while (true)
        {
           
            GameObject enemy = Instantiate(JumpingEnemy);
            enemy.transform.position = transform.position;
            yield return new WaitForSeconds(spawnTime);
            //yield return null;
        }
         
    }





}
