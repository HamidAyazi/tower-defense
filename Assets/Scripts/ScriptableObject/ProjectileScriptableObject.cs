using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Projectile")]
public class ProjectileScriptableObject : ScriptableObject
{
    /*-------- Projectile Attributes --------*/

    // Speed of the Projectile.
    public float BaseSpeed;
    // Time to die for a Projectile after hit missing.
    public float MaxTimeToDie;
}
