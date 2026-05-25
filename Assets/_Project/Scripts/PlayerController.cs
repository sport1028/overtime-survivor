using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float attackInterval = 1f;
    public int maxHp = 10;
    public int level = 1;
    public int currentExp = 0;
    public int maxExp = 5;

    private float attackTimer;
    private Rigidbody2D rb;
    private Vector2 movement;
    private int currentHp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        UIManager.Instance.UpdateHp(currentHp, maxHp);
        UIManager.Instance.UpdateLevel(level, currentExp, maxExp);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            AutoAttack();
            attackTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }

    void AutoAttack()
    {
        EnemyController nearestEnemy = FindNearestEnemy();

        if (nearestEnemy == null) return;

        Vector2 direction =
            (nearestEnemy.transform.position - transform.position)
            .normalized;

        GameObject bullet = Instantiate(
            bulletPrefab,
            transform.position,
            Quaternion.identity
        );

        bullet.GetComponent<BulletController>()
            .Init(direction);
    }

    EnemyController FindNearestEnemy()
    {
        EnemyController[] enemies =
            FindObjectsByType<EnemyController>(
                FindObjectsSortMode.None
            );

        EnemyController nearest = null;

        float minDistance = Mathf.Infinity;

        foreach (EnemyController enemy in enemies)
        {
            float distance =
                Vector2.Distance(
                    transform.position,
                    enemy.transform.position
                );

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }

        return nearest;
    }


    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        Debug.Log("Player HP : " + currentHp);
        UIManager.Instance.UpdateHp(currentHp, maxHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GAME OVER");

        gameObject.SetActive(false);
    }

    public void AddExp(int amount)
    {
        currentExp += amount;

        if (currentExp >= maxExp)
        {
            LevelUp();
        }

        UIManager.Instance.UpdateLevel(
            level,
            currentExp,
            maxExp
        );
    }

    void LevelUp()
    {
        level++;

        currentExp = 0;

        maxExp += 5;

        moveSpeed += 0.5f;

        Debug.Log("LEVEL UP!");

        UIManager.Instance.UpdateLevel(
            level,
            currentExp,
            maxExp
        );
    }
}
