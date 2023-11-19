using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMouse : MonoBehaviour
{
    public GameObject knifePrefab; // Prefab del cuchillo.
    public GameObject ladlePrefab; // Prefab del cuchar�n.
    public Transform firePoint; // Punto de origen del disparo.

    public float knifeSpeed = 10f; // Velocidad del cuchillo.
    public float ladleSpeed = 5f; // Velocidad del cuchar�n.

    public float knifeCooldown = 0.5f; // Tiempo de recarga para el cuchillo.
    public float ladleCooldown = 2f; // Tiempo de recarga para el cuchar�n.

    private float knifeTimer = 0f; // Temporizador para el cuchillo.
    private float ladleTimer = 0f; // Temporizador para el cuchar�n.

    // Capas a las que pertenece el jugador (ajustar seg�n sea necesario).
    public LayerMask playerLayer;

    void Update()
    {
        // Actualizar los temporizadores.
        knifeTimer += Time.deltaTime;
        ladleTimer += Time.deltaTime;

        // Obtener la direcci�n en la que el jugador est� apuntando.
        Vector3 shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // Disparar cuchillo al presionar el bot�n de disparo.
        if (Input.GetButtonDown("Fire1") && knifeTimer >= knifeCooldown) // Puedes ajustar el bot�n seg�n tu configuraci�n.
        {
            ShootKnife(shootDirection);
            knifeTimer = 0f; // Reiniciar el temporizador para el cuchillo.
        }

        // Disparar cuchar�n al presionar otro bot�n de disparo.
        if (Input.GetButtonDown("Fire2") && ladleTimer >= ladleCooldown) // Puedes ajustar el bot�n seg�n tu configuraci�n.
        {
            ShootLadle(shootDirection);
            ladleTimer = 0f; // Reiniciar el temporizador para el cuchar�n.
        }
    }

    void ShootKnife(Vector3 shootDirection)
    {
        // Instanciar un cuchillo en el punto de disparo.
        GameObject knife = Instantiate(knifePrefab, firePoint.position, Quaternion.identity);

        // Ignorar colisiones con el jugador.
        Physics2D.IgnoreCollision(knife.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        // Obtener el componente Rigidbody2D del cuchillo.
        Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();

        // Configurar el cuchillo como "Trigger".
        knife.GetComponent<Collider2D>().isTrigger = true;

        // Calcular el �ngulo de rotaci�n basado en la direcci�n del disparo.
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        // Rotar el cuchillo en la direcci�n del disparo.
        knife.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Aplicar velocidad al cuchillo en la direcci�n del disparo.
        rb.velocity = shootDirection * knifeSpeed;

        // Destruir el cuchillo despu�s de un tiempo (ajustar seg�n sea necesario).
        Destroy(knife, 2f);
    }

    void ShootLadle(Vector3 shootDirection)
    {
        // Instanciar un cuchar�n en el punto de disparo.
        GameObject ladle = Instantiate(ladlePrefab, firePoint.position, Quaternion.identity);

        // Ignorar colisiones con el jugador.
        Physics2D.IgnoreCollision(ladle.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        // Obtener el componente Rigidbody2D del cuchar�n.
        Rigidbody2D rb = ladle.GetComponent<Rigidbody2D>();

        // Configurar el cuchar�n como "Trigger".
        ladle.GetComponent<Collider2D>().isTrigger = true;

        // Calcular el �ngulo de rotaci�n basado en la direcci�n del disparo.
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        // Rotar el cuchar�n en la direcci�n del disparo.
        ladle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Aplicar velocidad al cuchar�n en la direcci�n del disparo.
        rb.velocity = shootDirection * ladleSpeed;

        // Destruir el cuchar�n despu�s de un tiempo (ajustar seg�n sea necesario).
        Destroy(ladle, 2f);
    }
}
