using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public Transform ProjectilePrefab;
    private Enemy TargetEnemy;

    public Projectile (Vector3 position, Enemy Enemy)
    {
        Instantiate(, position, Quaternion.identity);
        TargetEnemy = Enemy;

    }
    private void Update()
    {
        Vector3 MoveDiraction = (TargetEnemy.transform.position - transform.position).normalized;

        float MoveSpeed = 20f;
        transform.position += MoveDiraction * MoveSpeed * Time.deltaTime;
    }

    private void SetTarget(Enemy Enemy)
    {
        this.TargetEnemy = Enemy;
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
