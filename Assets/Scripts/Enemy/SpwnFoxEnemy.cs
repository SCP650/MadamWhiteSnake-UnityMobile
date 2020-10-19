using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnFoxEnemy : MonoBehaviour
{
    [SerializeField] GameObject FoxEnemy;

    [SerializeField] float spawnTime = 2;

    private Transform player;
    void Start()
    {

        float ScreenHeight = 2 * Camera.main.orthographicSize;
        float ScreenWidth = ScreenHeight * Camera.main.aspect;

        float left = -ScreenWidth / 2 + 30;
        player = GameObject.Find("PlayerCharacter").transform;

        transform.localPosition = new Vector3(left, transform.localPosition.y, transform.localPosition.z);
        StartCoroutine(SpawnEnemy());

    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float wait = Random.Range(spawnTime - 2, spawnTime + 2);
            GameObject gb= Instantiate(FoxEnemy);
            gb.transform.position = transform.position;
            yield return new WaitForSeconds(wait);
        }
    }

}
