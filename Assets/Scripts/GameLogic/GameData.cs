using System;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public PlayerStats playerStats;
    public LastPlayedLevel lastPlayedLevel;
    public Map map;

    /// <summary>
    /// Constructor for <c>GameData</c> class. Loads new <c>Map</c> and new <c>PlayerStats</c>
    /// </summary>
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

        /// <summary>
        /// Constructor for <c>PlayerStats</c> class.
        /// It sets <c>PlayerName</c> to 'New Player' and <c>PlayerLevel</c> to 1.
        /// It also Loads default <c>PlayerSettings</c> and <c>PlayerTalentTree</c>.
        /// </summary>
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

        /// <summary>
        /// Constructor for <c>LastPlayedLevel</c> class.
        /// This class is under developement and it's not finished yet.
        /// </summary>
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

        /// <summary>
        /// Constructor for <c>Map</c> class.
        /// It set default <c>MapID</c> tp 0, <c>XSize</c> to 10 and contains default map array.
        /// </summary>
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
