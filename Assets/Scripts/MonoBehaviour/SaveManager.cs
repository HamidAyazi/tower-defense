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

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Data = new GameData();
        LoadAllMaps();
        LoadPlayerStats();
        // if there are no map, for first app run
        if(Maps != null)
        {
            Data.map = new GameData.Map();
        }
    }

    private void SavePlayerStats()
    {
        FileHandler.SaveData(Data.playerStats, PlayerStatsFileName);
    }

    private void LoadPlayerStats()
    {
        Data.playerStats = FileHandler.LoadData<GameData.PlayerStats>(PlayerStatsFileName);
        if (Data.playerStats == null)
        {
            Data.playerStats = new GameData.PlayerStats();
        }
    }

    private void SaveLastPlayedMap()
    {
        FileHandler.SaveData(Data.lastPlayedLevel, LastPlayedLevelFileName);
    }
    private void SaveAllMaps()
    {
        // Save map list to the file
        FileHandler.SaveData<List<GameData.Map>>(Maps, MapsFileName);

    }
    private void LoadAllMaps()
    {
        Maps = FileHandler.LoadData<List<GameData.Map>>(MapsFileName);
    }

    private void OnApplicationQuit()
    {
        SavePlayerStats();
        SaveLastPlayedMap();
        SaveAllMaps();
    }

    public void LoadLastPlayedMap()
    {
        FileHandler.LoadData<GameData.LastPlayedLevel>(LastPlayedLevelFileName);
    }

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

    public GameData.Map FindMap(int MapID)
    {
            // Load a specific map
            return Maps.Find(Map => Map.MapID == MapID);
    }
    
}
