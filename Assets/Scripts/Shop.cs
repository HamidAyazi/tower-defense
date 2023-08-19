using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // tower assets
    public AttackerTowerScriptableObject TankTower;
    public AttackerTowerScriptableObject DoubleBarrelTower;
    // tower assets


    // tower prefabs
    public GameObject LaserTowerPrefab;
    public GameObject BasicTowerPrefab;
    // tower prefabs


    public GameObject TowerShop;
    public TMPro.TextMeshProUGUI TowerName;

    private string SelectedTower = null;

    public void CloseShopWindow(){
        TowerShop.SetActive(false);
    }

    private void OnEnable()
    {
        SelectedTower = null;
        TowerName.text = "";
    }
    public void BasicTowerClick() {
        // if(price >= money){
            if(SelectedTower != "Basic"){
                SelectedTower = "Basic";
                TowerName.text = SelectedTower;
                return;
            } else {
                TileManager.Instance.SelectedTile.Tower = (GameObject)Instantiate(BasicTowerPrefab, TileManager.Instance.SelectedTile.transform.position, TileManager.Instance.SelectedTile.transform.rotation);        
                TowerShop.SetActive(false);
            }
        // }
    }

    public void LaserTowerCliCk() {
    //      if(SelectedTower != "Laser"){
    //         SelectedTower = "Laser";
    //         TowerName.text = SelectedTower;
    //         return;
    //     } else {
    //         // TileManager.Instance.SelectedTile.Tower = (GameObject)Instantiate(LaserTowerPrefab, TileManager.Instance.SelectedTile.transform.position, TileManager.Instance.SelectedTile.transform.rotation);
    //         TowerShop.SetActive(false);
    //     }
    }
}
