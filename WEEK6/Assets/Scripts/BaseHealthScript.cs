using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseHealthScript : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public TextMeshProUGUI healthText;
    public Image healthBar;

    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        //display remaining health in the gamescene UI
        healthText.text = "Base Health: " + health.ToString();
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
            SceneManager.LoadScene(3);
        }
 
    }
}
