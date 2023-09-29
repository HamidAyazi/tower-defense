using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    /*-------- Projectile Attributes --------*/
    // Transform of "Tower" "Projectile". Each "Tower" of this type use this "Projectile" for shooting.
    public Transform ProjectilePrefab;
    [SerializeField] private float SlowMP;
    [SerializeField] private float Radius;
    [SerializeField] private float SlowTime;

    /*-------- Head Attributes --------*/
    private Transform ProjectileSpawnPoint;


    /*-------- Logic Attributes --------*/
    private float ShootTimer = 0f;
    private float LookForTargetTimer;
    private float LookForTargetTimerMAX = 0.02f;
    private Enemy TargetEnemy;
    private TowerStats Stats;

    // Start is called before the first frame update
    private void Start()
    {
        // Get Projectile Spawn Point 
        ProjectileSpawnPoint = transform.Find("ProjectileSpawnPoint");

        // Set Status
        Stats = GetComponent<TowerStats>();

        // Other Logics
        LookForTargetTimer = LookForTargetTimerMAX;
    }

    // Update is called once per frame
    private void Update()
    {
        HandleTargeting();
        HandleShooting();
    }
    private void HandleTargeting()
    {
        LookForTargetTimer -= Time.deltaTime;
        if (LookForTargetTimer < 0f)
        {
            if (TargetEnemy != null)
            {
                if (Vector3.Distance(transform.position, TargetEnemy.transform.position) > Stats.Range)
                {
                    TargetEnemy = null;
                }
            }
            else
            {
                LookForTarget();
            }
            LookForTargetTimer += LookForTargetTimerMAX;
        }
    }
    private void LookForTarget()
    {
        Collider2D[] Collider2DArray = Physics2D.OverlapCircleAll(transform.position, Stats.Range);
        float Distance = Stats.Range;
        foreach (Collider2D Collider2D in Collider2DArray) // in all in range objects
        {
            Enemy FoundEnemy = Collider2D.GetComponent<Enemy>();
            if (FoundEnemy != null) // if object is an Enemy
            {
                float NewDistance = Vector3.Distance(transform.position, FoundEnemy.transform.position);
                if (NewDistance < Distance) // is closer
                {
                    Distance = NewDistance;
                    TargetEnemy = FoundEnemy;
                }
            }
        }
    }
    private void HandleShooting()
    {
        if (TargetEnemy == null)
        {
            return;
        }
        ShootTimer -= Time.deltaTime;
        if (ShootTimer < 0f)
        {
            // play shooting sound
            SoundManager.PlaySound(Sound.FreezerShot, ProjectileSpawnPoint.position, "Freezer Shot");
            // shoot
            SnowBall.CreateProjectile(ProjectilePrefab, ProjectileSpawnPoint.position,
                TargetEnemy.transform.position, SlowMP, SlowTime, Radius);
            ShootTimer += 1 / Stats.AttackSpeed;
        }
    }
}
