using System;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    private float MaximumHealthPoint;
    private float HealthPoint;
    public event EventHandler OnEnemyDied;

    // Start is called before the first frame update
    private void Start()
    {
        // Calculation based on levels goes here
        MaximumHealthPoint = GetComponent<Enemy>().EnemySO.BaseHealtPoint;
        HealthPoint = MaximumHealthPoint;
    }

    /// <summary>
    /// Damage to <c>Enemy</c>.
    /// Reduces health of the <c>Enemy</c> by a fixed amount.
    /// </summary>
    /// <param name="DamageReceived">The amount of received damage.</param>
    public void DealDamage(float DamageReceived)
    {
        HealthPoint -= DamageReceived;
        HealthPoint = Mathf.Clamp(HealthPoint, 0, MaximumHealthPoint);

        if (HealthPoint == 0)
        {
            SoundManager.PlaySound(Sound.EnemyDie, transform.position, GetComponent<Enemy>().EnemySO.Name + "Die Sound");
            Kill();
        }
        
    }

    /// <summary>
    /// A method to get the remaining health of the <c>Enemy</c>.
    /// </summary>
    /// <returns>a float between 0 and <c>MaximumHealthPoint</c>.</returns>
    public float GetHealthPoint()
    {
        return HealthPoint;
    }

    /// <summary>
    /// A method to get normalized remaining health of the <c>Enemy</c>.
    /// </summary>
    /// <returns>A float between 0 and 1.</returns>
    public float GetHealthPointNormalized()
    {
        return (float)HealthPoint / MaximumHealthPoint;
    }

    /// <summary>
    /// Kill Enemy and Destory it's GameObject.
    /// </summary>
    public void Kill()
    {
        OnEnemyDied?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }

}
