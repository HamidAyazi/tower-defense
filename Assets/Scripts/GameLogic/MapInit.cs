using System.Collections.Generic;
using UnityEngine;

public static class MapInit
{
    private static Wave[] GetWaves(int MapID)
    {
        Wave[] waves = new Wave[10];
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i] = new Wave()
            {
                EnemyID = 1,
                EnemyNumber = MapID + i,
                EnemyLevel = Random.Range(1 , MapID),
                TimeToSpawn = 10f,
            };
        }
        return waves;
    }

    public static List<GameData.Map> GetDefaultMaps()
    {
        List<GameData.Map> MapsToLoad = new List<GameData.Map>();
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 1,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 2, 0, 3, 3, 3, 0, 0,
                0, 0, 0, 3, 4, 3, 4, 3, 0, 0,
                0, 0, 0, 3, 4, 1, 4, 3, 4, 0,
                0, 0, 0, 3, 4, 0, 4, 3, 4, 0,
                0, 4, 0, 3, 3, 3, 0, 3, 0, 0,
                0, 4, 0, 0, 0, 3, 4, 3, 0, 0,
                0, 0, 4, 0, 0, 3, 3, 3, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 4, 4, 0
            },
            Waves = GetWaves(1)
        });

        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 2,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
                0, 0, 0, 0, 4, 3, 3, 3, 4, 0,
                0, 0, 0, 0, 0, 0, 4, 3, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 3, 0, 0,
                0, 0, 0, 0, 0, 0, 4, 3, 0, 0,
                0, 0, 0, 0, 0, 0, 4, 3, 0, 0,
                0, 0, 3, 3, 3, 3, 3, 3, 0, 0,
                0, 0, 3, 4, 0, 4, 0, 4, 0, 0,
                0, 0, 3, 3, 3, 3, 0, 0, 0, 0,
                0, 0, 0, 0, 4, 2, 0, 0, 0, 0
            },
            Waves = GetWaves(2)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 3,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 
                0, 0, 0, 3, 3, 3, 3, 3, 3, 0, 
                0, 0, 4, 3, 4, 0, 4, 4, 3, 4,
                0, 2, 3, 3, 0, 0, 0, 4, 3, 4, 
                0, 0, 4, 0, 0, 0, 3, 3, 3, 0, 
                4, 0, 0, 0, 0, 4, 3, 4, 0, 0, 
                0, 4, 4, 0, 1, 3, 3, 0, 0, 4, 
                0, 0, 0, 0, 0, 0, 0, 0, 4, 0
            },
            Waves = GetWaves(3)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 4,
            XSize = 11,
            TileMap = new int[]
            {
                0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0,
                0, 0, 3, 3, 3, 2, 0, 4, 4, 0, 0,
                0, 4, 3, 0, 0, 0, 0, 0, 4, 0, 0,
                0, 4, 3, 0, 0, 0, 4, 4, 0, 4, 0,
                4, 0, 3, 0, 0, 1, 3, 3, 3, 0, 4,
                0, 4, 3, 0, 0, 4, 0, 0, 3, 4, 0,
                0, 4, 3, 0, 0, 0, 0, 0, 3, 4, 0,
                0, 0, 3, 3, 3, 3, 3, 3, 3, 0, 0,
                0, 0, 0, 4, 4, 0, 4, 4, 0, 0, 0,
                0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(4)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 5,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 4, 0,
                4, 0, 0, 0, 0, 4, 4, 0, 0, 0,
                4, 0, 0, 2, 3, 3, 3, 4, 0, 0,
                0, 4, 0, 0, 4, 0, 3, 0, 0, 0,
                0, 3, 3, 3, 3, 4, 3, 0, 0, 0,
                0, 3, 0, 4, 3, 0, 3, 4, 0, 0,
                0, 3, 4, 1, 3, 4, 3, 4, 0, 0,
                0, 3, 4, 4, 0, 4, 3, 0, 0, 0,
                4, 3, 3, 3, 3, 3, 3, 0, 0, 0,
                0, 0, 0, 4, 4, 0, 0, 4, 0, 0
            },
            Waves = GetWaves(5)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 6,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 3, 0, 0, 0, 0,
                1, 4, 0, 0, 0, 3, 3, 3, 3, 0,
                3, 0, 4, 4, 0, 3, 4, 4, 3, 0,
                3, 4, 3, 4, 0, 3, 4, 3, 3, 0,
                3, 3, 3, 4, 4, 3, 0, 3, 0, 0,
                4, 4, 3, 3, 3, 3, 4, 3, 0, 0,
                0, 0, 3, 4, 4, 0, 4, 3, 0, 0,
                0, 4, 4, 4, 0, 4, 4, 3, 0, 0,
                2, 3, 3, 3, 3, 3, 3, 3, 0, 0,
                0, 4, 4, 0, 0, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(6)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 7,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 2, 0, 0, 0, 1, 0, 0,
                0, 0, 4, 3, 0, 0, 0, 3, 0, 0,
                0, 3, 3, 3, 0, 0, 4, 3, 0, 0,
                0, 3, 4, 4, 0, 0, 4, 3, 0, 0,
                0, 3, 3, 3, 4, 0, 0, 3, 4, 0,
                0, 0, 4, 3, 4, 4, 0, 3, 4, 0,
                0, 0, 4, 3, 3, 3, 4, 3, 4, 0,
                0, 0, 0, 0, 4, 3, 4, 3, 0, 0,
                0, 0, 0, 0, 0, 3, 3, 3, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(7)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 8,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 3, 2, 0, 1, 3, 0, 0, 0,
                0, 4, 3, 4, 4, 4, 3, 4, 0, 0,
                3, 3, 3, 0, 0, 0, 3, 3, 3, 0,
                3, 4, 0, 0, 0, 4, 0, 4, 3, 0,
                3, 4, 0, 0, 4, 0, 0, 4, 3, 0,
                3, 4, 0, 4, 0, 0, 0, 4, 3, 0,
                3, 3, 3, 0, 0, 0, 3, 3, 3, 0,
                0, 4, 3, 4, 4, 4, 3, 4, 0, 0,
                0, 0, 3, 3, 3, 3, 3, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(8)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 9,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 2, 0, 4, 3, 3, 3, 0, 0,
                0, 3, 3, 4, 3, 3, 4, 3, 4, 0,
                0, 3, 4, 4, 3, 4, 4, 3, 0, 0,
                0, 3, 3, 4, 3, 4, 3, 3, 0, 0,
                0, 4, 3, 3, 3, 4, 1, 4, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(9)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 10,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 3, 3, 3, 1, 0,
                0, 0, 4, 0, 0, 3, 4, 0, 0, 0,
                0, 0, 0, 0, 4, 3, 3, 3, 3, 0,
                0, 4, 4, 4, 4, 4, 4, 4, 3, 0,
                3, 3, 3, 3, 3, 3, 3, 3, 3, 0,
                3, 4, 4, 4, 4, 4, 4, 4, 0, 0,
                3, 3, 3, 3, 4, 0, 0, 0, 0, 0,
                0, 0, 4, 3, 0, 0, 4, 0, 0, 0,
                2, 3, 3, 3, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(10)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 11,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 4, 3, 3, 3, 3, 3, 2, 0, 0,
                0, 3, 3, 4, 4, 4, 0, 0, 0, 0,
                0, 3, 4, 4, 3, 3, 3, 3, 0, 0,
                0, 3, 4, 3, 3, 4, 4, 3, 0, 0,
                0, 3, 4, 3, 4, 4, 3, 3, 0, 0,
                0, 3, 0, 3, 4, 3, 3, 4, 0, 0,
                0, 3, 3, 3, 0, 1, 4, 4, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(11)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 12,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 3, 3, 3, 3, 0, 2, 3, 3,
                0, 0, 3, 4, 4, 3, 0, 0, 4, 3,
                0, 0, 3, 4, 4, 3, 0, 0, 4, 3,
                0, 0, 3, 4, 4, 3, 0, 4, 4, 3,
                3, 3, 3, 4, 3, 3, 0, 3, 3, 3,
                3, 4, 4, 0, 3, 4, 4, 3, 0, 0,
                3, 4, 0, 0, 3, 4, 4, 3, 0, 0,
                3, 3, 1, 0, 3, 3, 3, 3, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(12)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 13,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                3, 3, 3, 3, 3, 3, 3, 0, 0, 0,
                3, 4, 4, 4, 4, 0, 3, 4, 0, 0,
                3, 3, 3, 3, 3, 4, 3, 0, 4, 0,
                0, 4, 0, 4, 3, 4, 3, 3, 3, 0,
                4, 3, 3, 3, 3, 0, 4, 4, 3, 0,
                4, 3, 0, 4, 0, 0, 0, 0, 3, 4,
                4, 3, 3, 3, 3, 4, 0, 4, 3, 0,
                0, 4, 4, 0, 1, 0, 4, 3, 3, 3,
                0, 0, 0, 0, 0, 0, 0, 2, 4, 0
            },
            Waves = GetWaves(13)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 14,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 3, 3, 3, 3, 3, 0, 0,
                1, 0, 0, 3, 4, 0, 4, 3, 0, 0,
                3, 3, 4, 3, 0, 4, 3, 3, 0, 0,
                4, 3, 4, 3, 4, 0, 3, 4, 0, 0,
                3, 3, 0, 3, 0, 4, 3, 0, 0, 0,
                3, 4, 4, 3, 4, 0, 3, 0, 0, 0,
                3, 3, 3, 3, 0, 4, 3, 0, 0, 0,
                0, 4, 4, 0, 4, 0, 3, 0, 0, 0,
                2, 3, 3, 3, 3, 3, 3, 0, 0, 0
            },
            Waves = GetWaves(14)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 15,
            XSize = 10,
            TileMap = new int[]
            {
                0, 0, 4, 0, 0, 0, 0, 4, 4, 0,
                0, 4, 4, 4, 0, 0, 0, 0, 4, 4,
                0, 0, 4, 0, 0, 0, 4, 3, 0, 0,
                4, 0, 0, 0, 0, 3, 3, 3, 3, 0,
                0, 0, 0, 0, 0, 3, 3, 4, 3, 0,
                3, 3, 3, 3, 0, 3, 4, 4, 3, 0,
                0, 0, 3, 0, 0, 2, 0, 0, 3, 4,
                0, 0, 3, 4, 4, 4, 0, 4, 3, 4,
                0, 0, 1, 3, 3, 3, 3, 3, 3, 0,
                0, 0, 0, 4, 4, 0, 0, 0, 0, 0
            },
            Waves = GetWaves(15)
        });
        MapsToLoad.Add(new GameData.Map()
        {
            MapID = 16,
            XSize = 11,
            TileMap = new int[]
            {
                0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 3, 3, 3, 0, 0, 0, 0,
                0, 0, 4, 3, 3, 0, 3, 4, 0, 0, 0,
                0, 0, 3, 3, 0, 3, 3, 4, 4, 0, 0,
                0, 3, 3, 0, 3, 3, 4, 3, 3, 3, 0,
                4, 3, 0, 1, 3, 4, 3, 3, 0, 3, 4,
                0, 3, 3, 0, 4, 3, 3, 0, 3, 3, 0,
                0, 0, 3, 3, 0, 2, 0, 3, 3, 0, 0,
                0, 0, 4, 3, 3, 0, 3, 3, 4, 0, 0,
                0, 0, 0, 0, 3, 3, 3, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 4, 0, 0, 0, 0 ,0
            },
            Waves = GetWaves(16)
        });


        return MapsToLoad;
    }

}
