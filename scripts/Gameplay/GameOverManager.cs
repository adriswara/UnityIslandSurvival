using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{

    public static int pickupCount;
    public static int maxPickup = 7;
    public static bool isGameOver;

    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public Canvas minimapCanvas;
    public Animator loseAnim;
    public Animator winAnim;
    public string scene = "Test";

    float restartTimer;


    // Start is called before the first frame update
    void Awake()
    {
        pickupCount = 0;
        isGameOver = false;
        EnemyManager.enemyCount = 0;

        minimapCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupCount == maxPickup)
        {
            Win();
        }

        if (playerHealth.currentHealth <= 0)
        {
            Lose();
        }
    }

    void Win (){
        minimapCanvas.enabled = false;

        winAnim.SetTrigger("Win");

        isGameOver = true;

        restartTimer += Time.deltaTime;

        if (restartTimer >= restartDelay)
        {
            SceneManager.LoadScene(scene,LoadSceneMode.Single);
        }
    }

    void Lose(){
        minimapCanvas.enabled = false;

        loseAnim.SetTrigger("Lose");

        isGameOver = true;

        restartTimer += Time.deltaTime;

        if (restartTimer >= restartDelay)
        {
            SceneManager.LoadScene(scene,LoadSceneMode.Single);
        }
    }

}
