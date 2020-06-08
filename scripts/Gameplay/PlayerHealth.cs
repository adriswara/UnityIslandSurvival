﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour{

   public int startingHealth =100;
   public int currentHealth;
   public Slider healthSlider;
   public Image damageImage;
   public float flashSpeed = 5f;
   public Color flashColour = new Color(1f,0f,0f,0.1f);

   bool isDead;
   bool damaged;
   Animator anim;
   PlayerMovement playerMovement;


   public AudioSource playerAudio;
   public AudioClip hurtClip;
   public AudioClip deathClip;
   
   public static int heal;

   void Awake(){
       anim = GetComponent <Animator> ();
       playerMovement = GetComponent <PlayerMovement>();

       healthSlider.value = startingHealth;
       currentHealth = startingHealth;


       //sound

       playerAudio.clip = hurtClip;
   }

   void Update(){
       if (damaged)
       {
           damageImage.color = flashColour;
       }

       else
       {
           damageImage.color = Color.Lerp (damageImage.color,Color.clear,flashSpeed * Time.deltaTime);
            currentHealth+=heal;
       }
       damaged = false;
   }

   public void TakeDamage (int amount)
   {
       damaged = true;
       currentHealth-=amount;
       healthSlider.value = currentHealth;

       //sound
       playerAudio.Play();
       
       if (currentHealth<= 0 && !isDead)
       {
           Death();
       }
   }

   void Death()
   {
       isDead=true;
       anim.SetTrigger("isDead");
       playerMovement.enabled = false;

       //sound
       playerAudio.clip = deathClip;
       playerAudio.Play();
   }


   
}
