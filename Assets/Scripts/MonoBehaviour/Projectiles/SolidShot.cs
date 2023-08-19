using System;
using Unity.VisualScripting;
using UnityEngine;

public class SolidShot : MonoBehaviour
{
    /*-------- Logic Attributes --------*/
    public event EventHandler OnEnemyDied;
    [SerializeField] private ProjectileScriptableObject ProjectileSO;
    private Enemy TargetEnemy;
    private Vector3 MoveDiraction;
    private Vector3 LastMoveDiraction;

    /*-------- Projectile Attributes --------*/
    private float TimeToDie;
    private float Damage;
    private float Speed;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealthSystem EHS = TargetEnemy.GetComponent<EnemyHealthSystem>();

        // Here goes to Event Subs
        EHS.OnEnemyDied += RemoveTarget_OnTargerDied;

        // Here goes to calculations based on level
        TimeToDie = ProjectileSO.MaxTimeToDie;
        Speed = ProjectileSO.BaseSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        // Moves Toward a target. If target is dead then goes the same diraction.
        if (TargetEnemy != null)
        {
            MoveDiraction = (TargetEnemy.transform.position - transform.position).normalized;
            LastMoveDiraction = MoveDiraction;
        }
        else
        {
            MoveDiraction = LastMoveDiraction;
        }

        transform.position += MoveDiraction * Speed * Time.deltaTime;
        TimeToDie -= Time.deltaTime;
        if (TimeToDie < 0f)
        {
            Destroy(gameObject);
        }
    }

    public static SolidShot CreateProjectile(Transform ProjectilePrefab, Vector3 SpawnPosition, Enemy TargetEnemy, float Damage)
    {
        Transform ProjectileTransform = Instantiate(ProjectilePrefab, SpawnPosition, Quaternion.identity);
        SolidShot Projectile = ProjectileTransform.GetComponent<SolidShot>();
        Projectile.TargetEnemy = TargetEnemy;
        Projectile.Damage = Damage;
        return Projectile;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy Enemy = collision.GetComponent<Enemy>();
        if (Enemy != null)
        { 
            // Hit an Enemy!          
            EnemyHealthSystem HealthSystem = Enemy.GetComponent<EnemyHealthSystem>();
            HealthSystem.DealDamage(Damage);
            Destroy(gameObject);
        }
    }

    private void RemoveTarget_OnTargerDied(object sender, EventArgs e)
    {
        TargetEnemy = null;
    }

}
