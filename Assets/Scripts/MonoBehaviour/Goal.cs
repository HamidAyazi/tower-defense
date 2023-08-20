using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public event EventHandler OnGoalDied;

    public void Damage(int DamageReceived)
    {
        PlayerStats.HealthPoint -= DamageReceived;
        if (PlayerStats.HealthPoint == 0)
        {
            OnGoalDied?.Invoke(this, EventArgs.Empty);
        }
    }
}
