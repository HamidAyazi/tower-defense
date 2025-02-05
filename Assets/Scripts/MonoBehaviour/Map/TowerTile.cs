using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerTile : MonoBehaviour, IPointerClickHandler
{
    private GameObject Tower;
    private Shop shop;
    private UpgradeMenu upgrade;

    [NonSerialized] public AttackerTowerScriptableObject AttackerTowerSO;

    private void Start(){
        GameObject Canvas = null;
        try
        {
            Canvas = GameObject.Find("Canvas");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Can not find Canvas: " + e.Message);
        }
        if (Canvas != null)
        {
            shop = Canvas.GetComponentInChildren<Shop>();
            upgrade = Canvas.GetComponentInChildren<UpgradeMenu>();
        }
        else
        {
            Debug.LogError("Canvas is Null. Distorying GameObject " + this.name);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Open either <c>ShopPanel</c>  or <c>UpgradePanel</c> when a <c>Tile</c> is selected.
    /// </summary>
    /// <param name="eventData">Pointer click event data.</param>
    public void OnPointerClick(PointerEventData eventData){
        TileManager.Instance.SelectedTile = this;
        if (Tower == null){
            upgrade.CloseUpgradeWindow();
            shop.OpenShopWindow();
        } else {
            shop.CloseShopWindow();
            upgrade.OpenUpgradeWindow();
        }
    }

    /// <summary>
    /// Destory deployed tower and set tile's refrenece to null.
    /// </summary>
    public void DestroyTower(){
    if (Tower != null)
    {
        SoundManager.PlaySound(Sound.TowerDespawn, transform.position, Tower.name);
        Destroy(Tower);
        Tower = null;
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
