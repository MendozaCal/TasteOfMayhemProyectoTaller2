using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveVegetables : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector2 RandomPosition;
    private float Distance = 2f;
    private Vector2 InicialPoint;
    private float timer = 0;
    private GameObject player;
    [SerializeField] public bool Follow = true;
    [SerializeField] public bool MoveRandom = true;
    private void Start()
    {
        InicialPoint = transform.position;
        Direccion();
        player = GameObject.FindWithTag("Player");
    }
    private void Direccion()
    {
        float X = Random.Range(-5, 5);
        float Y = Random.Range(-5, 5);
        Vector2 RandomValue = new Vector2(X, Y);
        RandomPosition = InicialPoint + RandomValue * Distance;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (player.GetComponent<MovePlayer>().canMove == false) 
        {
            Follow = false;
            if (Follow != true && MoveRandom == true)  
            {
                StartCoroutine(VegetablesMove());
                Movee();
            }
        }
        if (gameObject.GetComponent<EnemyFollow>().DistancePlayer < gameObject.GetComponent<EnemyFollow>().DistanciaMin && gameObject.CompareTag("EnemyFollow"))
        {
            if (Follow == true)
            {
                gameObject.GetComponent<EnemyFollow>().followPlayer();
            }
        }
        else
        {
            if (MoveRandom == true)
            {
                Movee();
            }
            else
            {
                StartCoroutine(VegetablesMove());
            }
        }
    }
    private void Movee()
    {      
            transform.position = Vector2.MoveTowards(transform.position, RandomPosition, Speed * Time.deltaTime);
            if (timer > 2)
            {
                if (Vector2.Distance(transform.position, InicialPoint) > 0.1f)
                {
                    timer = 0;
                    Direccion();
                }
                if (Vector2.Distance(transform.position, RandomPosition) < 0.1f)
                {
                    timer = 0;
                    Direccion();
                }
            }
    }
    IEnumerator VegetablesMove()
    {
        if (MoveRandom != true && Follow == true)
        {
            yield return new WaitForSeconds(5);
            Follow = true;
            MoveRandom = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cucharon"))
        {
            Follow = false;
            MoveRandom = false;
        }
    }
}   

