using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScriptableObject : ScriptableObject
{
    /*-------- Game Logic Attributes --------*/

    public int Level;
    // Base Price of each "Tower" unit. When a "Tower" is placed, the "Querency" will be reduce by it's "Price". Scales with "Level".
    public int BasePrice;
    // Base Range of each "Tower" unit. It shows how many "Tiles" away can a "Tower" cover. Scales with "Level".
    public int BaseRange;

}
