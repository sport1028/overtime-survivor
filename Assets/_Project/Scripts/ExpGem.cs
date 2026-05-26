using UnityEngine;

public class ExpGem : MonoBehaviour
{

    public int expAmount = 1;
    public float moveSpeed = 8f;

    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
    void Update()
    {
        if (player == null) return;

        float distance =
            Vector2.Distance(
                transform.position,
                player.position
            );

        PlayerController playerController = player.GetComponent<PlayerController>();

        if (distance <= playerController.magnetRange)
        {
            transform.position =
                Vector2.MoveTowards(
                    transform.position,
                    player.position,
                    moveSpeed * Time.deltaTime
                );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player =
                collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.AddExp(expAmount);
            }

            Destroy(gameObject);
        }
    }
}