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

    public TMPro.TextMeshProUGUI WaveText;

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
        float enemyCount = waveNumber;
        WaveText.text = waveNumber.ToString();
        for (int i = 0; i < (int)enemyCount; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
    } 

    void SpawnEnemy(){
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }

}

