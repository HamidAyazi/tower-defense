using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // tower assets
    public AttackerTowerScriptableObject TankTower;
    public AttackerTowerScriptableObject DoubleBarrelTower;
    // public AttackerTowerScriptableObject RailGunTower;
    // tower assets

    // tower prefabs
    public GameObject DoubleBarrelPrefab;
    public GameObject BasicTowerPrefab;
    // public GameObject RailGunPrefab;
    // tower prefabs

    // tower buttons
    public Button TankShopButton;
    
    public Button DoubleBarrelShopButton;
    public Button RailGunShopButton;
    // tower buttons

    public TMPro.TextMeshProUGUI TowerName;
    private string SelectedTower;

    
    private TutorialManager Tmanager;

    private void Start()
    {
        Tmanager = GameObject.Find("GameManager").GetComponent<TutorialManager>();
    }

    private void Update()
    {
        if (GameStats.Money < TankTower.BasePrice)
        {
            TankShopButton.interactable = false;
        } else
        {
            TankShopButton.interactable = true;
        }
        if (GameStats.Money < DoubleBarrelTower.BasePrice)
        {
            DoubleBarrelShopButton.interactable = false;
        } else
        {
            DoubleBarrelShopButton.interactable = true;
        }
        // if (GameStats.Money < RailGunTower.BasePrice)
        // {
        //     RailGunShopButton.interactable = false;
        // } else
        // {
        //     RailGunShopButton.interactable = true;
        // }
    }

    private void OnEnable()
    {
        SelectedTower = null;
        TowerName.text = "";
    }

    /// <summary>
    /// Place Tank on the selected tile.
    /// </summary>
    public void BasicTowerClick() {
        if(GameStats.Money >= TankTower.BasePrice)
        {
            if(SelectedTower != TankTower.Name){
                SelectedTower = TankTower.Name;
                TowerName.text = SelectedTower;
                return;
            } else {
                GameStats.Money -= TankTower.BasePrice;
                // play tower spawn sound
                SoundManager.PlaySound(Sound.TowerSpawn, TileManager.Instance.SelectedTile.transform.position,
                                        SelectedTower + " Spawn Sound");
                // place tower
                TileManager.Instance.SelectedTile.SetTower(Instantiate(BasicTowerPrefab,
                                                           TileManager.Instance.SelectedTile.transform.position,
                                                           TileManager.Instance.SelectedTile.transform.rotation));
                CloseShopWindow();
            }
        }
    }

    /// <summary>
    /// Place Double Barrel Tank on selected tile.
    /// </summary>
    public void DoubleBarrelTowerCliCk() {

        if (GameStats.Money >= DoubleBarrelTower.BasePrice)
        {
            if (SelectedTower != DoubleBarrelTower.Name){
                SelectedTower = DoubleBarrelTower.Name;
                TowerName.text = SelectedTower;
                return;
            } else {
                GameStats.Money -= DoubleBarrelTower.BasePrice;
                // play tower spawn sound
                SoundManager.PlaySound(Sound.TowerSpawn, TileManager.Instance.SelectedTile.transform.position,
                                        SelectedTower + " Spawn Sound");
                // place tower
                TileManager.Instance.SelectedTile.SetTower(Instantiate(DoubleBarrelPrefab,
                                                            TileManager.Instance.SelectedTile.transform.position,
                                                            TileManager.Instance.SelectedTile.transform.rotation));
                CloseShopWindow();
            }
        }
    }

    /// <summary>
    /// Place Rail Gun on selected tile.
    /// </summary>
    // public void RailGunTowerCliCk() {

    //     if (GameStats.Money >= RailGunTower.BasePrice)
    //     {
    //         if (SelectedTower != RailGunTower.Name){
    //             SelectedTower = RailGunTower.Name;
    //             TowerName.text = SelectedTower;
    //             return;
    //         } else {
    //             GameStats.Money -= RailGunTower.BasePrice;
    //             // play tower spawn sound
    //             SoundManager.PlaySound(Sound.TowerSpawn, TileManager.Instance.SelectedTile.transform.position,
    //                                     SelectedTower + " Spawn Sound");
    //             // place tower
    //             TileManager.Instance.SelectedTile.SetTower(Instantiate(RailGunPrefab,
    //                                                         TileManager.Instance.SelectedTile.transform.position,
    //                                                         TileManager.Instance.SelectedTile.transform.rotation));
    //             CloseShopWindow();
    //         }
    //     }
    // }

    /// <summary>
    /// Open Shop Menu UI.
    /// </summary>
    public void OpenShopWindow()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        Tmanager.CheckPhase2();
    }

    /// <summary>
    /// Close Shop Menu UI.
    /// </summary>
    public void CloseShopWindow()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Tmanager.CheckPhase3();
    }
}
