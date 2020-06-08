using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static int enemyCount = 0;
    public static int maxEnemy = 50;


    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime =3f;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Spawn",spawnTime,spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount>=maxEnemy)
        {
            CancelInvoke();
        }
        else{
            InvokeRepeating("Spawn",0f,spawnTime);
        }
    }

    void Spawn()
    {
        if (playerHealth.currentHealth<=0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0,spawnPoints.Length);
        Instantiate (enemy,spawnPoints[spawnPointIndex].position,spawnPoints[spawnPointIndex].rotation);

        enemyCount++;
    }

}
