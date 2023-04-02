using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_StarScript : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Renderer bgrenderer;

    void Update()
    {
        bgrenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
