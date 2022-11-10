using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boss
{
    public float timeToBoss;
    public GameObject bossPrefab;
    public int bossAmount;
    public float bossRate;
}

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public int enemyAmount;
    public float rate;
    public float timeToNextWave;
    public bool isBoss;
    public Boss boss;
    
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
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.rate);
        }
        if(wave.isBoss)
        {
            yield return new WaitForSeconds(wave.boss.timeToBoss);
            for (int i = 0; i < wave.boss.bossAmount; i++)
            { 
                SpawnEnemy(wave.boss.bossPrefab);
                yield return new WaitForSeconds(wave.boss.bossRate);
            }
           
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
