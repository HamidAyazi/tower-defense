using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static int Money;
    private int StartingMoney = 150;
    public TMPro.TextMeshProUGUI HudMoney;


    public static int HealthPoint;
    private int StartingHealth = 3;
    public TMPro.TextMeshProUGUI HudHealth;


    public static int Wave;
    public TMPro.TextMeshProUGUI HudWave;

    private void Start()
    {
        Money = StartingMoney;
        HudMoney.text = Money.ToString();

        HealthPoint = StartingHealth;
        HudHealth.text = HealthPoint.ToString();

        Wave = 0;
        HudWave.text = Wave.ToString();
    }

    private void Update()
    {
        HudMoney.text = Money.ToString();
        HudHealth.text = HealthPoint.ToString();
        HudWave.text = Wave.ToString();
    }

}
