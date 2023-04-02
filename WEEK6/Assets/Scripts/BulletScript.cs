using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage = 2;

    //public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    public void OnTriggerEnter2D(Collider2D hitenemies)
    {
        if (hitenemies.gameObject.CompareTag("Enemy"))
        {
            EnemyBehaviorScript enemy = hitenemies.GetComponent<EnemyBehaviorScript>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
