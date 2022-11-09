using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Wave
{
    public GameObject enemy;
    public int enemyAmount;
    public float rate;
    public float timeToNextWave;
}
public class WaveSpawner : MonoBehaviour
{
    private float timetoStart = 3f;
    public Wave[] waves;
    private int waveIndex = 0;
    private Transform spawnPoint;


    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Start").transform;
        WaveStart();
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(timetoStart);
        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.enemyAmount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.rate);
        }
        yield return new WaitForSeconds(wave.timeToNextWave);
        waveIndex++;
        timetoStart = 0;
        WaveStart();

        if (waveIndex == waves.Length)
        {
            Debug.Log("wygrales");
            this.enabled = false;
        }
    }
        
    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
    private void WaveStart()
    {
        StartCoroutine(SpawnWave());
    }
}
