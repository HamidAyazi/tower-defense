using UnityEngine;

[CreateAssetMenu(fileName = "Goal", menuName = "ScriptableObjects/Goal")]
public class GoalScriptableObject : ScriptableObject
{
    // Health amount of "Goal". It reduces when each "Enemy" hits Goal.
    public int BaseHealthPoint;
}
