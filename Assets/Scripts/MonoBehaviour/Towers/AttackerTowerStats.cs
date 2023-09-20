using System;
using UnityEngine;

public class AttackerTowerStats : MonoBehaviour
{
    /*-------- Multipliers --------*/
    [SerializeField] private float DamageMp;
    [SerializeField] private float AttackSpeedMp;
    [SerializeField] private float RangeMp;
    [SerializeField] private float RotationSpeedMp;
    [SerializeField] private int PriceMp;
    [SerializeField] private int MaxLevel;

    /*-------- AttackerTower Attributes --------*/
    public AttackerTowerScriptableObject AttackerTowerSO;
    [NonSerialized] public int CurrentLevel;
    [NonSerialized] public float Damage;
    [NonSerialized] public float AttackSpeed;
    [NonSerialized] public float Range;
    [NonSerialized] public float RotationSpeed;

    /// <summary>
    /// First init when a tower is placed
    /// </summary>
    private void Awake()
    {
        CurrentLevel = 1;
        Damage = AttackerTowerSO.BaseDamage;
        AttackSpeed = AttackerTowerSO.BaseAttackSpeed;
        Range = AttackerTowerSO.BaseRange;
        RotationSpeed = AttackerTowerSO.BaseRotationSpeed;
    }

    /// <summary>
    /// Upgrade the <c>AttackerTower</c> and set new status.
    /// </summary>
    public void Upgrade()
    {
        float[] NewStatus = GetLevelStatus(CurrentLevel++);
        Damage = NewStatus[0];
        AttackSpeed = NewStatus[1];
        Range = NewStatus[2];
        RotationSpeed = NewStatus[3];
    }

    /// <summary>
    /// Get <c>AttackerTower</c> status in specifed level.
    /// </summary>
    /// <param name="Level">Level that the status is fixed.</param>
    /// <returns>An array of <c>AttackerTower</c> status.</returns>
    public float[] GetLevelStatus(int Level)
    {
        if (Level > MaxLevel)
        {
            return null;
        }
        float[] Status = new float[5];
        Status[0] = AttackerTowerSO.BaseDamage * (1 + Level * DamageMp);
        Status[1] = AttackerTowerSO.BaseAttackSpeed * (1 + Level * AttackSpeedMp);
        Status[2] = AttackerTowerSO.BaseRange * (1 + Level * RangeMp);
        Status[3] = AttackerTowerSO.BaseRotationSpeed * (1 + Level * RotationSpeedMp);
        Status[4] = AttackerTowerSO.BasePrice + PriceMp * (Level - 2);
        return Status;
    }
    /// <summary>
    /// Get max level of each tower.
    /// </summary>
    /// <returns><code>Tower</code> max level.</returns>
    public int GetMaxLevel()
    {
        return MaxLevel;
    }
}
