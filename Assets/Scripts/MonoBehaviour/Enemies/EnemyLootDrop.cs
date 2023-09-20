using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootDrop : MonoBehaviour
{
    [SerializeField] private float CoinDropChance;
    [SerializeField] private int MaxCoinDrop;
    [SerializeField] private float CashDropChance;
    [SerializeField] private int MaxCashDrop;

    private EnemyHealthSystem EnemyHealthSystem;

    // Start is called before the first frame update
    private void Start()
    {
        EnemyHealthSystem = GetComponent<EnemyHealthSystem>();
        EnemyHealthSystem.OnEnemyDied += LootDrop;
    }

    private void LootDrop(object sender, System.EventArgs e)
    {
        if (Random.value <= CoinDropChance)
        {
            int DroppedCoin = (int) Random.value * MaxCoinDrop;
            GameStats.Money += DroppedCoin;
        }
        if (Random.value <= CashDropChance)
        {
            int DroppedCash = (int)Random.value * MaxCashDrop;
            SaveManager.Instance.Data.playerStats.PlayerTalentTree.Cash += DroppedCash;
        }
    }
}
