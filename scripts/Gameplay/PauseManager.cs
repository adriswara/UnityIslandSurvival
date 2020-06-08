using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


#if UNITY_EDITOR
    using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{

    public AudioMixerSnapshot pause;
    public AudioMixerSnapshot play;

    Canvas canvas;
    GameObject player;
    PlayerAttack playerAttack;
    PlayerMagic playerMagic;
    AudioListener audioListener;
    CameraFollow cam;
    public Transform Target, Player;
    float mouseX, mouseY;


    public CapsuleCollider col;
   // col = GetComponent<CapsuleCollider>();
    // Start is called before the first frame update

    void Awake(){


        
        canvas = GetComponent <Canvas>();
        player = GameObject.FindGameObjectWithTag ("Player");
        audioListener = Camera.main.GetComponent <AudioListener>();
        playerAttack = player.GetComponent<PlayerAttack>();
        playerMagic = player.GetComponent <PlayerMagic>();
        cam = GetComponent <CameraFollow>();
    }




    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            canvas.enabled = !canvas.enabled;
            Pause();
        }
    }

    public void Pause(){
   Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        if(audioListener.enabled)
        {
        if (Time.timeScale == 0)
            {
                pause.TransitionTo(.01f);
               playerAttack.enabled =false;
                playerMagic.enabled=false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                
                
               
            }
            else
            {
                play.TransitionTo(.01f);
                playerAttack.enabled =true;
                playerMagic.enabled=true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
              
            }
        }
    }

    public void Quit(){
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
