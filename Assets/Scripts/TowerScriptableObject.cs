using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Tower")]
public class TowerScriptableObject : ScriptableObject
{
    /*-------- Game Logic Attributes --------*/
    
    public int Level;
    // Base Price of each "Tower" unit. When a "Tower" is placed, the "Querency" will be reduce by it's "Price". Scales with "Level".
    public int BasePrice;
    // Base Damage of each "Tower" unit. When a "Tower" shots, the enemy's "HealthPoint" is reduced by it's "Damage". Scales with "Level".
    public int BaseDamage;
    // Base attack speed of each "Tower" unit. It shows how fast each "Tower" unit can attack "Enemy" units. Scales with "Level".
    public int BaseAttackSpeed;
    // Base Range of each "Tower" unit. It shows how many "Tiles" away can a "Tower" cover. Scales with "Level".
    public int BaseRange;
    // Base Rotation speed of each "Tower" unit. It shows how fast a "Tower" can switch rotates. Scales with "Level".
    public int BaseRotationSpeed;

    /*-------- Unity Attributes --------*/

    // "TowerPrefab" is used to store each "Tower" unit's "Prefab" inside "Unity".
    public Transform TowerPrefab;

}
