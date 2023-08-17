using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GoalScriptableObject GoalSO;
    public event EventHandler<OnDamagedEventArgs> OnGoalDamaged;
    public event EventHandler OnGoalDied;
    private float MaximumHealthPoint;
    private float HealthPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Calculation based on levels goes here
        MaximumHealthPoint = GoalSO.BaseHealthPoint;
        HealthPoint = MaximumHealthPoint;
    }

    public void Damage(int DamageReceived)
    {
        HealthPoint -= DamageReceived;
        HealthPoint = Mathf.Clamp(HealthPoint, 0, MaximumHealthPoint);
        OnGoalDamaged?.Invoke(this, new OnDamagedEventArgs { HealthPoint = HealthPoint});

        if (IsDead())
        {
            OnGoalDied?.Invoke(this, EventArgs.Empty);
        }

    }
    public float GetHealthPoint()
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
    public class OnDamagedEventArgs : EventArgs
    {
        public float HealthPoint;
    }
}
