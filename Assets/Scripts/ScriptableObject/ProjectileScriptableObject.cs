using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Projectile")]
public class ProjectileScriptableObject : ScriptableObject
{
    /*-------- Projectile Attributes --------*/


    public float BaseSpeed;

    public float MaxTimeToDie;
}
