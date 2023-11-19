using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoEspecial : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float DistanciaMin;
    [SerializeField] private GameObject enemys;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        player.GetComponent<MovePlayer>().canMove = false;
        enemys.GetComponent<MoveVegatables>().MoveRandom = false;
        enemys.GetComponent<MoveVegatables>().Follow = false;
    }
}
