using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GoalScriptableObject GoalSO;
    private int MaximumHealthPoint;
    private int HealthPoint;

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
        Debug.Log("goal hp : " + HealthPoint);
        if (IsDead())
        {
            Destroy(gameObject);
            Debug.Log("goal died");
        }

    }
    public int GetHealthPoint()
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
