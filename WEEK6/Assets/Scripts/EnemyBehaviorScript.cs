using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int health = 100;
    public GameObject deathEffect;
    private PlayerCombat player;
    public int damage;
    public int playerDamage;
  

    public void TakeDamages(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (player != null)
        {
            player.AddScore(2);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCombat>();

        Vector2 direction = Vector2.down;

        float angle = Random.Range(-45f, 45f);
      
        direction = Quaternion.Euler(0, 0, angle) * direction;

        float randomSpeed = Random.Range(0.2f, 3f) * speed;

 
        Vector2 perpendicular = new Vector2(-direction.y, direction.x);
        float randomForce = Random.Range(-1f, 1f) * randomSpeed;
        Vector2 forceVector = perpendicular * randomForce;
        rb.AddForce(forceVector);


        rb.velocity = direction.normalized * randomSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Vector2 direction = Vector2.down;

            float angle = Random.Range(-45f, 45f);

            direction = Quaternion.Euler(0, 0, angle) * direction;

            float randomSpeed = Random.Range(0.5f, 1f) * speed;

            Vector2 perpendicular = new Vector2(-direction.y, direction.x);
            float randomForce = Random.Range(-1f, 1f) * randomSpeed;
            Vector2 forceVector = perpendicular * randomForce;
            rb.AddForce(forceVector);

            rb.velocity = direction.normalized * randomSpeed;
        }

        PlayerScript player = other.GetComponent<PlayerScript>();
        if (player != null)
        {   
            player.TakeDamage(damage);
            Destroy(gameObject);
        }


    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

