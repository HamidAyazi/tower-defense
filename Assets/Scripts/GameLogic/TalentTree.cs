using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentTree
{
    public int StartMoney;
    public int StartHealthPoint;
    public int Cash;


    public bool speed3x;
    public bool infinity;
    public int bonusCash;
    public int waveInterval;
    public int earlyWaveBonusPoint;
    public float rotationSpeed;
    public float range;
    public float ProjectileSpeed;
    public float damage;
    public float attackSpeed;
    public int baseHealth;
    public int startingMoney;
    public int EnemyDropCoin;
    public int maxUpgradeLevel;
    public int StartingLevel;
    public float Discount;
    public float TowerRefund;


    public List<TalentData> Talents;
    public TalentTree()
    {
        Talents = new List<TalentData>();
        Cash = 0;
        speed3x = false;
        infinity = false;
        bonusCash = 0;
        waveInterval = 0;
        earlyWaveBonusPoint = 0;
        rotationSpeed = 0.0f;
        range = 0.0f;
        ProjectileSpeed = 0.0f;
        damage = 0.0f;
        attackSpeed = 0.0f;
        baseHealth = 0;
        startingMoney = 0;
        EnemyDropCoin = 0;
        maxUpgradeLevel = 0;
        StartingLevel = 0;
        Discount = 0.0f;
        TowerRefund = 0.0f;

    }
}
