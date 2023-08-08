using System;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    //public event EventHandler OnDamaged;
    //public event EventHandler OnDied;

    private EnemyScriptableObject EnemySO;
    private int MaximumHealthPoint;
    private int HealthPoint;

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

        //OnDamaged?.Invoke(this, EventArgs.Empty);
        if (IsDead())
        {
            //OnDied?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
            Debug.Log("died");
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
