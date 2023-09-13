using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private GameObject Tower;
    private Shop shop;
    private Upgrade upgrade;

    void Start(){
        try
        {
            GameObject Canvas = GameObject.Find("Canvas");
            shop = Canvas.GetComponentInChildren<Shop>();
            upgrade = Canvas.GetComponentInChildren<Upgrade>();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Can not find Canvas: " + e.Message);
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        TileManager.Instance.SelectedTile = this;
        if (Tower != null){
            shop.CloseShopWindow();
            upgrade.OpenUpgradeWindow();
            return;
        } else {
            shop.OpenShopWindow();
        }
    }
    public void SetTower(GameObject Tower)
    {
        this.Tower = Tower;
    }
    public GameObject GetTower()
    {
        return Tower;
    }
}
