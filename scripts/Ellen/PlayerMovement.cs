using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    public int pickUpScore = 1;
    public AudioSource pickUpAudio;

    public float normalSpeed = 7;
  
   
    public bool isWalking = false;
  


    Animator anim;
    Rigidbody playerRigidbody;
    public LayerMask groundLayers;
    public CapsuleCollider col;
    

    
    void Awake(){
        anim = GetComponent <Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       if (!GameOverManager.isGameOver){

       
     

        //movement
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

      

            Move(hor,ver);
            Animating(hor,ver);
       }
    }
    //player movement
    void Move(float hor, float ver){
       
        Vector3 playerMovement = new Vector3(hor,0f,ver) * normalSpeed * Time.deltaTime;
        transform.Translate(playerMovement,Space.Self);

       
      
    }

    //on ground checker
    private bool IsGrounded(){
       return Physics.CheckCapsule(col.bounds.center, new Vector3 (col.bounds.center.x,
         col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }


    //animate 
    void Animating(float hor, float ver){
        bool walking = hor != 0f || ver != 0f;

     

        if(isWalking){
            anim.SetBool("isWalking",walking);
        }
       if(!isWalking){
           anim.SetBool("isWalking", walking);
       }
    }

    void OnTriggerEnter (Collider other){
      if(other.gameObject.CompareTag("Pick up")){
            ScoreManager.score += pickUpScore;
            PlayerHealth.heal += 10;
            pickUpAudio.Play();
            other.gameObject.SetActive(false);
            GameOverManager.pickupCount++;
        }

        

    }
}
