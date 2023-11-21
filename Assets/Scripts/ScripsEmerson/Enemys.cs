    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageValue = 1;

    private Spawner spawner;

    public float speed = 3f;
    public float detectionRadius = 5f;
    private Transform player;
    private bool playerDetected = false;

    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();

        if (spawner == null)
        {
            Debug.LogError("No se encontró el script del spawner.");
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("No se encontró el objeto del jugador con la etiqueta 'Player'");
        }
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < detectionRadius)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }

        if (playerDetected)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        spawner.EnemyDied();
    }
}



