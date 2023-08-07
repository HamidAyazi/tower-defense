using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TowerTypesList")]
public class TowerTypesList : ScriptableObject
{
    public List<Transform> List;
}
