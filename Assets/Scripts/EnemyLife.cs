using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private int life;

    public Ingrediente ingredienteAsociado; // Asigna Inspector
    public JugadorHud jugadorHud;

    private void ChangeLife(int value)
    {
        life += value;
        if (life <= 0)
        {
            Destroy(gameObject);

            // Llamar al método AsesinarEnemigoAsociado del script JugadorHud cuando el enemigo muere
            if (ingredienteAsociado != null)
            {
                jugadorHud.AsesinarEnemigoAsociado(ingredienteAsociado);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            ChangeLife(-collision.gameObject.GetComponent<Damage>().GetDamage());
            Destroy(collision.gameObject);
        }
    }
}
