using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject hud;
    public GameObject inv;
    public GameObject deathScreen;
    public GameObject player;
    public AudioSource loseSound;

    public float health = 100f;
    public float shield = 0f;



    void Start()
    {
        deathScreen.SetActive(false);
    }



    void Update()
    {

        if(health <= 0)
        {
            AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach(AudioSource aud in audios)
                aud.volume = 0;

            loseSound.volume = 1;
            loseSound.Play();
            player.GetComponent<CharacterController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            hud.SetActive(false);
            inv.SetActive(false);
            deathScreen.SetActive(true);
        }

        if (health > 100)
        {
            health = 100;
        } else if (health < 0)
        {
            health = 0;
        }

        if (shield > 50)
        {
            shield = 50;
        } else if (shield < 0)
        {
            shield = 0;
        }

    }
}
