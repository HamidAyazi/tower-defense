using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartingMoney = 150;
    public static int HealthPoint;
    public TMPro.TextMeshProUGUI HudMoney;

    void Start()
    {
        Money = StartingMoney;
        HudMoney.text = Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HudMoney.text = Money.ToString();
    }

}
