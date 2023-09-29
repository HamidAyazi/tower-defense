using System;
using System.Collections;
using UnityEngine;

public class TowerStats : MonoBehaviour
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
    [NonSerialized] public float MoneySpent;

    private GameObject RangeCircle;
    private float ChangeSizeTime = 0.5f; // Set the duration for the circle to grow/shrink.
    private Vector3 startScale = new Vector3(0.1f, 0.1f, 1); // Start with a tiny circle;

    /// <summary>
    /// First init when a tower is placed
    /// </summary>
    private void Awake()
    {
        RangeCircle = transform.GetChild(1).gameObject;
        CurrentLevel = 1 + GameStats.StartingLevel;
        Damage = AttackerTowerSO.BaseDamage += GameStats.damage;
        AttackSpeed = AttackerTowerSO.BaseAttackSpeed += GameStats.attackSpeed;
        Range = AttackerTowerSO.BaseRange += GameStats.range;
        RotationSpeed = AttackerTowerSO.BaseRotationSpeed += GameStats.rotationSpeed;
        MoneySpent = AttackerTowerSO.BasePrice;
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
        MoneySpent += AttackerTowerSO.BasePrice + PriceMp * (CurrentLevel - 3);
        ShowRange();
    }

    /// <summary>
    /// Get <c>AttackerTower</c> status in specifed level.
    /// </summary>
    /// <param name="Level">Level that the status is fixed.</param>
    /// <returns>An array of <c>AttackerTower</c> status.</returns>
    public float[] GetLevelStatus(int Level)
    {
        if (Level > MaxLevel + GameStats.maxUpgradeLevel)
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

    public void ShowRange()
    {
        StartCoroutine(GrowRangeCircle());
    }

    private IEnumerator GrowRangeCircle()
    {
        RangeCircle.SetActive(true);
        float elapsedTime = 0;
        Vector3 MaxRange = new Vector3(Range/5, Range/5, 1);
        while (elapsedTime < ChangeSizeTime)
        {
            RangeCircle.transform.localScale = Vector3.Lerp(startScale, MaxRange,
                                                            elapsedTime / ChangeSizeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Ensure it's set to the final size
        startScale = RangeCircle.transform.localScale = MaxRange;
    }

    public void HideRange()
    {
        StartCoroutine(ShrinkRangeCircle());
    }

    private IEnumerator ShrinkRangeCircle()
    {
        float elapsedTime = 0;
        Vector3 MinRange = new Vector3(0.1f, 0.1f, 1);
        while (elapsedTime < ChangeSizeTime)
        {
            RangeCircle.transform.localScale = Vector3.Lerp(startScale, MinRange,
                                                            elapsedTime / ChangeSizeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Ensure it's set to the final tiny size
        startScale = RangeCircle.transform.localScale = MinRange; 
        RangeCircle.SetActive(false);
    }
}
