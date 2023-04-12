using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed = 15f;
    public float health;
    public float maxHealth;
    public GameObject deathEffect;
    public TextMeshProUGUI shipHealthtext;
    public Image healthBar;


    void Start()
    {
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);


        float inputhorizontal = Input.GetAxisRaw("Horizontal");
        float inputvertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(inputhorizontal, inputvertical, 0) * speed * Time.deltaTime;

        transform.Translate(direction);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), Mathf.Clamp(transform.position.y, -8f, -1f), transform.position.z);
        shipHealthtext.text = "Ship Health: " + health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
   
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            SceneManager.LoadScene(3);
        }
    }
}
