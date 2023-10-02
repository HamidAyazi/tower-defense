using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static event EventHandler OnGoalDied;

    /// <summary>
    /// Damage the <c>Goal</c>. if <c>HealthPoint</c> reaches 0, it invokes game over.
    /// </summary>
    /// <param name="DamageReceived">The amount of received damage.</param>
    public void Damage(int DamageReceived)
    {
        GameStats.HealthPoint -= DamageReceived;
        if (GameStats.HealthPoint <= 0)
        {
            OnGoalDied?.Invoke(this, EventArgs.Empty);
        }
    }
}
