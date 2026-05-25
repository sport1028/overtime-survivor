using UnityEngine;

public class ExpGem : MonoBehaviour
{
    public int expAmount = 1;

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