using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject Tower;
    void OnMouseDown(){
        Debug.Log("Tower exists");
        if (Tower != null){
            Debug.Log("Tower exists");
            return;
        } else {
            GameObject TowerToBuild = BuildManager.instance.GetTowerToBuild();
            Tower = (GameObject)Instantiate(TowerToBuild, transform.position, transform.rotation);
        }
    }
}
