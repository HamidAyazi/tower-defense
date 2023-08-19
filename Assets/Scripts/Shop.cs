using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // tower assets
    public AttackerTowerScriptableObject TankTower;
    public AttackerTowerScriptableObject DoubleBarrelTower;
    // tower assets


    // tower prefabs
    public GameObject DoubleBarrelPrefab;
    public GameObject BasicTowerPrefab;
    // tower prefabs

    // tower buttons
    public Button TankShopButton;
    private bool IsTankButtonActive = false;
    // tower buttons



    public GameObject TowerShop;
    public TMPro.TextMeshProUGUI TowerName;

    private string SelectedTower = null;

    public void CloseShopWindow(){
        TowerShop.SetActive(false);
    }

    void Start()
    {
        if (PlayerStats.Money < TankTower.BasePrice)
        {
            IsTankButtonActive = false;
        }
    }

    void Update()
    {
        if (PlayerStats.Money < TankTower.BasePrice)
        {
            TankShopButton.interactable = false;
        } else
        {
            
        }
    }

    private void OnEnable()
    {
        SelectedTower = null;
        TowerName.text = "";
    }
    
    public void BasicTowerClick() {
        if(PlayerStats.Money >= TankTower.BasePrice)
        {
            if(SelectedTower != "Basic"){
                SelectedTower = "Basic";
                TowerName.text = SelectedTower;
                return;
            } else {
                PlayerStats.Money -= TankTower.BasePrice;
                TileManager.Instance.SelectedTile.Tower = (GameObject)Instantiate(BasicTowerPrefab, TileManager.Instance.SelectedTile.transform.position, TileManager.Instance.SelectedTile.transform.rotation);        
                TowerShop.SetActive(false);
            }
        }
    }

    public void DoubleBarrelTowerCliCk() {

        if (PlayerStats.Money >= DoubleBarrelTower.BasePrice)
        {
            if (SelectedTower != "Double Barrel"){
                SelectedTower = "Double Barrel";
                TowerName.text = SelectedTower;
                return;
            } else {
                TileManager.Instance.SelectedTile.Tower = (GameObject)Instantiate(DoubleBarrelPrefab, TileManager.Instance.SelectedTile.transform.position, TileManager.Instance.SelectedTile.transform.rotation);
                TowerShop.SetActive(false);
            }
        }
    }

    void SetButtonStatus()
    {
        if (PlayerStats.Money < TankTower.BasePrice && IsTankButtonActive)
        {
            TankShopButton.interactable = false;
            IsTankButtonActive = false;
        }
        else if(PlayerStats.Money >= TankTower.BasePrice && !IsTankButtonActive)
        {
            TankShopButton.interactable = false;
            IsTankButtonActive = false;
        }
    }
}
