using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;

    private void Update()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            BaseHealth(1); // Deduct one health from BorderScript
        }
    }

    public void BaseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Destroy");
            // Instantiate(deathEffect, transform.position, Quaternion.identity);
            // Destroy(gameObject);
        }
 
    }
}
