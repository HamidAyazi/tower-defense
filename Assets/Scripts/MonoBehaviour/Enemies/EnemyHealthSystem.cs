using System;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    private float MaximumHealthPoint;
    private float HealthPoint;
    public event EventHandler OnEnemyDied;

    // Start is called before the first frame update
    void Start()
    {
        // Calculation based on levels goes here
        MaximumHealthPoint = GetComponent<Enemy>().EnemySO.BaseHealtPoint;
        HealthPoint = MaximumHealthPoint;
    }
    public void DealDamage(float DamageReceived)
    {
        HealthPoint -= DamageReceived;
        HealthPoint = Mathf.Clamp(HealthPoint, 0, MaximumHealthPoint);

        if (IsDead())
        {
            OnEnemyDied?.Invoke(this, EventArgs.Empty);
        }
        
    }
    public float GetHealthPoint ()
    {
        return HealthPoint;
    }
    public float GetHealthPointNormalized()
    {
        return (float)HealthPoint / MaximumHealthPoint;
    }
    public bool IsDead()
    {
        return HealthPoint == 0;
    }

}
