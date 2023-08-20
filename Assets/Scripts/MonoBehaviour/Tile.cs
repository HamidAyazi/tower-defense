using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public GameObject Tower;
    public Shop TowerShop;

    public void Start()
    {
    }
    public void OnPointerClick(PointerEventData eventData){
        TileManager.Instance.SelectedTile = this;
        if (Tower != null){
            Debug.Log(Tower);
            TowerShop.CloseShopWindow();
            // TODO - TowerUpgradeSystem.SetActive(true)
            return;
        } else {
            TowerShop.OpenShopWindow();
        }
    }
}
