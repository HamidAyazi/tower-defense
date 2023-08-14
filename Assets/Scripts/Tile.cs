using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject Tower;
    public GameObject TowerShop;

    void OnMouseDown(){
        TileManager.Instance.SelectedTile = this;
        if (Tower != null){
            Debug.Log(Tower);
            return;
        } else {
            OpenShopWindow();
        }
    }

    void OpenShopWindow(){
        TowerShop.SetActive(true);
    }
}
