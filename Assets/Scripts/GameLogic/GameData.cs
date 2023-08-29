[System.Serializable]
public class GameData
{
    public PlayerStats playerStats;
    public LastPlayedLevel lastPlayedLevel;
    public Map map;

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
    }

    [System.Serializable]
    public class Map
    {
        /*
         * 0 - Empty
         * 1 - Home Tile
         * 2 - Goal Tile
         * 3 - Enemy path Tile
         * 4 - Tower Tile
         */
        public int MapID;
        public int[,] TileMap;
        public int XSize;
        public int YSize;
    }
}
