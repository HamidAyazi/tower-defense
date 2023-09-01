using UnityEngine;
using static GameData;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs; // Prefabs for different tile types
    private Map mapData; // Your Map data
    private int tileSize = 1; // Size of each tile

    private void Start()
    {
        mapData = SaveManager.Instance.Data.map;
        GenerateMap();
    }

    void GenerateMap()
    {
        Vector3 spawnPosition = Vector3.zero;
        Vector3 cameraCenter = Camera.main.transform.position;

        // Calculate the starting position for the map based on the camera's position and the map's size
        float mapWidth = mapData.XSize * tileSize;
        float mapHeight = (mapData.TileMap.Length / mapData.XSize) * tileSize;
        Vector3 mapStartPosition = cameraCenter - new Vector3(mapWidth / 2f, 0f, mapHeight / 2f);
        spawnPosition.z = 0;

        for (int y = 0; y < mapData.TileMap.Length / mapData.XSize; y++)
        {
            for (int x = 0; x < mapData.XSize; x++)
            {
                int tileIndex = x + y * mapData.XSize;
                int tileType = mapData.TileMap[tileIndex];

                GameObject tilePrefab = tilePrefabs[tileType];

                if (tilePrefab != null)
                {
                    spawnPosition.x = mapStartPosition.x + x * tileSize;
                    spawnPosition.y = mapStartPosition.y - y * tileSize;

                    Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
                }
                if(tileIndex == 1)
                {
                    SaveManager.Instance.Data.map.SpawnPointPosition = spawnPosition;
                }
            }
        }
    }
}
