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
            GameStats.Money += Mathf.RoundToInt(Random.value * MaxCoinDrop) + GameStats.EnemyDropCoin;
        }
        if (Random.value <= CashDropChance)
        {
            SaveManager.Instance.Data.playerStats.PlayerTalentTree.Cash +=
                Mathf.RoundToInt(Random.value * MaxCashDrop);
        }
    }
}
