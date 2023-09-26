using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject EnemySO;
    public int Level;

    private int Damage;
    private EnemyHealthSystem enemyHealthSystem;

    // Start is called before the first frame update
    private void Start()
    {
        // Here calculates "Damage" based on "Level"
        Damage = EnemySO.BaseDamage * Level;
        enemyHealthSystem = GetComponent<EnemyHealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Goal goal = collision.GetComponent<Goal>();
        if (goal != null)
        {
            // Hit Goal!
            goal.Damage(Damage);
            enemyHealthSystem.Kill();
        }
    }
}
