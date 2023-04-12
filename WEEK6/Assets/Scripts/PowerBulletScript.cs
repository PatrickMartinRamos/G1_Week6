using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBulletScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage;
    public GameObject impactEffect;

    void Start()
    {
        //bullet speed
        rb.velocity = transform.up * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object the bullet collided with has an EnemyBehaviorScript component attached to it
        EnemyBehaviorScript enemy = collision.GetComponent<EnemyBehaviorScript>();

        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);  // Destroy the bullet game object
        }

        if (enemy != null)
        {
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            // Call the TakeDamages function of the enemy to deal damage to it
            enemy.TakeDamages(damage);
            Destroy(gameObject);
        }

        // Check if the object the bullet collided with has an EnemyType2 component attached to it
        EnemyType2 enemytype2 = collision.GetComponent<EnemyType2>();

        if (enemytype2 != null)
        {
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            enemytype2.TakeDamages(damage);  // Call the TakeDamages function of the enemy to deal damage to it
            Destroy(gameObject);
        }

        // Check if the object the bullet collided with has an EnemyType3 component attached to it
        EnemyType3 enemytype3 = collision.GetComponent<EnemyType3>();

        if (enemytype3 != null)
        {
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            enemytype3.TakeDamages(damage);  // Call the TakeDamages function of the enemy to deal damage to it
            Destroy(gameObject);
        }
    }
}
