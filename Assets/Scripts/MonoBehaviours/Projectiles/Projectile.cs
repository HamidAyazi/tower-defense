using System;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event EventHandler OnEnemyDied;
    private Enemy TargetEnemy;
    private Vector3 MoveDiraction;
    private Vector3 LastMoveDiraction;
    private float TimeToDie = 2f;
    private float MoveSpeed = 6f;
    private int Damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealthSystem EHS = TargetEnemy.GetComponent<EnemyHealthSystem>();
        EHS.OnEnemyDied += RemoveTarget_OnTargerDied;

    }
        
    private void Update()
    {
        if (TargetEnemy != null)
        {
            MoveDiraction = (TargetEnemy.transform.position - transform.position).normalized;
            LastMoveDiraction = MoveDiraction;
        } else
        {
            MoveDiraction = LastMoveDiraction;
        } 

        transform.position += MoveDiraction * MoveSpeed * Time.deltaTime;
        TimeToDie -= Time.deltaTime;
        if (TimeToDie < 0f)
        {
            Destroy(gameObject);
        }
    }

    public static Projectile CreateProjectile(Transform Prefab, Vector3 position, Enemy TargetEnemy)
    {
        Transform ProjectileTransform = Instantiate(Prefab, position, Quaternion.identity);
        Projectile Projectile = ProjectileTransform.GetComponent<Projectile>();
        Projectile.TargetEnemy = TargetEnemy;
        return Projectile;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy Enemy = collision.GetComponent<Enemy>();
        if (Enemy != null)
        { 
            // Hit an Enemy!          
            EnemyHealthSystem HealthSystem = Enemy.GetComponent<EnemyHealthSystem>();
            HealthSystem.Damage(Damage);
            Destroy(gameObject);
        }
    }

    private void RemoveTarget_OnTargerDied(object sender, EventArgs e)
    {
        TargetEnemy = null;
    }

}
