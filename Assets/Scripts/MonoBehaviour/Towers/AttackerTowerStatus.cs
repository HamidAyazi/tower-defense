using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class AttackerTowerStatus : MonoBehaviour
{
    /*-------- Multipliers --------*/
    [SerializeField] private float DamageMP;
    [SerializeField] private float AttackTimeMP;
    [SerializeField] private float RangeMP;
    [SerializeField] private float RotationSpeedMP;

    /*-------- AttackerTower Attributes --------*/
    public AttackerTowerScriptableObject AttackerTowerSO;
    [NonSerialized] public int Level;
    [NonSerialized] public float Damage;
    [NonSerialized] public float AttackSpeed;
    [NonSerialized] public float Range;
    [NonSerialized] public float RotationSpeed;


    private void Awake()
    {
        Level = 1;
        Damage = AttackerTowerSO.BaseDamage;
        AttackSpeed = AttackerTowerSO.BaseAttackTime;
        Range = AttackerTowerSO.BaseRange;
        RotationSpeed = AttackerTowerSO.BaseRotationSpeed;
    }
    public void Upgrade()
    {
        Level++;
    }
    public float[] GetLevelStatus(int Level)
    {
        float[] Status = new float[4];
        Status[0] = AttackerTowerSO.BaseDamage * Level * DamageMP;
        Status[1] = AttackerTowerSO.BaseAttackTime * Level * AttackTimeMP;
        Status[2] = AttackerTowerSO.BaseRange * Level * RangeMP;
        Status[3] = AttackerTowerSO.BaseRotationSpeed * Level * RotationSpeedMP;
        return null;
    }
}
