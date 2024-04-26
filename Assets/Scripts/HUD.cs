using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{    public GameObject Gun;
    public GameObject Bullets;
    public GameObject GunOB;

    public GameObject Shotgun;
    public GameObject Shells;
    public GameObject ShotgunOB;




    void Start()
    {

    }




    void Update()
    {

        if (GunOB.activeInHierarchy)
        {
            Gun.SetActive(true);
            Bullets.SetActive(true);
        }

        else
        {
            Gun.SetActive(false);
            Bullets.SetActive(false);
        }

        if (ShotgunOB.activeInHierarchy)
        {
            Shotgun.SetActive(true);
            Shells.SetActive(true);
        }

        else
        {
            Shotgun.SetActive(false);
            Shells.SetActive(false);
        }
    }
}
