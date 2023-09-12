using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailTank : MonoBehaviour
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
    private AttackerTowerStatus Status;

    // Start is called before the first frame update
    void Start()
    {
        // Get Projectile Spawn Point 
        Head = transform.Find("Head");
        ProjectileSpawnPoint = Head.Find("ProjectileSpawnPoint");

        // Set Status
        Status = GetComponent<AttackerTowerStatus>();

        // Set Rotation
        TowerAnimator = Head.GetComponent<Animator>();
        HeadRotation = Head.GetComponent<HeadRotation>();
        HeadRotation.SetRotationSpeed(Status.RotationSpeed);

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
        Collider2D[] Collider2DArray = Physics2D.OverlapCircleAll(transform.position, Status.Range);
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
                    if (Vector3.Distance(transform.position, enemy.transform.position) <
                        Vector3.Distance(transform.position, TargetEnemy.transform.position))
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
            ShootTimer += Status.AttackSpeed;
            if (TargetEnemy != null && HeadRotation.IsLocked())
            {
                // trigger shooting animation
                TowerAnimator.SetTrigger("IsShooting");
                // play shooting sound
                SoundManager.PlaySound(Sound.TankShot, ProjectileSpawnPoint.position, "Double Barrel Tank Shot");
                // shoot
                Laser.CreateProjectile(ProjectilePrefab, ProjectileSpawnPoint.position, TargetEnemy, Status.Damage);
            }
        }
        
        
    }

}
