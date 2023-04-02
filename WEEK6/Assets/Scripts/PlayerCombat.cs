using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //public Transform FirePoint_1;
    public Transform FirePoint_2;
   // public Transform FirePoint_3;
    public GameObject bulletprefab;
    //public Animator animator;
    // Start is called before the first frame update
    public float Shootinginterval;
    public float startTimeshots;

    // Update is called once per frame
    void Update()
    {
        if(Shootinginterval <= 0)
        {
            Instantiate(bulletprefab, FirePoint_2.position, FirePoint_2.rotation);
            Shootinginterval = startTimeshots;
        }
        else
        {
            Shootinginterval -= Time.deltaTime;
        }
    }
}
