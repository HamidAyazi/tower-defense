using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // Current Status
    [SerializeField] private TMPro.TextMeshProUGUI Damage;
    [SerializeField] private TMPro.TextMeshProUGUI AttackSpeed;
    [SerializeField] private TMPro.TextMeshProUGUI Range;
    [SerializeField] private TMPro.TextMeshProUGUI RotationSpeed;
    // Upgrade Preview Status
    [SerializeField] private TMPro.TextMeshProUGUI DamageUpgrade;
    [SerializeField] private TMPro.TextMeshProUGUI AttackSpeedUpgrade;
    [SerializeField] private TMPro.TextMeshProUGUI RangeUpgrade;
    [SerializeField] private TMPro.TextMeshProUGUI RotationSpeedUpgrade;

    private AttackerTowerStatus TowerStatus;
    private float[] CurrentStatusArray;

    public void OpenUpgradeWindow()
    {
        TowerStatus = TileManager.Instance.SelectedTile.GetTower().GetComponent<AttackerTowerStatus>();
        transform.GetChild(0).gameObject.SetActive(true);
        SetStatusText();
        //SetUpgradePreview();
    }
    public void CloseUpgradeWindow()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    // Set Upgrade Panel Current Status Text numbers
    private void SetStatusText()
    {
        CurrentStatusArray = TowerStatus.GetLevelStatus(TowerStatus.CurrentLevel);
        Damage.text = CurrentStatusArray[0].ToString();
        AttackSpeed.text = CurrentStatusArray[1].ToString();
        Range.text = CurrentStatusArray[2].ToString();
        RotationSpeed.text = CurrentStatusArray[3].ToString();
    }
    // Set Upgrade Panel Upgrade Preview Text numbers
    private void SetUpgradePreview()
    {
        float[] UpgradePreviewArray = TowerStatus.GetLevelStatus(TowerStatus.CurrentLevel + 1);
        for (int i = 0; i < UpgradePreviewArray.Length; i++)
        {
            UpgradePreviewArray[i] -= CurrentStatusArray[i];
        }
        DamageUpgrade.text = "+" + UpgradePreviewArray[0].ToString();
        AttackSpeedUpgrade.text = "+" + UpgradePreviewArray[1].ToString();
        RangeUpgrade.text = "+" + UpgradePreviewArray[2].ToString();
        RotationSpeedUpgrade.text = "+" + UpgradePreviewArray[3].ToString();
    }
}
