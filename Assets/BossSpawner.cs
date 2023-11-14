using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    private EnemySpawner enemySpawner;
    public bool bossDead;
    public GameObject bossPrefab;

     private void Start()
    {      
        SpawnBoss();
    }
    void Update()
    {
       
    }

    public void SpawnBoss()
    {              
            Instantiate(bossPrefab, spawnPoint.transform.position, transform.rotation);
                                                    
    }
}
