using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackerTower", menuName = "ScriptableObjects/AttackerTower")]
public class AttackerTowerScriptableObject : TowerScriptableObject
{
    /*-------- Attack Tower Attributes --------*/

    // Base Damage of each "Tower" unit. When a "Tower" shots, the enemy's "HealthPoint" is reduced by it's "Damage". Scales with "Level".
    public float BaseDamage;
    // Base time each attack of each "Tower" unit takes . It shows how many seconds each "Tower" unit can attack "Enemy" units. Scales with "Level".
    public float BaseAttackSpeed;
    // Base Rotation speed of each "Tower" unit. It shows how fast a "Tower" can switch rotates. Scales with "Level".
    public float BaseRotationSpeed;
    // Base time for "Tower" to look for an "Enemy". Scales with "LeveL".
    public float BaseLookForTargetTimer;


}
