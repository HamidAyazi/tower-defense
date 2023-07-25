using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScriptableObject : ScriptableObject
{
    /*-------- Unity Attributes --------*/

    // "TowerPrefab" is used to store each "Tower" unit's "Prefab" inside "Unity".
    public Transform TowerPrefab;


    /*-------- Game Logic Attributes --------*/

    public int Level;
    // Base Price of each "Tower" unit. When a "Tower" is placed, the "Querency" will be reduce by it's "Price". Scales with "Level".
    public int BasePrice;
    // Base Range of each "Tower" unit. It shows how many "Tiles" away can a "Tower" cover. Scales with "Level".
    public int BaseRange;

}
