using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    public GameData Data;

    private List<GameData.Map> Maps;

    [SerializeField] private string PlayerStatsFileName;
    [SerializeField] private string MapsFileName;
    [SerializeField] private string LastPlayedLevelFileName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }
        Instance = this;
        Maps = MapInit.GetDefaultMaps();
        Data = new GameData();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadPlayerStats();
        LoadAllMaps();
        //LoadLastPlayedMap();
    }
    private void OnApplicationQuit()
    {
        SavePlayerStats();
        SaveAllMaps();
        //SaveLastPlayedMap();
    }
    private void LoadPlayerStats()
    {
        GameData.PlayerStats LoadedStats = FileHandler.LoadData<GameData.PlayerStats>(PlayerStatsFileName);
        if (LoadedStats == null)
        {
            Debug.LogError("Can not find any saved player stats. Loading default player.");
            return;
        }
        Data.playerStats = LoadedStats;
    }

    private void LoadAllMaps()
    {
        List <GameData.Map> MapsToLoad = FileHandler.LoadData<List<GameData.Map>>(MapsFileName);
        if (MapsToLoad == null)
        {
            Debug.LogError("Can not find Maps file. Loading default maps.");
            return;
        }
        foreach (GameData.Map map in MapsToLoad)
        {
            if (Maps.Find(Map => Map.MapID == map.MapID) == null)
            {
                Debug.Log("HERE");
                Maps.Add(map);
            }
        }
    }


    /// <summary>
    /// Load <c>LastPlayedMap</c> from device.
    /// </summary>
    public void LoadLastPlayedMap()
    {
        Data.lastPlayedLevel = FileHandler.LoadData<GameData.LastPlayedLevel>(LastPlayedLevelFileName);
    }
    private void SavePlayerStats()
    {
        FileHandler.SaveData(Data.playerStats, PlayerStatsFileName);
    }
    private void SaveAllMaps()
    {
        // Save map list to the file
        FileHandler.SaveData<List<GameData.Map>>(Maps, MapsFileName);
    }
    private void SaveLastPlayedMap()
    {        
        FileHandler.SaveData(Data.lastPlayedLevel, LastPlayedLevelFileName);
    }

    /// <summary>
    /// Add new created <c>Map</c> to <c>Maps</c> list.
    /// </summary>
    public void SaveMap()
    {
        // Save new created map
        if (FindMap(Data.map.MapID) == null)
        {
            Maps.Add(Data.map);
        }
        else
        {
            Debug.LogError("Map with same ID has been found");
        }
            
    }

    /// <summary>
    /// Get a <c>Map</c> from <c>Maps</c> List.
    /// </summary>
    /// <param name="MapID"><c>ID</c> of the wanted <c>Map</c></param>
    /// <returns><c>Map</c> if it is found or Null if it's not.</returns>
    public GameData.Map FindMap(int MapID)
    {
            // Load a specific map
            return Maps.Find(Map => Map.MapID == MapID);
    }
    
}
