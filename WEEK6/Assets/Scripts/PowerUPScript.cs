using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPScript : MonoBehaviour
{

    public float speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

}
