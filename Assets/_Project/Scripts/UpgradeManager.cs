using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public GameObject levelUpPanel;

    private PlayerController player;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player =
            FindFirstObjectByType<PlayerController>();
    }

    public void ShowLevelUp()
    {
        levelUpPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void UpgradeAttackSpeed()
    {
        player.attackInterval -= 0.1f;

        if (player.attackInterval < 0.2f)
        {
            player.attackInterval = 0.2f;
        }

        CloseLevelUp();
    }

    public void UpgradeMoveSpeed()
    {
        player.moveSpeed += 1f;

        CloseLevelUp();
    }

    public void UpgradeDamage()
    {
        player.bulletDamage += 1;
        CloseLevelUp();
    }

    void CloseLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpgradeMultiShot()
    {
        player.shotCount += 2;

        if (player.shotCount > 7)
        {
            player.shotCount = 7;
        }

        CloseLevelUp();
    }
}