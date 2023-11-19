using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public float DistancePlayer;
    [SerializeField] private Transform player;

    [SerializeField] public float DistanciaMin;
    [SerializeField] public float Speed;
    void Update()
    {
        DistancePlayer = Vector2.Distance(transform.position, player.position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DistanciaMin);
    }
    public void followPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
    }
}
