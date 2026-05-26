using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;

    public float spawnInterval = 2f;

    public float spawnDistance = 10f;

    public int currentWave = 1;

    public float waveDuration = 20f;

    private float waveTimer;

    private Transform player;

    private float timer;


    void Start()
    {
        player = GameObject.Find("Player").transform;
        UIManager.Instance.UpdateWave(currentWave);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }

        waveTimer += Time.deltaTime;

        if (waveTimer >= waveDuration)
        {
            NextWave();

            waveTimer = 0f;
        }
    }

    void NextWave()
    {
        currentWave++;

        if (currentWave % 5 == 0)
        {
            SpawnBoss();
        }

        spawnInterval *= 0.9f;

        if (spawnInterval < 0.3f)
        {
            spawnInterval = 0.3f;
        }

        Debug.Log("WAVE " + currentWave);

        UIManager.Instance.UpdateWave(currentWave);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        Vector2 randomDirection =
            Random.insideUnitCircle.normalized;

        Vector2 spawnPosition =
            (Vector2)player.position +
            randomDirection * spawnDistance;

        GameObject selectedEnemy;

        float randomValue = Random.value;

        if (currentWave < 3)
        {
            selectedEnemy = enemyPrefabs[0];
        }
        else
        {
            if (randomValue < 0.7f)
            {
                selectedEnemy = enemyPrefabs[0];
            }
            else
            {
                selectedEnemy = enemyPrefabs[1];
            }
        }

        Instantiate(
            selectedEnemy,
            spawnPosition,
            Quaternion.identity
        );
    }

    void SpawnBoss()
    {
        if (player == null) return;

        Vector2 spawnPosition =
            (Vector2)player.position +
            Random.insideUnitCircle.normalized
            * spawnDistance;

        Instantiate(
            bossPrefab,
            spawnPosition,
            Quaternion.identity
        );

        Debug.Log("BOSS SPAWN!");

        AudioManager.Instance.PlaySFX(
            AudioManager.Instance.bossClip
        );
    }
}