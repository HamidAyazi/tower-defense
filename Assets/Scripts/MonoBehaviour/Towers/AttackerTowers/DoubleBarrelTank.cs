using UnityEngine;

public class DoubleBarrelTank : MonoBehaviour
{
    /*-------- Projectile Attributes --------*/
    // Transform of "Tower" "Projectile". Each "Tower" of this type use this "Projectile" for shooting.
    public Transform ProjectilePrefab;

    /*-------- Head Attributes --------*/
    private Transform Head;
    private Transform ProjectileSpawnPoint1;
    private Transform ProjectileSpawnPoint2;
    private HeadRotation HeadRotation;
    private Animator TowerAnimator;

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
        Head = transform.Find("Head");
        ProjectileSpawnPoint1 = Head.Find("ProjectileSpawnPoint1");
        ProjectileSpawnPoint2 = Head.Find("ProjectileSpawnPoint2");

        // Set Status
        Stats = GetComponent<TowerStats>();

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
        HeadRotation.SetTarget(TargetEnemy);
    }
    private void HandleShooting()
    {
        ShootTimer -= Time.deltaTime;
        if (ShootTimer < 0f)
        {
            if (HeadRotation.IsLocked())
            {
                // trigger shooting animation
                TowerAnimator.SetTrigger("IsShooting");
                // play shooting sound
                SoundManager.PlaySound(Sound.TankShot, ProjectileSpawnPoint1.position, "Double Barrel Tank Shot");
                // shoot
                SolidShot.CreateProjectile(ProjectilePrefab, ProjectileSpawnPoint1.position, TargetEnemy, Stats.Damage);
                SolidShot.CreateProjectile(ProjectilePrefab, ProjectileSpawnPoint2.position, TargetEnemy, Stats.Damage);
            }
        }
        ShootTimer += 1 / Stats.AttackSpeed;  
    }

}
