using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageToEnemy = 1f;
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent);
            enemyComponent.health -= damageToEnemy;
            Destroy(gameObject);
        } else 
        if(other.gameObject.tag == "Boss")
        {
            other.gameObject.TryGetComponent<Boss>(out Boss bossComponent);
            bossComponent.health -= damageToEnemy;
            Destroy(gameObject);
        }else{
            Destroy(gameObject, 2);
        }
              
    }
}
