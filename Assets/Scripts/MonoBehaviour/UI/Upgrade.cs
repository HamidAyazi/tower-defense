using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI Damage;
    [SerializeField] private TMPro.TextMeshProUGUI AttackSpeed;
    [SerializeField] private TMPro.TextMeshProUGUI Range;
    [SerializeField] private TMPro.TextMeshProUGUI RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpgradeWindow()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        SetStatusText();
    }
    public void CloseUpgradeWindow()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void SetStatusText()
    {
        AttackerTowerStatus Status = TileManager.Instance.SelectedTile.GetTower().GetComponent<AttackerTowerStatus>();
        float[] StatusArray = Status.GetLevelStatus(Status.CurrentLevel);
        Debug.Log(StatusArray);
        Damage.text = StatusArray[0].ToString();
        AttackSpeed.text = StatusArray[1].ToString();
        Range.text = StatusArray[2].ToString();
        RotationSpeed.text = StatusArray[3].ToString();
    }
}
