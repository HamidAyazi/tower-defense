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


    // talents
    public static bool speed3x; //
    public static bool infinity;
    public static int bonusCash;
    public static int waveInterval;
    public static int earlyWaveBonusPoint;
    public static float rotationSpeed;
    public static float range;
    public static float ProjectileSpeed;
    public static float damage;
    public static float attackSpeed;
    public static int baseHealth; //
    public static int startingMoney; //
    public static int EnemyDropCoin; //
    public static int maxUpgradeLevel;
    public static int StartingLevel;
    public static float Discount; //
    public static float TowerRefund; //
    // talents

    private void Start()
    {
        TalentTree Talents = SaveManager.Instance.Data.playerStats.PlayerTalentTree;
        speed3x = Talents.speed3x;
        infinity = Talents.infinity;
        bonusCash = Talents.bonusCash;
        waveInterval = Talents.waveInterval;
        earlyWaveBonusPoint = Talents.earlyWaveBonusPoint;
        rotationSpeed = Talents.rotationSpeed;
        range = Talents.range;
        ProjectileSpeed = Talents.ProjectileSpeed;
        damage = Talents.damage;
        attackSpeed = Talents.attackSpeed;
        baseHealth = Talents.baseHealth;
        startingMoney = Talents.startingMoney;
        EnemyDropCoin = Talents.EnemyDropCoin;
        maxUpgradeLevel = Talents.maxUpgradeLevel;
        StartingLevel = Talents.StartingLevel;
        Discount = Talents.Discount;
        TowerRefund = Talents.TowerRefund;







        Money = StartingMoney + Talents.startingMoney;
        HudMoney.text = Money.ToString();

        HealthPoint = StartingHealth + Talents.baseHealth;
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
