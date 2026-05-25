using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject expGemPrefab;
    public float moveSpeed = 2f;
    public int damage = 1;
    public int maxHp = 3;
    public int expReward = 1;

    private Transform player;
    private int currentHp;

    void Start()
    {
        currentHp = maxHp;

        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction =
            (player.position - transform.position).normalized;

        transform.position +=
            (Vector3)(direction * moveSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player =
                collision.gameObject
                    .GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject gem = Instantiate(
            expGemPrefab,
            transform.position,
            Quaternion.identity
        );

        gem.GetComponent<ExpGem>()
            .expAmount = expReward;

        Destroy(gameObject);
    }
}
