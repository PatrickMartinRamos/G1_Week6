using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;  // The speed of the bullet
    public Rigidbody2D rb;  // The Rigidbody2D component attached to the bullet
    public int damage;  // The amount of damage the bullet deals

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;  // Set the velocity of the bullet to its transform's up direction multiplied by the speed
    }

    // This function is called when the object becomes invisible
    void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destroy the game object when it becomes invisible
    }

    // This function is called when the object collides with another object with a trigger collider
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object the bullet collided with has an EnemyBehaviorScript component attached to it
        EnemyBehaviorScript enemy = collision.GetComponent<EnemyBehaviorScript>();

        // Check if the object the bullet collided with has a "Border" tag
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);  // Destroy the bullet game object
        }

        if (enemy != null)
        {
            enemy.TakeDamages(damage);  // Call the TakeDamages function of the enemy to deal damage to it
            Destroy(gameObject);  // Destroy the bullet game object
        }

        // Check if the object the bullet collided with has an EnemyType2 component attached to it
        EnemyType2 enemytype2 = collision.GetComponent<EnemyType2>();

        if (enemytype2 != null)
        {
            enemytype2.TakeDamages(damage);  // Call the TakeDamages function of the enemy to deal damage to it
            Destroy(gameObject);  // Destroy the bullet game object
        }

        // Check if the object the bullet collided with has an EnemyType3 component attached to it
        EnemyType3 enemytype3 = collision.GetComponent<EnemyType3>();

        if (enemytype3 != null)
        {
            enemytype3.TakeDamages(damage);  // Call the TakeDamages function of the enemy to deal damage to it
            Destroy(gameObject);  // Destroy the bullet game object
        }
    }
}
