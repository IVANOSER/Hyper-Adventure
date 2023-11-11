using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent);
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        } else {
            Destroy(gameObject, 2);
        }
              
    }
}
