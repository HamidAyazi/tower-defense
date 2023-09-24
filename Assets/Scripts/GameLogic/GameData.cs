using System;
using UnityEngine;
using System.Collections.Generic;

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
        playerStats = new PlayerStats();
        lastPlayedLevel = new LastPlayedLevel();
    }

    [System.Serializable]
    public class PlayerStats
    {
        public string PlayerName;
        public int PlayerLevel;
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
            RemainingCoins = 0;
            GoalHP = 0;
        }
    }

    [System.Serializable]
    public class Map
    {
        /*
         * 0 - Empty
         * 1 - Spawn Tile
         * 2 - Goal Tile
         * 3 - Enemy path tile
         * 4 - Tower Tile
         */
        public int[] TileMap;
        public Wave[] Waves;
        public int MapID;
        public int XSize;
        [NonSerialized] public Vector3 SpawnPointPosition;
        [NonSerialized] public Vector3 GoalPointPosition;
    }
}
