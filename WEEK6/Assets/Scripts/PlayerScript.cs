using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float speed = 15f;
    public int health;
    public GameObject deathEffect;
    public TextMeshProUGUI shipHealthtext;



    void Start()
    {
     
    }
    // Update is called once per frame
    void Update()
    {
       


        float inputhorizontal = Input.GetAxisRaw("Horizontal");
        float inputvertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(inputhorizontal, inputvertical, 0) * speed * Time.deltaTime;

        transform.Translate(direction);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), Mathf.Clamp(transform.position.y, -8f, -1f), transform.position.z);
        shipHealthtext.text = "Health: " + health.ToString();
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
