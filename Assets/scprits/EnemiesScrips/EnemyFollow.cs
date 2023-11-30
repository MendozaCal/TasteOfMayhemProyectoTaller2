using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float DistancePlayer;
    private GameObject player;
    [SerializeField] public float DistanciaMin;
    [SerializeField] public float Speed;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        DistancePlayer = Vector2.Distance(transform.position, player.transform.position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DistanciaMin);
    }
    public void followPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
    }
}
