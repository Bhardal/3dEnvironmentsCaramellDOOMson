using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsWithLockAuto : MonoBehaviour
{
    public Animator door;

    public AudioSource doorSound;
    public AudioSource granted;


    public bool FinalBossKilled = false;
    public bool unlocked;
    public bool locked;





    void Start()
    {
        unlocked = false;
        locked = true;
    }


    void Update()
    {
        if (FinalBossKilled)
        {
            locked = false;
            unlocked = true;
            DoorOpens();
        }



    }


    void DoorOpens ()
    {
        if (unlocked)
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            granted.Play();
            doorSound.Play();
        }
    }


}
