using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int initialNumberOfEnemies = 5;
    public float spawnRadius = 10f;

    void Start()
    {
        SpawnEnemies(initialNumberOfEnemies);
    }

    void SpawnEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Instantiate(enemyPrefab, new Vector3(randomPosition.x, randomPosition.y, 0f), Quaternion.identity);
        }
    }

    public void EnemyDied()
    {
        Invoke("SpawnSingleEnemy", 1f);
    }

    void SpawnSingleEnemy()
    {
        SpawnEnemies(1);
    }
}








