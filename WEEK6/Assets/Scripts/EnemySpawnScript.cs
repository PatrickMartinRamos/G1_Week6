using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 1.0f; // Set in Inspector

    void Start()
    {
        StartCoroutine(SpawnEnemies());     // start the SpawnEnemies coroutine when the game starts
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);          // choose a random enemy prefab from the enemyPrefabs array
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);      // choose a random spawn point from the spawnPoints array
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);   // spawn an enemy at the chosen spawn point with a random enemy prefab
            yield return new WaitForSeconds(spawnInterval);               // wait for the specified spawn interval before spawning another enemy
        }
    }   
}
