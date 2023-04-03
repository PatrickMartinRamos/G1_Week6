using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 15f;
    public int health = 5;
    public GameObject deathEffect;

    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

        // Update is called once per frame
    void Update()
        {
            float inputhorizontal = Input.GetAxisRaw("Horizontal");
            float inputvertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(inputhorizontal, inputvertical, 0) * speed * Time.deltaTime;

            transform.Translate(direction);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9f, 9f), Mathf.Clamp(transform.position.y, -8f, -1f), transform.position.z);
    }
}