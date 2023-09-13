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
    [NonSerialized] public int CurrentLevel;
    [NonSerialized] public float Damage;
    [NonSerialized] public float AttackSpeed;
    [NonSerialized] public float Range;
    [NonSerialized] public float RotationSpeed;


    private void Awake()
    {
        CurrentLevel = 1;
        Damage = AttackerTowerSO.BaseDamage;
        AttackSpeed = AttackerTowerSO.BaseAttackTime;
        Range = AttackerTowerSO.BaseRange;
        RotationSpeed = AttackerTowerSO.BaseRotationSpeed;
    }
    public void Upgrade()
    {
        float[] NewStatus = GetLevelStatus(CurrentLevel++);
        Damage = NewStatus[0];
        AttackSpeed = NewStatus[1];
        Range = NewStatus[2];
        RotationSpeed = NewStatus[3];

    }
    public float[] GetLevelStatus(int Level)
    {
        float[] Status = new float[4];
        Status[0] = AttackerTowerSO.BaseDamage * (1 + Level-- * DamageMP);
        Status[1] = AttackerTowerSO.BaseAttackTime * (1 - Level * AttackTimeMP);
        Status[2] = AttackerTowerSO.BaseRange * (1 + Level * RangeMP);
        Status[3] = AttackerTowerSO.BaseRotationSpeed * (1 + Level * RotationSpeedMP);
        return Status;
    }
}
