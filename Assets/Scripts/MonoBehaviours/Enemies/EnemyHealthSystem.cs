using System;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    private EnemyScriptableObject EnemySO;
    private int MaximumHealthPoint;
    private int HealthPoint;
    public event EventHandler OnEnemyDied;

    // Start is called before the first frame update
    void Start()
    {
        EnemySO = GetComponent<Enemy>().EnemyType;

        // Calculation based on levels goes here
        MaximumHealthPoint = EnemySO.BaseHealtPoint;
        HealthPoint = MaximumHealthPoint;
    }
    public void Damage(int DamageReceived)
    {
        HealthPoint -= DamageReceived;
        HealthPoint = Mathf.Clamp(HealthPoint, 0, MaximumHealthPoint);

        if (IsDead())
        {
            OnEnemyDied?.Invoke(this, EventArgs.Empty);
        }
        
    }
    public int GetHealthPoint ()
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
