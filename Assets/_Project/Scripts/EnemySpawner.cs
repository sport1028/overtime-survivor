using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnInterval = 2f;

    public float spawnDistance = 10f;

    private Transform player;

    private float timer;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        Vector2 randomDirection =
            Random.insideUnitCircle.normalized;

        Vector2 spawnPosition =
            (Vector2)player.position +
            randomDirection * spawnDistance;

        Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}