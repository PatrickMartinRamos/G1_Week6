using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject enemySpawn;
    public Transform spawnPoint;
    public float spawninterval;
    public float startSpawn;
    public float cooldownTimer; // new public variable for cooldown timer

    private static int enemies;



    void Update()
    {
        if (spawninterval <= 0)
        {
            if (enemies < 5)
            {
                Instantiate(enemySpawn, spawnPoint.position, spawnPoint.rotation);
                spawninterval = startSpawn;
                enemies++;
            }
            else
            {
                spawninterval = cooldownTimer; // set cooldown timer to public variable
                enemies = 0;
            }
        }
        else
        {
            spawninterval -= Time.deltaTime;
        }
    }
}
