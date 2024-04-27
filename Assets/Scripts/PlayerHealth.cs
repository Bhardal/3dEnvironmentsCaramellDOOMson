using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject deathMenu;
    public AudioSource loseSound;

    public float health = 100f;
    public float shield = 0f;

    public bool died;
    public bool on;
    public bool off;



    void Start()
    {
        died = false;
        deathMenu.SetActive(false);
        off = true;
        on = false;
    }



    void Update()
    {

        if(health <= 0 && died == false)
        {
            died = true;
            AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach(AudioSource aud in audios)
                aud.volume = 0;

            loseSound.volume = 1;
            loseSound.Play();
            deathMenu.SetActive(true);
            off = false;
            on = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(WaitEnd());
        }

        if (health > 100)
        {
            health = 100;
        } else if (health <= 0)
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

    IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }
}
