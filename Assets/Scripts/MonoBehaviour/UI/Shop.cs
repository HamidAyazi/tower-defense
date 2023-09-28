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

    public TMPro.TextMeshProUGUI TowerName;
    private string SelectedTower;

    
    private TutorialManager Tmanager;

    private void Start()
    {
        Tmanager = GameObject.Find("GameManager").GetComponent<TutorialManager>();
        if (GameStats.Money < TankTower.BasePrice)
        {
            IsTankButtonActive = false;
        }
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
    }

    private void OnEnable()
    {
        SelectedTower = null;
        TowerName.text = "";
    }
    private void SetButtonStatus()
    {
        if (GameStats.Money < TankTower.BasePrice && IsTankButtonActive)
        {
            TankShopButton.interactable = false;
            IsTankButtonActive = false;
        }
        else if (GameStats.Money >= TankTower.BasePrice && !IsTankButtonActive)
        {
            TankShopButton.interactable = false;
            IsTankButtonActive = false;
        }
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
