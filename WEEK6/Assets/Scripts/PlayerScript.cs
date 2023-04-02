using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputhorizontal = Input.GetAxisRaw("Horizontal");
        float inputvertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(inputhorizontal, inputvertical, 0) * speed* Time.deltaTime;

        transform.Translate(direction);
    }
}
