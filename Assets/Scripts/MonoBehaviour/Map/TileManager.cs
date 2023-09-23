using System;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance { get; private set; }
    [NonSerialized] public Tile SelectedTile;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SellTower(){
        SelectedTile.DestroyTower();
    }
}
