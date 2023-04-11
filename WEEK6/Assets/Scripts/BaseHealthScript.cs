using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseHealthScript : MonoBehaviour
{
    public int health; //base health
    public TextMeshProUGUI healthText;

    void Update()
    {   
        //display remaining health in the gamescene UI
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
            SceneManager.LoadScene(3);
        }
 
    }
}
