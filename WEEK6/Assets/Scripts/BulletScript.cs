using UnityEngine;


public class BulletScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage;

    //public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviorScript enemy = collision.GetComponent<EnemyBehaviorScript>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
