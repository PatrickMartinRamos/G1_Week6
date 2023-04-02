using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemySpawn;
    public Transform spawnPoint;
    public float spawninterval;
    public float startSpawn;

    private static int enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawninterval <= 0)
        {
            Instantiate(enemySpawn, spawnPoint.position, spawnPoint.rotation);
            spawninterval = startSpawn;
        }
        else
        {
            spawninterval -= Time.deltaTime;
        }
    }
}
