using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucharon : MonoBehaviour
{
    
    public float fuerzaLanzamiento;
    private float destroyDelay = 2f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LanzarBala(Vector2 direction)
    {
        rb.velocity = direction * fuerzaLanzamiento;
        Destroy(gameObject, destroyDelay);
    }

    private void OnCollisionEnter2D()
    {   
        Destroy(gameObject);
    }

}
