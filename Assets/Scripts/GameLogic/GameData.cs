using System;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public PlayerStats playerStats;
    public LastPlayedLevel lastPlayedLevel;
    public Map map;

    public GameData()
    {
        map = new Map();
        lastPlayedLevel = new LastPlayedLevel();
    }

    [System.Serializable]
    public class PlayerStats
    {
        public string PlayerName;
        public int PlayerLevel;
        public Settings PlayerSettings;
        public TalentTree PlayerTalentTree;

        public PlayerStats()
        {
            PlayerName = "New Player";
            PlayerLevel = 1;
            PlayerSettings = new Settings();
            PlayerTalentTree = new TalentTree();
        }
    }

    [System.Serializable]
    public class LastPlayedLevel
    {
        public Map map;
        public int RemainingCoins;
        public int GoalHP;

        public LastPlayedLevel()
        {
            this.map = new Map();
            RemainingCoins = 0;
            GoalHP = 0;
        }
    }

    [System.Serializable]
    public class Map
    {
        /*
         * 0 - Empty
         * 1 - Home Tile
         * 2 - Goal Tile
         * 3 - Enemy path tile
         * 4 - Tower Tile
         */
        public int MapID;
        public int XSize;
        public int[] TileMap;
        [NonSerialized] public Vector3 SpawnPointPosition;

        public Map()
        {
            MapID = 0;
            XSize = 10;
            TileMap = new int[] {0 ,0 ,0 ,0 ,0 ,1 ,0 ,0 ,0 ,0 ,
                                 0 ,0 ,0 ,0, 4, 3 ,3 ,3 ,4 ,0 ,
                                 0 ,0 ,0 ,0 ,0 ,0 ,4 ,3 ,0 ,0 ,
                                 0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,0 ,0 ,
                                 0 ,0 ,0 ,0 ,0 ,0 ,4 ,3 ,0 ,0 ,
                                 0 ,0 ,0 ,0 ,0 ,0 ,4 ,3 ,0 ,0 ,
                                 0 ,0 ,3 ,3 ,3 ,3 ,3 ,3 ,0 ,0 ,
                                 0 ,0 ,3 ,4 ,0 ,4 ,0 ,4 ,0 ,0 ,
                                 0 ,0 ,3 ,3 ,3 ,3 ,0 ,0 ,0 ,0 ,
                                 0 ,0 ,0 ,0 ,4 ,2 ,0 ,0 ,0 ,0};
        }
    }
}
