using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform SpawnPoint;
    public float waveInterval = 5f;
    private float countdown = 1f;
    private int waveNumber = 0;

    public Text WaveText;

    void Start () {
        WaveText.text = waveNumber.ToString();
    }
    void Update(){
        if (countdown <= 0) {
            StartCoroutine(SpawnWave());
            countdown = waveInterval;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave(){
        waveNumber++;
        float enemyCount = CalculateEnemiesPerWave(waveNumber);
        WaveText.text = waveNumber.ToString();
        for (int i = 0; i < (int)enemyCount; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    } 

    void SpawnEnemy(){
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }

    private static float CalculateEnemiesPerWave(int waveNumber) {
        if (waveNumber <= 25)
        {
            return 5 + (waveNumber - 1) * 3;
        }
        else if (waveNumber <= 50)
        {
            return 5 + 24 * 3 + (waveNumber - 25) * 2;
        }
        else
        {
            return 5 + 24 * 3 + 25 * 2 + (waveNumber - 50) * 0.5f;
        }
    }

}

