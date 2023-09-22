using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    // UI elements
    public TMPro.TextMeshProUGUI HudMoney;
    public TMPro.TextMeshProUGUI HudHealth;
    public TMPro.TextMeshProUGUI HudWave;
    
    // Logic elements
    [NonSerialized] public static int Money;
    [NonSerialized] public static int HealthPoint;
    [NonSerialized] public static int Wave;

    private int StartingMoney = 250;
    private int StartingHealth = 30;

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
