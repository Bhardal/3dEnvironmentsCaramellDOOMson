using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioSource hurt;
    public AudioSource die;
    // public GameObject OriginalOB;
    // public GameObject ChangeOB;
    // public Animator ANI;

    public float health = 100f;

    // public bool animate;
    // public bool replace;
    public bool destroy;


    public void TakeDamage(float amount)
    {
        health -= amount;
        // if(health <= 0f && animate)
        // {
        //     Animate();
        // }

        // if (health <= 0f && replace)
        // {
        //     Replace();
        // }

        if (health <= 0f && destroy)
        {
            die.Play();
            Destroy();
        } else
        {
            hurt.Play();
        }
    }

    // void Animate()
    // {
    //     ANI.SetBool("animate", true);
    // }


    // void Replace()
    // {
    //     OriginalOB.SetActive(false);
    //     ChangeOB.SetActive(true);
    // }


    void Destroy()
    {
        Destroy(gameObject);
    }

}
