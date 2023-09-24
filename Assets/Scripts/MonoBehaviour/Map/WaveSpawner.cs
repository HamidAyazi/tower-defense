using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> EnemyPrefabs; // List of enemy prefabs to spawn
    [SerializeField] private float spawnDelay;

    private GameData.Map Map;
    private bool waveToggle = false;
    private float TimeToSpawnNewWave;
    private int currentWaveIndex = 0; // Current wave index

    private void Start()
    {
        Map = SaveManager.Instance.Data.map;
    }

    private void Update()
    {
        if (waveToggle)
        {
            if (Time.time >= TimeToSpawnNewWave)
            {
                // Spawn the current wave
                SpawnWave(currentWaveIndex);
                currentWaveIndex++;

                if (currentWaveIndex < Map.Waves.Length)
                {
                    // Set the time to spawn the next wave
                    TimeToSpawnNewWave = Time.time + Map.Waves[currentWaveIndex].TimeToSpawn;
                }
                else
                {
                    // All waves have been spawned, stop spawning
                    waveToggle = false;
                }
            }
        }
    }

    private void SpawnWave(int waveIndex)
    {
        Wave waveToSpawn = Map.Waves[waveIndex];

        // Start spawning enemies with a delay of 0.2 seconds and repeat every 0.2 seconds
        int enemiesToSpawn = waveToSpawn.EnemyNumber;

        StartCoroutine(SpawnEnemiesWithDelay(waveToSpawn.EnemyID, waveToSpawn.EnemyLevel, spawnDelay, enemiesToSpawn));
    }

    private IEnumerator SpawnEnemiesWithDelay(int enemyID, int enemyLevel, float spawnDelay, int count)
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
        }
        else
        {
            Debug.LogError("Enemy prefab with ID " + enemyID + " not found!");
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
            TimeToSpawnNewWave = Time.time; // Start spawning immediately
        }
    }
}
