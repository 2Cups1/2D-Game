using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawn;
    

    public GameObject enemyPrefab;
    public GameObject clearerPrefab;
    public Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
        StartCoroutine(SpawnClearerCoroutine());

    }
    
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }

    private void SpawnEnemyClearer()
    {
        Instantiate(clearerPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }
   
    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            SpawnEnemy();
        }
    }

    private IEnumerator SpawnClearerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(15f, 20f));
            SpawnEnemyClearer();
        }
    }


}
