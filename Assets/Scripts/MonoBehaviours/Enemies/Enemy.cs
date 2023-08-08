using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject EnemyType;
    private int Damage;
    // Start is called before the first frame update
    void Start()
    {
        // Here calculates "Damage" based on "Level"
        Damage = EnemyType.BaseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Goal goal = collision.GetComponent<Goal>();
        if (goal != null)
        {
            // Hit an Enemy!
            goal.Damage(Damage);
            Destroy(gameObject);
        }
    }
}
