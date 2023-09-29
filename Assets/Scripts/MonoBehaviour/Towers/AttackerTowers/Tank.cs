using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    /*-------- Projectile Attributes --------*/
    // Transform of "Tower" "Projectile". Each "Tower" of this type use this "Projectile" for shooting.
    public Transform ProjectilePrefab;

    /*-------- Head Attributes --------*/
    private Transform Head;
    private Transform ProjectileSpawnPoint;
    private HeadRotation HeadRotation;
    private Animator TowerAnimator;

    /*-------- Logic Attributes --------*/
    private float ShootTimer = 0f;
    private float LookForTargetTimer;
    private float LookForTargetTimerMAX = 0.02f;
    private Enemy TargetEnemy;
    private AttackerTowerStats Stats;

    // Start is called before the first frame update
    private void Start()
    {
        // Get Projectile Spawn Point 
        Head = transform.Find("Head");
        ProjectileSpawnPoint = Head.Find("ProjectileSpawnPoint");

        // Set Status
        Stats = GetComponent<AttackerTowerStats>();

        // Set Rotation
        TowerAnimator = Head.GetComponent<Animator>();
        HeadRotation = Head.GetComponent<HeadRotation>();
        HeadRotation.SetRotationSpeed(Stats.RotationSpeed);

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
            LookForTargetTimer += LookForTargetTimerMAX;
            LookForTargets();
        }
    }
    private void LookForTargets()
    {
        Collider2D[] Collider2DArray = Physics2D.OverlapCircleAll(transform.position, Stats.Range);
        foreach (Collider2D Collider2D in Collider2DArray)
        {
            Enemy enemy = Collider2D.GetComponent<Enemy>();
            if (enemy != null) // Is an Enemy!
            {
                if (TargetEnemy == null)
                {
                    TargetEnemy = enemy;
                    HeadRotation.SetTarget(TargetEnemy);
                }
                else if (Vector3.Distance(transform.position, enemy.transform.position) < Stats.Range) // Target out of range
                {
                    TargetEnemy = enemy;
                    HeadRotation.SetTarget(TargetEnemy);
                }
            }
        }
    }
    private void HandleShooting()
    {
        ShootTimer -= Time.deltaTime;
        if (ShootTimer < 0f)
        {
            ShootTimer += 1 / Stats.AttackSpeed;
            if (TargetEnemy != null && HeadRotation.IsLocked())
            {
                // trigger shooting animation
                TowerAnimator.SetTrigger("IsShooting");
                // play shooting sound
                SoundManager.PlaySound(Sound.TankShot, ProjectileSpawnPoint.position, "Tank Shot");
                // shoot
                SolidShot.CreateProjectile(ProjectilePrefab, ProjectileSpawnPoint.position, TargetEnemy, Stats.Damage);
            }
        }  
    }
    
}
