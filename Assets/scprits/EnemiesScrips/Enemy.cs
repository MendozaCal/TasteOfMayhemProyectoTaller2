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
    public float velocidad = 2.0f;
    private bool comportamientoNormal = true;
    [SerializeField] private float duracionAturdimiento = 20f;
    [SerializeField] private float tiempoAturdimiento = 0.0f;
    private Vector3 posicionInicial;

    private void Start()
    {
        {
            posicionInicial = transform.position;
        }
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
        if (comportamientoNormal)
        {
            //izquierda a derecha
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);

            // Cambiar de dirección
            if (transform.position.x > 5.0f)
            {
                velocidad = -Mathf.Abs(velocidad);
                transform.localScale = new Vector3(-1, 1, 1); // Voltear sprite
            }
            else if (transform.position.x < -5.0f)
            {
                velocidad = Mathf.Abs(velocidad);
                transform.localScale = new Vector3(1, 1, 1); // escala del sprite
            }
        }
        else
        {
            // está aturdido
            tiempoAturdimiento += Time.deltaTime;
            if (tiempoAturdimiento >= duracionAturdimiento)
            {
                // Restaurar el comportamiento normal 
                comportamientoNormal = true;
                tiempoAturdimiento = 0;
                velocidad = 2.0f;
                transform.position = posicionInicial;

            }
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
    }

    public void Aturdir()
    {
        // Iniciar aturdimiento
        comportamientoNormal = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cucharon"))
        {
            Aturdir();
        }
        if (collision.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        spawner.EnemyDied();
    }
}
