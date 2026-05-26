using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI waveText;
    public Slider bossHpBar;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateHp(int currentHp, int maxHp)
    {
        hpText.text =
            "HP : " + currentHp + " / " + maxHp;
    }

    public void UpdateLevel( int level, int currentExp, int maxExp)
    {
        levelText.text =
            "LV " + level +
            "\nEXP " + currentExp +
            " / " + maxExp;
    }

    public void UpdateWave(int wave)
    {
        waveText.text = "WAVE " + wave;
    }

    public void ShowBossHpBar(int maxHp)
    {
        bossHpBar.gameObject.SetActive(true);

        bossHpBar.maxValue = maxHp;

        bossHpBar.value = maxHp;
    }

    public void UpdateBossHp(int currentHp)
    {
        bossHpBar.value = currentHp;
    }

    public void HideBossHpBar()
    {
        bossHpBar.gameObject.SetActive(false);
    }
}