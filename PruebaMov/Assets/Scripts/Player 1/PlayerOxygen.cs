﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerOxygen : MonoBehaviour {

    public int startingHealth = 1000;
    public int currentHealth;
    public Slider OxigenSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;

    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

    public float temporizador;
    public int temporizadorInt;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        temporizador -= Time.deltaTime;
        temporizadorInt = (int)temporizador;
        OxigenSlider.value = temporizadorInt;


        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;


        if (temporizadorInt == 0)
        {
            Death();
        }
    }

    public void TakeDamage(int amount)
    {
        //  damaged = true;

        //  currentHealth -= amount;

        ////  healthSlider.value = currentHealth;

        //  playerAudio.Play ();

        //  if(currentHealth <= 0 && !isDead)
        //  {
        //      Death ();
        //  }
    }


    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects ();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Oxigeno")
        {
            temporizador = Time.deltaTime * 1000;
            temporizadorInt = (int)temporizador;
            OxigenSlider.value = temporizadorInt;
        }

    }
}
