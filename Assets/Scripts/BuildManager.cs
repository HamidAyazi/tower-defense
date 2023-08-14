using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject SelectedTower;
    public GameObject TowerType1;

    void Awake(){
        instance = this;
    }

    public GameObject GetTowerToBuild() {
        return SelectedTower;
    }

    void Start() {
        SelectedTower = TowerType1;
    }

}
