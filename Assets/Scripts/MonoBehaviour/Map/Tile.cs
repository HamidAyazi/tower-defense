using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private GameObject Tower;
    private Shop shop;
    private UpgradeMenu upgrade;

    private void Start(){
        try
        {
            GameObject Canvas = GameObject.Find("Canvas");
            shop = Canvas.GetComponentInChildren<Shop>();
            upgrade = Canvas.GetComponentInChildren<UpgradeMenu>();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Can not find Canvas: " + e.Message);
        }
    }

    /// <summary>
    /// Open either <c>ShopPanel</c>  or <c>UpgradePanel</c> when a <c>Tile</c> is selected.
    /// </summary>
    /// <param name="eventData">Pointer click event data.</param>
    public void OnPointerClick(PointerEventData eventData){
        TileManager.Instance.SelectedTile = this;
        if (Tower != null){
            shop.CloseShopWindow();
            upgrade.OpenUpgradeWindow();
            return;
        } else {
            upgrade.CloseUpgradeWindow();
            shop.OpenShopWindow();
        }
    }

    /// <summary>
    /// Set a <c>Tower</c> to the <c>Tile</c>.
    /// </summary>
    /// <param name="Tower"><c>Tower</c> game object to set.</param>
    public void SetTower(GameObject Tower)
    {
        this.Tower = Tower;
    }

    /// <summary>
    /// A method to get <c>Tile</c>'s <c>Tower</c>.
    /// </summary>
    /// <returns><c>Tower</c> that is built on a tile.</returns>
    public GameObject GetTower()
    {
        return Tower;
    }
}
