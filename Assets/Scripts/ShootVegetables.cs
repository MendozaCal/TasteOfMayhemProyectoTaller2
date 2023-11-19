using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootVegetables : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefap;
    [SerializeField] public float DistanciaMin;
    [SerializeField] public float DistancePlayer;
    [SerializeField] private Transform player;
    float Timerr;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DistanciaMin);
    }
    private void Update()
    {
        DistancePlayer = Vector2.Distance(transform.position, player.position);
        Timerr += Time.deltaTime;
        if (DistancePlayer < DistanciaMin)
        {
            if (Timerr > 1)
            {
                Instantiate(bulletPrefap, transform.position, Quaternion.identity);
                Timerr = 0;
            }
        }
    }
}
