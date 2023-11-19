using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMouse : MonoBehaviour
{
    public GameObject knifePrefab; // Prefab del cuchillo.
    public GameObject ladlePrefab; // Prefab del cucharón.
    public Transform firePoint; // Punto de origen del disparo.

    public float knifeSpeed = 10f; // Velocidad del cuchillo.
    public float ladleSpeed = 5f; // Velocidad del cucharón.

    public float knifeCooldown = 0.5f; // Tiempo de recarga para el cuchillo.
    public float ladleCooldown = 2f; // Tiempo de recarga para el cucharón.

    private float knifeTimer = 0f; // Temporizador para el cuchillo.
    private float ladleTimer = 0f; // Temporizador para el cucharón.

    // Capas a las que pertenece el jugador (ajustar según sea necesario).
    public LayerMask playerLayer;

    void Update()
    {
        // Actualizar los temporizadores.
        knifeTimer += Time.deltaTime;
        ladleTimer += Time.deltaTime;

        // Obtener la dirección en la que el jugador está apuntando.
        Vector3 shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // Disparar cuchillo al presionar el botón de disparo.
        if (Input.GetButtonDown("Fire1") && knifeTimer >= knifeCooldown) // Puedes ajustar el botón según tu configuración.
        {
            ShootKnife(shootDirection);
            knifeTimer = 0f; // Reiniciar el temporizador para el cuchillo.
        }

        // Disparar cucharón al presionar otro botón de disparo.
        if (Input.GetButtonDown("Fire2") && ladleTimer >= ladleCooldown) // Puedes ajustar el botón según tu configuración.
        {
            ShootLadle(shootDirection);
            ladleTimer = 0f; // Reiniciar el temporizador para el cucharón.
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

        // Calcular el ángulo de rotación basado en la dirección del disparo.
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        // Rotar el cuchillo en la dirección del disparo.
        knife.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Aplicar velocidad al cuchillo en la dirección del disparo.
        rb.velocity = shootDirection * knifeSpeed;

        // Destruir el cuchillo después de un tiempo (ajustar según sea necesario).
        Destroy(knife, 2f);
    }

    void ShootLadle(Vector3 shootDirection)
    {
        // Instanciar un cucharón en el punto de disparo.
        GameObject ladle = Instantiate(ladlePrefab, firePoint.position, Quaternion.identity);

        // Ignorar colisiones con el jugador.
        Physics2D.IgnoreCollision(ladle.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        // Obtener el componente Rigidbody2D del cucharón.
        Rigidbody2D rb = ladle.GetComponent<Rigidbody2D>();

        // Configurar el cucharón como "Trigger".
        ladle.GetComponent<Collider2D>().isTrigger = true;

        // Calcular el ángulo de rotación basado en la dirección del disparo.
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        // Rotar el cucharón en la dirección del disparo.
        ladle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Aplicar velocidad al cucharón en la dirección del disparo.
        rb.velocity = shootDirection * ladleSpeed;

        // Destruir el cucharón después de un tiempo (ajustar según sea necesario).
        Destroy(ladle, 2f);
    }
}
