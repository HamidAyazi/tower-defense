using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;

    }
    public void BasicTowerClick() {
        Debug.Log("basic(1) tower clicked");
        buildManager.SetTowerToBuild(buildManager.BasicTowerPrefab);
    }

     public void LaserTowerCliCk() {
        Debug.Log("laser(2) tower clicked");
        buildManager.SetTowerToBuild(buildManager.LaserTowerPrefab);
    }
}
