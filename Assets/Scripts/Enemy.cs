using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private float speed;
    private EnemySpawner enemySpawner;
    //private PlayerHP playerHP;
    public bool dead = false;
    public float health, maxHealth = 100f;
    private void Start()
    {
        enemySpawner = GetComponentInParent<EnemySpawner>();
        health = maxHealth;
    }
    void Update()
    {
        transform.Translate(transform.forward * -speed * Time.deltaTime, 0f);

        if (dead == true || health <= 0)
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
    
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

}
