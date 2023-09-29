using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    // Current Status
    [SerializeField] private TMPro.TextMeshProUGUI Damage;
    [SerializeField] private TMPro.TextMeshProUGUI AttackSpeed;
    [SerializeField] private TMPro.TextMeshProUGUI Range;
    [SerializeField] private TMPro.TextMeshProUGUI RotationSpeed;
    [SerializeField] private TMPro.TextMeshProUGUI CurrentLevel;
    // Upgrade Preview Status
    [SerializeField] private TMPro.TextMeshProUGUI DamageUpgrade;
    [SerializeField] private TMPro.TextMeshProUGUI AttackSpeedUpgrade;
    [SerializeField] private TMPro.TextMeshProUGUI RangeUpgrade;
    [SerializeField] private TMPro.TextMeshProUGUI RotationSpeedUpgrade;
    [SerializeField] private TMPro.TextMeshProUGUI NextLevel;
    [SerializeField] private TMPro.TextMeshProUGUI UpgradePrice;
    // Icons
    [SerializeField] private GameObject arrowImage;
    [SerializeField] private GameObject Coin;
    // UI elements
    [SerializeField] private Button UpgradeBtn;
    [SerializeField] public GameObject SellConfirmPanel;
    [SerializeField] public TMPro.TextMeshProUGUI SellPriceText;

    private bool UpgradeConfirm;
    private AttackerTowerStats TowerStats;
    private float[] CurrentStatsArray;
    
    private TutorialManager Tmanager;

     private void Start()
    {
        Tmanager = GameObject.Find("GameManager").GetComponent<TutorialManager>();
    }

    /// <summary>
    /// Open Upgrade Menu UI.
    /// </summary>
    public void OpenUpgradeWindow()
    {
        CloseUpgradeWindow();
        Tmanager.CheckPhase4();
        ResetValues();
        TowerStats = TileManager.Instance.SelectedTile.GetTower().GetComponent<AttackerTowerStats>();
        transform.GetChild(0).gameObject.SetActive(true);
        UpgradeConfirm = false;
        SetStatsText();
        TowerStats.ShowRange();
    }
    
    /// <summary>
    /// Set Upgrade Panel Current Status Text numbers
    /// </summary>
    private void SetStatsText()
    {
        CurrentStatsArray = TowerStats.GetLevelStatus(TowerStats.CurrentLevel);
        CurrentLevel.text = TowerStats.CurrentLevel.ToString();
        Damage.text = CurrentStatsArray[0].ToString();
        AttackSpeed.text = CurrentStatsArray[1].ToString();
        Range.text = CurrentStatsArray[2].ToString();
        RotationSpeed.text = CurrentStatsArray[3].ToString();
    }

    /// <summary>
    /// Set Upgrade Panel Upgrade Preview Text numbers
    /// </summary>
    private void SetUpgradePreviewText()
    {
        int nextLevel = TowerStats.CurrentLevel + 1;
        float[] UpgradePreviewArray = TowerStats.GetLevelStatus(nextLevel);
        if (UpgradePreviewArray == null)
        {
            UpgradeBtn.interactable = false;
            ResetValues();
            return;
        }
        for (int i = 0; i < UpgradePreviewArray.Length; i++)
        {
            UpgradePreviewArray[i] -= CurrentStatsArray[i];
            UpgradePreviewArray[i] = Mathf.Round(UpgradePreviewArray[i] * 100f) / 100f;
        }
        NextLevel.text = nextLevel.ToString();
        DamageUpgrade.text = "+" + UpgradePreviewArray[0].ToString();
        AttackSpeedUpgrade.text = "+" + UpgradePreviewArray[1].ToString();
        RangeUpgrade.text = "+" + UpgradePreviewArray[2].ToString();
        RotationSpeedUpgrade.text = "+" + UpgradePreviewArray[3].ToString();
        UpgradePrice.text = Mathf.FloorToInt(CurrentStatsArray[4] - (CurrentStatsArray[4] * (GameStats.Discount / 100))).ToString();
        arrowImage.SetActive(true);
    }

    /// <summary>
    /// On upgrade click.
    /// if confirmed upgrade else confirm and show preview
    /// </summary>
    public void UpgradeTower(){
        if(GameStats.Money >= Mathf.FloorToInt(CurrentStatsArray[4] - (CurrentStatsArray[4] * (GameStats.Discount / 100)))){
            if(!UpgradeConfirm){
                UpgradeConfirm = true;
                SetUpgradePreviewText();
            } else {
                GameStats.Money -= (int)Mathf.FloorToInt(CurrentStatsArray[4] - (CurrentStatsArray[4] * (GameStats.Discount / 100)));
                TowerStats.Upgrade();
                SetStatsText();
                SetUpgradePreviewText();
            }
        }
    }

    /// <summary>
    /// Reset upgrade UI values
    /// </summary>
    private void ResetValues()
    {
        arrowImage.SetActive(false);
        UpgradeConfirm = false;
        UpgradeBtn.interactable = true;
        NextLevel.text = "";
        UpgradePrice.text = "";
        DamageUpgrade.text = "";
        AttackSpeedUpgrade.text = "";
        RangeUpgrade.text = "";
        RotationSpeedUpgrade.text = "";
    }

    /// <summary>
    /// Close Upgrade Menu UI.
    /// </summary>
    public void CloseUpgradeWindow()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        if (TowerStats != null)
        {
            TowerStats.HideRange();
        }
    }

    public void OpenSellConfirmPanel() {
        int sellPrice = Mathf.FloorToInt((TowerStats.MoneySpent / 2) * ((GameStats.TowerRefund + 100) / 100));
        SellPriceText.text = sellPrice.ToString();
        SellConfirmPanel.SetActive(true);
    }
    public void CloseSellConfirmPanel() {
        SellConfirmPanel.SetActive(false);
    }
    public void AddSellTower(){
        int sellPrice = Mathf.FloorToInt((TowerStats.MoneySpent / 2) * ((GameStats.TowerRefund + 100) / 100));
        GameStats.Money += sellPrice;
        CloseSellConfirmPanel();
        CloseUpgradeWindow();
    }
}
