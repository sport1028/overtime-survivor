using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float lifeTime = 1f;

    private TextMeshProUGUI textMesh;
    private Vector3 worldPosition;

    void Awake()
    {
        textMesh =
            GetComponent<TextMeshProUGUI>();
    }

    public void SetDamage(int damage, Vector3 position)
    {
        textMesh.text = damage.ToString();

        worldPosition = position;
    }

    void Update()
    {
        worldPosition += Vector3.up * moveSpeed * Time.deltaTime;

        transform.position = Camera.main.WorldToScreenPoint(worldPosition);

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}