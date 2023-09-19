using UnityEngine;

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

    private bool UpgradeConfirm = false;

    private AttackerTowerStats TowerStats;
    private float[] CurrentStatsArray;

    // Set Upgrade Panel Current Status Text numbers
    private void SetStatusText()
    {
        CurrentStatsArray = TowerStats.GetLevelStatus(TowerStats.CurrentLevel);
        CurrentLevel.text = TowerStats.CurrentLevel.ToString();
        Damage.text = CurrentStatsArray[0].ToString();
        AttackSpeed.text = CurrentStatsArray[1].ToString();
        Range.text = CurrentStatsArray[2].ToString();
        RotationSpeed.text = CurrentStatsArray[3].ToString();
    }
    // Set Upgrade Panel Upgrade Preview Text numbers
    private void SetUpgradePreview()
    {
        float[] UpgradePreviewArray = TowerStats.GetLevelStatus(TowerStats.CurrentLevel + 1);
        for (int i = 0; i < UpgradePreviewArray.Length; i++)
        {
            UpgradePreviewArray[i] -= CurrentStatsArray[i];
            UpgradePreviewArray[i] = Mathf.Round(UpgradePreviewArray[i] * 100f) / 100f;
        }
        NextLevel.text = (TowerStats.CurrentLevel + 1).ToString();
        DamageUpgrade.text = "+" + UpgradePreviewArray[0].ToString();
        AttackSpeedUpgrade.text = "+" + UpgradePreviewArray[1].ToString();
        RangeUpgrade.text = "+" + UpgradePreviewArray[2].ToString();
        RotationSpeedUpgrade.text = "+" + UpgradePreviewArray[3].ToString();
    }


    public void UpgradeTower(){
        if(!UpgradeConfirm){
            UpgradeConfirm = true;
            SetUpgradePreview();
        } else {
            // upgrade tower
        }
    }
    /// <summary>
    /// Open Upgrade Menu UI.
    /// </summary>
    public void OpenUpgradeWindow()
    {
        TowerStats = TileManager.Instance.SelectedTile.GetTower().GetComponent<AttackerTowerStats>();
        transform.GetChild(0).gameObject.SetActive(true);
        SetStatusText();
        //SetUpgradePreview();
    }

    /// <summary>
    /// Close Upgrade Menu UI.
    /// </summary>
    public void CloseUpgradeWindow()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
