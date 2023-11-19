using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjiExplosion : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public float DistanciaMin;
    private void ExplosionFire()
    {
        Vector2 OrigenRaycast = transform.position;
        Vector2 DireccionRycast = ((Vector2)player.position - OrigenRaycast).normalized;
        RaycastHit2D HitImformation = Physics2D.Raycast(OrigenRaycast, DireccionRycast, DistanciaMin);
        if (HitImformation.collider != null)
        {
            player.GetComponent<ShootMouse>().enabled = false;
        }
    }
    private void OnDestroy()
    {
        ExplosionFire();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}