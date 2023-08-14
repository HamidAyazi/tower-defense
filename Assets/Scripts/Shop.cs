using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject TowerShop;
    public GameObject BasicTowerPrefab;
    public GameObject LaserTowerPrefab;
    public TMPro.TextMeshProUGUI TowerName;

    private string SelectedTower = null;

    public void CloseShopWindow(){
        TowerShop.SetActive(false);
    }
    public void BasicTowerClick() {
        if(SelectedTower != "Basic"){
            SelectedTower = "Basic";
            TowerName.text = SelectedTower;
            return;
        } else {
            TileManager.Instance.SelectedTile.Tower = (GameObject)Instantiate(BasicTowerPrefab, TileManager.Instance.SelectedTile.transform.position, TileManager.Instance.SelectedTile.transform.rotation);        
            TowerShop.SetActive(false);
            SelectedTower = null;
        }
    }

    public void LaserTowerCliCk() {
        Debug.Log("laser(2) tower clicked");
    }
}
