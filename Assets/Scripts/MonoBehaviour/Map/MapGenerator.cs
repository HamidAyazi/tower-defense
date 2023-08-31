using UnityEngine;
using static GameData;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs; // Prefabs for different tile types
    private Map mapData; // Your Map data

    private void Start()
    {
        Debug.Log("here");
        GenerateMap();
    }

    void GenerateMap()
    {
        mapData = SaveManager.Instance.Data.map;
        int tileSize = 1; // Size of each tile
        Vector3 spawnPosition = Vector3.zero;

        for (int x = 0; x < mapData.XSize; x++)
        {
            for (int z = 0; z < mapData.TileMap.Length / mapData.XSize; z++)
            {
                int tileIndex = x + z * mapData.XSize;
                int tileType = mapData.TileMap[tileIndex];

                GameObject tilePrefab = tilePrefabs[tileType];

                if (tilePrefab != null)
                {
                    spawnPosition.x = x * tileSize;
                    spawnPosition.z = z * tileSize;

                    Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
