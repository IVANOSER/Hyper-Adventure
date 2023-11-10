using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private float speed;
    private EnemySpawner enemySpawner;
    public bool dead = false;
    private void Start()
    {
        enemySpawner = GetComponentInParent<EnemySpawner>();
    }
    void Update()
    {
        transform.Translate(transform.forward * -speed * Time.deltaTime, 0f);

        if (dead == true)
        {
            Destroy(gameObject);
            enemySpawner.waves[enemySpawner.currentWaveIndex].enemiesLeft--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadLine")
        dead = true;
    }
}
