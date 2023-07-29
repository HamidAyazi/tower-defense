using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerTower : MonoBehaviour
{
    private Enemy TargetEnemy;
    private float LookForTargetTimer;
    private float LookForTargetTimerMAX = .2f;
    private float ShootTimer = 0f;
    private AttackerTowerScriptableObject AttackerTowerSO;

    // Start is called before the first frame update
    void Start()
    {
        AttackerTowerSO = Resources.Load<AttackerTowerScriptableObject>("ScriptableObjects/Towers/Attackers/AttackerTower1");
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
        Collider2D[] Collider2DArray = Physics2D.OverlapCircleAll(transform.position, AttackerTowerSO.BaseRange);
        foreach (Collider2D Collider2D in Collider2DArray)
        {
            Enemy enemy = Collider2D.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Is an Enemy!
                if (TargetEnemy == null)
                {
                    TargetEnemy = enemy;
                } else
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, TargetEnemy.transform.position))
                    {
                        // CLoser!
                        TargetEnemy = enemy;
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
            ShootTimer += AttackerTowerSO.BaseAttackSpeed;
            if (TargetEnemy != null)
            {
                new Projectile (AttackerTowerSO.ProjectilePrefab ,transform.position, TargetEnemy);
            }
        }
        
        
    }
}
