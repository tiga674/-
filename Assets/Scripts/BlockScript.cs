using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlockScript : MonoBehaviour
{
    Renderer blockRenderer;

    void Start()
    {
        blockRenderer = GetComponent<Renderer>();
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            blockRenderer.material.color = Color.white;
            this.tag = "floor";
        }
    }
}
