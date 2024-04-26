using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject resume;
    public GameObject quit;
    public AudioSource music1;
    public AudioSource music2;
    private AudioSource music;

    public bool on;
    public bool off;





    void Start()
    {
        menu.SetActive(false);
        off = true;
        on = false;
    }




    void Update()
    {
        if (music1.mute == false)
        {
            music = music1;
        }
        else if (music2.mute == false)
        {
            music = music2;
        }

        if (off && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            off = false;
            on = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            music.Pause();
        }

        else if (on && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            off = true;
            on = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            music.UnPause();
        }

    }

    public void Resume()
    {
            Time.timeScale = 1;
            menu.SetActive(false);
            off = true;
            on = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            music.UnPause();

    }

    public void Exit()
    {
        Debug.Log("Button Pressed !");
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
