using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Tower")]
public class TowerScriptableObject : ScriptableObject
{
    public string Name;
    public int Level;
    public int Price;
    public int Damage;
    public int AttackSpeed;
    public int Range;
    public int RotationSpeed;

}
