using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    public int life;
    public GameObject prefab;

    public void LifeChange(int value)
    {
        life -= value;
        if(life <= 0)
        {
            Destroy(prefab);
        }
    }
}
