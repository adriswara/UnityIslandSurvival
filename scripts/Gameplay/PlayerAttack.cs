using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   public int damagePerAttack = 20;
   public float timeBetweenAttacks = 0.2f;
   public float timeStopped = .5f;
   public float range =  1f;
   public AudioSource attackAudio;

    float timer;
    bool enemyInRange;
    Light attackLight;
    Animator anim;
    EnemyHealth enemyHealth;
    EnemyMovement enemyMovement;
    ParticleSystem exp;

    void Awake()
    {
     attackLight = GetComponentInChildren <Light> ();
     anim = GetComponent <Animator> ();    
     exp = GetComponentInChildren <ParticleSystem> ();
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyInRange = true;
            enemyHealth = other.GetComponent<EnemyHealth> ();
            enemyMovement = other.GetComponent <EnemyMovement> ();
        }

    }
    void OnTriggerExit (Collider other){
        if (other.gameObject.CompareTag ("Enemy"))
        {
            enemyInRange = false;
        }
    }
    void Update(){
        timer += Time.deltaTime;

        if (timer >=timeStopped)
        {
            if (enemyMovement!=null)
            {
                enemyMovement.Start();
            }
        }

        if (attackLight!=null && timer >=timeStopped)
        {
            attackLight.enabled = false;
        }

        if (Input.GetButtonDown ("Fire1"))
        {
            Animate();

            if (timer >= timeBetweenAttacks && enemyInRange && enemyHealth !=null && enemyHealth.currentHealth > 0 && !GameOverManager.isGameOver)
            {
                Attack();
            }

            else{
                anim.SetTrigger("isAttack");
            }

        }

        void Animate(){
            if (attackLight != null)
            {
                attackLight.enabled = true;
            }

            anim.SetTrigger("isAttack");

            if (exp)
            {
                exp.Play();
            }

            attackAudio.Play();

        }

        void Attack(){
         if (enemyMovement != null)
         {
             enemyMovement.Stop();
         }

         timer = 0f;

         if (enemyHealth !=null)
         {
             enemyHealth.TakeDamage (damagePerAttack);
         }   

        }
    }
}
