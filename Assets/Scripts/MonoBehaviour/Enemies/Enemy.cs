using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject EnemySO;
    private EnemyHealthSystem EnemyHealthSystem;
    private int Damage;

    // Start is called before the first frame update
    private void Start()
    {
        // Here calculates "Damage" based on "Level"
        Damage = EnemySO.BaseDamage;

        EnemyHealthSystem = GetComponent<EnemyHealthSystem>();
        EnemyHealthSystem.OnEnemyDied += EnemyHealthSystem_OnEnemyDied;
    }

    private void EnemyHealthSystem_OnEnemyDied(object sender, System.EventArgs e)
    {
        SoundManager.PlaySound(Sound.EnemyDie, transform.position, EnemySO.Name + "Die Sound");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Goal goal = collision.GetComponent<Goal>();
        if (goal != null)
        {
            // Hit an Enemy!
            goal.Damage(Damage);
            Destroy(gameObject);
        }
    }
}
