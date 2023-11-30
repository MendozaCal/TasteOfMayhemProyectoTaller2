using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public bool canMove = true;
    public bool isMoving = true;
    [SerializeField]
    Vector2 velocityrebound;
    private Animator Playeranimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Playeranimator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if (isMoving)
        {
            StartCoroutine(IStrueStun());
        }
        if (!canMove)
        {
            StartCoroutine(istrueMove());
        }
        if (canMove && isMoving)
        {
            Move();

        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }
    public void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = (new Vector2(moveX, moveY) * speed).normalized;

        Playeranimator.SetFloat("Horizontal", moveX);
        Playeranimator.SetFloat("Vertical", moveY);
        Playeranimator.SetFloat("Speed", moveInput.sqrMagnitude);
    }
    public void Rebote(Vector2 puntoGolpe)
    {
        rb.velocity = new Vector2(velocityrebound.x * puntoGolpe.x, velocityrebound.y * puntoGolpe.y).normalized;
    }
    IEnumerator istrueMove()
    {
        yield return new WaitForSeconds(4);
        canMove = true;
    }
    IEnumerator IStrueStun()  
    {
        yield return new WaitForSeconds(2);
        isMoving = true;
    }
}

