using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackerTower", menuName = "ScriptableObjects/AttackerTower")]
public class AttackerTowerScriptableObject : TowerScriptableObject
{
    /*-------- Unity Attributes --------*/

    // Transform of "Tower" "Projectile". Each "Tower" of this type use this "Projectile" for shooting.
    public Transform ProjectilePrefab;

    /*-------- Attack Tower Attributes --------*/

    // Base Damage of each "Tower" unit. When a "Tower" shots, the enemy's "HealthPoint" is reduced by it's "Damage". Scales with "Level".
    public int BaseDamage;
    // Base attack speed of each "Tower" unit. It shows how fast each "Tower" unit can attack "Enemy" units. Scales with "Level".
    public int BaseAttackSpeed;
    // Base Rotation speed of each "Tower" unit. It shows how fast a "Tower" can switch rotates. Scales with "Level".
    public int BaseRotationSpeed;


}
