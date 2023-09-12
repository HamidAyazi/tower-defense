using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnEnable runs every time the game object gets enabled
    private void OnEnable()
    {
        AttackerTowerStatus status = TileManager.Instance.SelectedTile.GetTower().GetComponent<AttackerTowerStatus>();
        float[] statusarray = status.GetLevelStatus(status.Level);
    }
    public void OpenUpgradeWindow()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void CloseUpgradeWindow()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
