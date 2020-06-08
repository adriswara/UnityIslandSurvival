using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioSource enemyAudio;
    public AudioClip deathClip;
    public AudioClip hurtclip;
    public float SinkingTime =1f;
    public float DisplayTime =1f;

    Animator anim;
    bool isDead;
    bool isSinking;
    float timer;
    bool isAttacked;
    Canvas canvas;
    Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent <Animator>();
        canvas = GetComponentInChildren <Canvas> ();
        slider = GetComponentInChildren <Slider> ();

        canvas.enabled = false;

        currentHealth = startingHealth;

        enemyAudio.clip = hurtclip;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (isAttacked && timer > DisplayTime)
        {
            isAttacked =false;
            canvas.enabled = false;
        }

        if (isSinking && timer > SinkingTime)
        {
            transform.Translate (-Vector3.up * sinkSpeed *Time.deltaTime);
        }
    }

    public void TakeDamage(int amount){
        if (isDead)
        
            return;

        enemyAudio.Play();

        currentHealth -= amount;

        timer =0;
        isAttacked =true;
        canvas.enabled = true;
        slider.value = currentHealth;

        if (currentHealth <=0)
        {
                Death();
        }
    }

    void Death(){
        isDead = true;

        enemyAudio.clip = deathClip;
        enemyAudio.Play() ;

        StartSinking ();
    }

    public void StartSinking(){
        GetComponent <NavMeshAgent> ().enabled = false;

        GetComponent <Rigidbody> ().isKinematic = true;

        timer = 0;
        isSinking = true;

        ScoreManager.score += scoreValue;

        EnemyManager.enemyCount--;

        Destroy (gameObject,2f);


    }
}
