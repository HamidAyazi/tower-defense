using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject Tower;
    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }


    void OnMouseDown(){
        if(buildManager.GetTowerToBuild() == null) return;
        Debug.Log("Tower exists");
        if (Tower != null){
            Debug.Log("Tower exists");
            return;
        } else {
            GameObject TowerToBuild = buildManager.GetTowerToBuild();
            Tower = (GameObject)Instantiate(TowerToBuild, transform.position, transform.rotation);
        }
    }
}
