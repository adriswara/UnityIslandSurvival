using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    Transform player;
    Animator anim;
    NavMeshAgent nav;
    PlayerHealth playerHealth;

   bool playerDead;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        anim = GetComponent <Animator> ();
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentHealth > 0 && nav.enabled && !GameOverManager.isGameOver)
        {
            nav.SetDestination(player.position);
        }

        else
        {
            Stop();
        }
    }
    public void Stop()
    {
        playerDead = true;
        anim.SetTrigger("playerDead");
        nav.enabled = false;
    }

    public void Start(){
        nav.enabled = true;
    }
}
