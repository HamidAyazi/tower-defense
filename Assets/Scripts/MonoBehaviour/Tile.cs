using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private GameObject Tower;
    private Shop shop;
    [SerializeField] private GameObject TowerShop;


    void Start(){
        shop = TowerShop.GetComponent<Shop>();
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
