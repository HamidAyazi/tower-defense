using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{ 
    private Enemy TargetEnemy;
    private Vector3 MoveDiraction;
    private Vector3 LastMoveDiraction;
    private float TimeToDie = 2f;
    private float MoveSpeed = 2f;

    public static Projectile CreateProjectile (Transform Prefab, Vector3 position, Enemy TargetEnemy)
    {
        Transform ProjectileTransform = Instantiate(Prefab, position, Quaternion.identity);
        Projectile Projectile = ProjectileTransform.GetComponent<Projectile>();
        Projectile.TargetEnemy = TargetEnemy;
        return Projectile;
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
        if(TimeToDie < 0f)
        {
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy Enemy = collision.GetComponent<Enemy>();
        if (Enemy != null)
        {
            // Hit an Enemy!
            Destroy(gameObject);
        }
    }

}
