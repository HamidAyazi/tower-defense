using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private GameObject Tower;
    [SerializeField] private GameObject TowerShop;

    public void OnPointerClick(PointerEventData eventData){
        TileManager.Instance.SelectedTile = this;

        if (Tower != null){
            Debug.Log(Tower);
            TowerShop.GetComponent<Shop>().CloseShopWindow();
            // TODO - TowerUpgradeSystem.SetActive(true)
            return;
        } else {
            TowerShop.GetComponent<Shop>().OpenShopWindow();
        }
    }
    public void SetTower(GameObject Tower)
    {
        this.Tower = Tower;
    }
}
