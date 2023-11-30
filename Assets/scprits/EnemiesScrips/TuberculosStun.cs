using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuberculosStun : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<MovePlayer>().canMove = false;
        }
    }
}