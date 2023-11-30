using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomateStuneador : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            Destroy(gameObject);

        }
    }
    private void Stun()
    {
        player.GetComponent<MovePlayer>().canMove = false;
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 5,mask);
        foreach (Collider2D c in collider) 
        { 
            MoveVegetables M = c.GetComponent<MoveVegetables>();
            M.Follow = false; M.MoveRandom = false;
        }
    }
}

