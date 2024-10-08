using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int spawnTimer = 10;
    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(spawnTimer);
        Instantiate(enemy, transform.position, Quaternion.identity) ;
        StartCoroutine(spawnEnemy());
    }
}
