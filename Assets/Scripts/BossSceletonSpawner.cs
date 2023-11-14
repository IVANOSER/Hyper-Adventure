using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceletonSpawner : MonoBehaviour
{
   public Transform creepSpawnPoint1;
   public Transform creepSpawnPoint2;
    public GameObject creepPrefab;


    public float timer = 1;
    private float creepTime;
    private  EnemySpawner enemySpawner;
    private void Start()
    {
        enemySpawner = GetComponentInParent<EnemySpawner>();
    }
    void Update()
    {
        spawnCreep();
        //Debug.Log("Wave"+enemySpawner.currentWaveIndex);
    }

    void spawnCreep()
    {
        creepTime -=Time.deltaTime;
        if (creepTime>0) return;
        creepTime = timer;
        var creep = Instantiate(creepPrefab, creepSpawnPoint1.position, creepSpawnPoint1.rotation);
        var creep2 = Instantiate(creepPrefab, creepSpawnPoint2.position, creepSpawnPoint2.rotation);
    }
}
