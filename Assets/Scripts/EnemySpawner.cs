using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnSpots;
    [SerializeField] private Transform spawnBoss;
    private int randomSpawnSpot;
    [SerializeField] private float countdown;
    public GameObject winWindow;  

    public Wave[] waves;
    public int currentWaveIndex = 0;
    private bool readyToCountDown;


    private void Start()
    {
        Time.timeScale = 1f;
        readyToCountDown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {
        randomSpawnSpot = Random.Range(0, spawnSpots.Length);
        if ( currentWaveIndex >= waves.Length)
        {    
            FinishLevel();
            winWindow.SetActive(true);  
            Time.timeScale = 0f;                   
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
            Debug.Log("killed wave"+ currentWaveIndex);
            readyToCountDown = true;
            currentWaveIndex++;           
        }

    
        
    }

    private IEnumerator SpawnWave()

    {
        if (currentWaveIndex < waves.Length){
        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {   
            if (waves[currentWaveIndex].bossWave == true)
            {
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnBoss.position, Quaternion.identity);
                enemy.transform.SetParent(spawnBoss);        
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }else{
            Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnSpots[randomSpawnSpot].position, Quaternion.identity);
            enemy.transform.SetParent(spawnSpots[randomSpawnSpot]);        
            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
       
        }
    }

    public void FinishLevel()
    {
        PlayerPrefs.SetInt("currentScene", SceneManager.GetActiveScene().buildIndex);        
    }
}

[System.Serializable]

public class Wave 
{
    public Enemy[] enemies;
    public  float timeToNextEnemy;
    public  float timeToNextWave;
    [HideInInspector] public int enemiesLeft;
    public bool bossWave;
}


