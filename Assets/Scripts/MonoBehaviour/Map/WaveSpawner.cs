using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> EnemyPrefabs; // List of enemy prefabs to spawn
    [SerializeField] private float spawnDelay;
    [SerializeField] private float BonusTime;

    // UI Elements
    [SerializeField] private Sprite playImage;
    [SerializeField] private Sprite pauseImage;

    private GameData.Map Map;
    private bool waveToggle = false;
    private float TimeToSpawnNewWave;
    private int currentWaveIndex = 0; // Current wave index
    private int totalEnemiesToSpawn; // Total enemies to spawn in the current wave
    private int enemiesDefeated = 0; // Number of defeated enemies

    private void Start()
    {
        Map = SaveManager.Instance.Data.map;
        foreach (Wave wave in Map.Waves)
        {
            // Add to the total enemies to spawn
            totalEnemiesToSpawn += wave.EnemyNumber;
        }
    }

    private void Update()
    {
        if (waveToggle && Time.time >= TimeToSpawnNewWave)
        {
            // Spawn the current wave
            SpawnWave(currentWaveIndex);
            currentWaveIndex++;
            if (currentWaveIndex < Map.Waves.Length)
            {
                // Spawn the current wave
                SpawnWave(currentWaveIndex);
                currentWaveIndex++;
                // Set the time to spawn the next wave
                TimeToSpawnNewWave = Time.time + Map.Waves[currentWaveIndex].TimeToSpawn + GameStats.waveInterval;
            }
            else
            {
                // All waves have been spawned, stop spawning
                waveToggle = false;
            } 
        }
    }

    private void SpawnWave(int waveIndex)
    {
        Wave waveToSpawn = Map.Waves[waveIndex];
        GameStats.Wave = waveIndex + 1;
        // Start spawning enemies with a delay
        StartCoroutine(SpawnEnemiesWithDelay(waveToSpawn.EnemyID, waveToSpawn.EnemyLevel, waveToSpawn.EnemyNumber));
    }

    private IEnumerator SpawnEnemiesWithDelay(int enemyID, int enemyLevel, int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy(enemyID, enemyLevel);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemy(int enemyID, int enemyLevel)
    {
        Transform enemyPrefab = EnemyPrefabs.Find(enemy => enemy.GetComponent<Enemy>().EnemySO.ID == enemyID);

        if (enemyPrefab != null)
        {
            Transform enemy = Instantiate(enemyPrefab, Map.SpawnPointPosition, Quaternion.identity);
            enemy.GetComponent<Enemy>().Level = enemyLevel;
            // Subscribe to the enemy's death event
            enemy.GetComponent<EnemyHealthSystem>().OnEnemyDied += HandleEnemyDeath; 
        }
        else
        {
            Debug.LogError("Enemy prefab with ID " + enemyID + " not found!");
        }
    }

    /// <summary>
    /// Event handler for enemy death
    /// </summary>
    /// <param name="sender">Enemy which invoke the event.</param>
    /// <param name="e">Passed parameters.</param>
    private void HandleEnemyDeath(object sender, System.EventArgs e)
    {
        enemiesDefeated++;
        // Check if all enemies are defeated to trigger the Victory Panel
        if (enemiesDefeated == totalEnemiesToSpawn)
        {
            GetComponent<Victory>().ShowVictoryPanel();
        }
    }

    /// <summary>
    /// Start or Stop an Enemy Wave.
    /// </summary>
    public void ToggleWave()
    {
        waveToggle = !waveToggle;
        if (waveToggle)
        {
            if (currentWaveIndex != 0 && TimeToSpawnNewWave > Time.time + BonusTime)
            {
                GameStats.Money += GameStats.earlyWaveBonusPoint;
            }
            TimeToSpawnNewWave = Time.time; // Start spawning immediately
        }
    }
}
