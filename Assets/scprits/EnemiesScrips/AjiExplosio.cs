using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AjiExplosio : MonoBehaviour
{
    private GameObject player;
    [SerializeField] public float DistanciaMin;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void ExplosionFire()
    {   
        Vector2 OrigenRaycast = transform.position;
        Vector2 DireccionRycast = ((Vector2)player.transform.position - OrigenRaycast).normalized;
        RaycastHit2D HitImformation = Physics2D.Raycast(OrigenRaycast, DireccionRycast, DistanciaMin);
            if (HitImformation.collider != null)
            {
                   player.GetComponent<ShootMouse>().enabled = false;                
            }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ExplosionFire();
        }
    }
}