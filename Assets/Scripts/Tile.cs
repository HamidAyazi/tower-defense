using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public GameObject Tower;
    public GameObject TowerShop;

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("Clicked");
        TileManager.Instance.SelectedTile = this;
        if (Tower != null){
            Debug.Log(Tower);
            TowerShop.SetActive(false);
            return;
        } else {
            OpenShopWindow();
        }
    }

    // void OnMouseDown(){
    //     Debug.Log("Clicked");
    //     TileManager.Instance.SelectedTile = this;
    //     if (Tower != null){
    //         Debug.Log(Tower);
    //         TowerShop.SetActive(false);
    //         return;
    //     } else {
    //         OpenShopWindow();
    //     }
    // }

    void OpenShopWindow(){
        TowerShop.SetActive(true);
    }
}
