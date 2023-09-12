using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private GameObject Tower;
    private Shop shop;

    void Start(){
        try
        {
            GameObject Canvas = GameObject.Find("Canvas");
            shop = Canvas.GetComponentInChildren<Shop>();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Can not find Canvas: " + e.Message);
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        TileManager.Instance.SelectedTile = this;

        if (Tower != null){
            Debug.Log(Tower);
            shop.CloseShopWindow();
            // TODO - TowerUpgradeSystem.SetActive(true)
            return;
        } else {
            shop.OpenShopWindow();
        }
    }
    public void SetTower(GameObject Tower)
    {
        this.Tower = Tower;
    }
}
