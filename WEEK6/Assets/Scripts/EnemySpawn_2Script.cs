using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn_2Script : MonoBehaviour
{
    public GameObject enemySpawn;
    public Transform spawnPoint;
    public float spawninterval;
    public float startSpawn;
    public float cooldownTimer;
    public float delayBeforeSpawn; // added delay before spawn variable
    private static int enemies;
    private float delayTimer; // added delay timer variable

    void Start()
    {
        delayTimer = delayBeforeSpawn; // initialize delay timer to delay before spawn time
    }

    void Update()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime; // count down delay timer
            return; // exit Update() if still in delay period
        }

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
                spawninterval = cooldownTimer;
                enemies = 0;
            }
        }
        else
        {
            spawninterval -= Time.deltaTime;
        }
    }
}
