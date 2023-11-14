using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
   [SerializeField] private float speed;
    //private EnemySpawner enemySpawner;
    public bool dead = false;
    public float health, maxHealth = 100f;
    public float damageToPlayer = 5f;
    //public bool nextWave;
    private void Start()
    {
       // enemySpawner = GetComponentInParent<EnemySpawner>();
        health = maxHealth;
    }
    void Update()
    {
        transform.Translate(transform.forward * -speed * Time.deltaTime, 0f);

        if (dead == true || health <= 0)
        {
            //nextWave = true;
            Destroy(gameObject);
           // enemySpawner.waves[enemySpawner.currentWaveIndex].enemiesLeft--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadLine"){
        other.gameObject.TryGetComponent<PlayerHP>(out PlayerHP playerComponent);
        playerComponent.healthP -= damageToPlayer;
        dead = true;
        }
    }
       

}
