using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed;
    private float destroyDelay = 2f;
    private Rigidbody2D balarb;


    private void Awake()
    {
        balarb = GetComponent<Rigidbody2D>();
    }
    public void LanzarBala(Vector2 direction)
    {
        balarb.velocity = direction * speed;
        Destroy(gameObject, destroyDelay);
    }
    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
