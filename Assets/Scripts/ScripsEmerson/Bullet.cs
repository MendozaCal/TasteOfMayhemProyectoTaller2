using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2D;

    [SerializeField]
    private Vector2 direction;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        Move();
    }

    public void GetDirection(Vector2 dirction)
    {
        direction = dirction;
    }

    private void Move()
    {
        rb2D.velocity = direction.normalized * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<LifeEnemy>().LifeChange(1);
            collision.GetComponent<LifeEnemy>().life -= 1;
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
    }
}
