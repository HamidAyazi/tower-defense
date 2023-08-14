using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject SelectedTower;
    public GameObject BasicTowerPrefab;
    public GameObject LaserTowerPrefab;

    void Awake(){
        if(instance != null) return;
        instance = this;
    }

    public GameObject GetTowerToBuild() {
        return SelectedTower;
    }
    public void SetTowerToBuild(GameObject Tower){
        SelectedTower = Tower;
    }

}
