using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    /*-------- Logic Attributes --------*/
    private float ShootTimer = 0f;
    private float LookForTargetTimer;
    private Enemy TargetEnemy;
    private Transform Head;
    private Transform ProjectileSpawnPoint;
    private HeadRotation HeadRotation;
    private Animator TowerAnimator;

    /*-------- AttackerTower Attributes --------*/
    [SerializeField] private AttackerTowerScriptableObject AttackerTowerSO;
    private int Level;
    private float Damage;
    private float AttackSpeed;
    private float Range;
    private float LookForTargetTimerMAX;

    // Start is called before the first frame update
    void Start()
    {
        // Get Projectile Spawn Point 
        Head = transform.Find("Head");
        ProjectileSpawnPoint = Head.Find("ProjectileSpawnPoint");

        // Set Rotation
        TowerAnimator = Head.GetComponent<Animator>();
        HeadRotation = Head.GetComponent<HeadRotation>();

        // Here goes calculations based on level
        Damage = AttackerTowerSO.BaseDamage;
        AttackSpeed = AttackerTowerSO.BaseAttackTime;
        Range = AttackerTowerSO.BaseRange;
        LookForTargetTimerMAX = AttackerTowerSO.BaseLookForTargetTimer;
        HeadRotation.SetRotationSpeed(AttackerTowerSO.BaseRotationSpeed);

        // Other Logics
        LookForTargetTimer = LookForTargetTimerMAX;
    }

    // Update is called once per frame
    void Update()
    {
        HandleTargeting();
        HandleShooting();

    } 
    private void HandleTargeting()
    {
        LookForTargetTimer -= Time.deltaTime;
        if (LookForTargetTimer < 0f)
        {
            LookForTargetTimer += LookForTargetTimerMAX;
            LookForTargets();
        }
    }
    private void LookForTargets()
    {
        Collider2D[] Collider2DArray = Physics2D.OverlapCircleAll(transform.position, Range);
        foreach (Collider2D Collider2D in Collider2DArray)
        {
            Enemy enemy = Collider2D.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Is an Enemy!
                if (TargetEnemy == null)
                {
                    TargetEnemy = enemy;
                    HeadRotation.SetTarget(TargetEnemy);
                } else
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, TargetEnemy.transform.position))
                    {
                        // CLoser!
                        TargetEnemy = enemy;
                        HeadRotation.SetTarget(TargetEnemy);
                    }
                }
            }
        }
    }
    private void HandleShooting()
    {
        ShootTimer -= Time.deltaTime;
        if (ShootTimer < 0f)
        {
            ShootTimer += AttackSpeed;
            if (TargetEnemy != null && HeadRotation.IsLocked())
            {
                TowerAnimator.SetTrigger("IsShooting");
                SolidShot.CreateProjectile(AttackerTowerSO.ProjectilePrefab , ProjectileSpawnPoint.position, TargetEnemy, Damage);
            }
        }
        
        
    }
}
