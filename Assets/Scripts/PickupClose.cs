using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class PickupClose : MonoBehaviour
{
    public GameObject weaponOB;
    public GameObject player;

    public AudioSource pickUpAmmoSound;
    public AudioSource pickUpShotgun;

    public int ammoBoxAmount;

    public bool inreach;
    public GameObject pickableObject;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Pickable")
        {
            inreach = true;
            pickableObject = other.GameObject();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            inreach = false;
            pickableObject = null;
        }
    }



    void Update()
    {
        if(inreach)
        {
            if (pickableObject.name == "ShellsGround")
            {
                weaponOB.GetComponent<GunSystem>().ammoCache += ammoBoxAmount;
                pickableObject.SetActive(false);
                pickUpAmmoSound.Play();
                inreach = false;
                pickableObject = null;
            } else if (pickableObject.name == "ShotgunGround")
            {
                player.GetComponent<WeaponsSwitch>().shotgun = true;
                player.GetComponent<WeaponsSwitch>().object01.SetActive(false);
                player.GetComponent<WeaponsSwitch>().object02.SetActive(true);
                pickableObject.SetActive(false);
                pickUpAmmoSound.Play();
                inreach = false;
                pickableObject = null;

            }
        }


    }
}
