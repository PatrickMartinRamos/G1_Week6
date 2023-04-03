using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    public int health = 2;

    public void baseDamage(int baseDamage)
    {
        health -= baseDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
