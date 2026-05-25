using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI levelText;

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
}