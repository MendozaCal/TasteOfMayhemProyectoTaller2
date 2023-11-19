using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private float shootTimer;
    [SerializeField]
    private float timeDelay;

    private Vector2 direction;

    private void Awake()
    {
        direction = Vector2.up;
    }

    private void Update()
    {
        Shooting();
        Timer();
        SetDirection();
    }

    public void Timer()
    {
        shootTimer += Time.deltaTime;
    }

    public void SetDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            direction = new Vector2(horizontal, vertical);
        }
    }

    public void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shootTimer >= timeDelay)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            obj.gameObject.GetComponent<Bullet>().GetDirection(direction);
            shootTimer = 0;
        }
    }
}
