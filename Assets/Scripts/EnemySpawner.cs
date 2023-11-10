using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject spawnPoint;
    public Wave[] waves;

    public int currentWaveIndex = 0;
    private bool readyToCountDown;
    private void Start()
    {

        readyToCountDown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {
        if ( currentWaveIndex >= waves.Length)
        {
            return;
        }

        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <=0 )
        {
            readyToCountDown = false;
            countdown = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }

        if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
    }

    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length){
        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], transform.position, transform.rotation);
            enemy.transform.SetParent(spawnPoint.transform);
            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            
        }
        }
    }
}

[System.Serializable]

public class Wave 
{
    public Enemy[] enemies;
    public  float timeToNextEnemy;
    public  float timeToNextWave;
    [HideInInspector] public int enemiesLeft;
}

