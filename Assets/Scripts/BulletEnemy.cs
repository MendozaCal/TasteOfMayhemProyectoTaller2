using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    Transform Player;
    Rigidbody2D rb;
    [SerializeField]
    private float destroyDelay;

    private void Update()
    {
        Destroy(gameObject, destroyDelay);
    }
    void Start()
    {
        Player = FindAnyObjectByType<MovePlayer>().transform;
        rb = GetComponent<Rigidbody2D>();
        Shoot();
    }
    private void Shoot()
    {
        Vector2 directionPlayer = (Player.position - transform.position).normalized;
        rb.velocity = directionPlayer * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MovePlayer>().Rebote(other.GetContact(0).normal);
            Destroy(gameObject);
            Player.GetComponent<MovePlayer>().isMoving = false;
        }
        if (gameObject.CompareTag("BulletHaba") && other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

    }
}
