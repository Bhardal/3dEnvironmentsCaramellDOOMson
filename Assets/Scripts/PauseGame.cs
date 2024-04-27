using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject resume;
    public GameObject quit;
    public Sprite muteButtonImage;
    public Sprite unMuteButtonImage;
    public Button muteButton;
    public AudioSource music1;
    public AudioSource music2;
    private AudioSource music;
    private int musicNumber;

    public bool on;
    public bool off;





    void Start()
    {
        menu.SetActive(false);
        off = true;
        on = false;
        if (music1.mute == false)
        {
            music = music1;
            musicNumber = 1;
        } else if (music2.mute == false)
        {
            music = music2;
            musicNumber = 2;
        } else
        {
            music = null;
            musicNumber = 0;
        }
    }




    void Update()
    {
        if (music1.mute == false)
        {
            music = music1;
            musicNumber = 1;
        } else if (music2.mute == false)
        {
            music = music2;
            musicNumber = 2;
        } else
        {
            music = null;
        }

        if (off && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            off = false;
            on = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (music != null)
            {
                music.Pause();
            }
        }

        else if (on && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            off = true;
            on = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (music != null)
            {
                music.UnPause();
            }
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
            if (music != null)
            {
                music.UnPause();
            }
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

    public void Mute()
    {
        if (music == null)
        {
            if (musicNumber == 1)
            {
                music = music1;
            } else if (musicNumber == 2)
            {
                music = music2;
            } else
            {
                return;
            }
        }
        if (music.mute == true)
        {
            music.mute = false;
            muteButton.image.sprite = muteButtonImage;
        } else
        {
            music.mute = true;
            muteButton.image.sprite = unMuteButtonImage;
        }
    }

    public void Switch()
    {
        if (musicNumber == 1)
        {
            musicNumber = 2;
            music.mute = true;
            music = music2;
            music.mute = false;
            music.Play();
            music.Pause();
        } else if (musicNumber == 2)
        {
            musicNumber = 1;
            music.mute = true;
            music = music1;
            music.mute = false;
            music.Play();
            music.Pause();
        }
    }
}
