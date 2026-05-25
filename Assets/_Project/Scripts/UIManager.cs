using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI waveText;

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
}