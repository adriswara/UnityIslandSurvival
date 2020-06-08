using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MagicController : MonoBehaviour
{

    public int damagePerAttack = 20;
    public float range = 1f;

    float timer;

    EnemyHealth enemyHealth;

    void OnTriggerEnter (Collider other){
        Console.Write(other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyHealth = other.GetComponent <EnemyHealth>();
            Console.Write("Is Hit");
            if (enemyHealth != null && enemyHealth.currentHealth > 0)
            {
                Attack();

                
            }
        }

        if (!other.gameObject.CompareTag ("Player"))
        {
            Destroy (gameObject,0f);
        }
    }

    // Update is called once per frame
    void Attack()
    {
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damagePerAttack);
        }
    }
}
