using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PickupClose : MonoBehaviour
{
    public GameObject menu;
    public GameObject quit;
    public GameObject weaponOB;
    public GameObject player;

    public AudioSource pickUpAmmoSound;
    public AudioSource pickUpShotgunSound;
    public AudioSource pickUpHealthSound;
    public AudioSource pickUpShieldSound;
    public AudioSource winSound;
    public AudioSource loseSound;
    public int healthPackHeal;
    public int ShieldPackHeal;

    public int ammoBoxAmount;

    public bool inreach;
    public GameObject pickableObject;

    public bool on;
    public bool off;


    void Start()
    {
        menu.SetActive(false);
        off = true;
        on = false;
    }

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
                pickUpShotgunSound.Play();
                inreach = false;
                pickableObject = null;

            } else if (pickableObject.name == "HealthPack")
            {
                // player.GetComponent<WeaponsSwitch>().shotgun = true;
                // player.GetComponent<WeaponsSwitch>().object01.SetActive(false);
                // player.GetComponent<WeaponsSwitch>().object02.SetActive(true);
                pickableObject.SetActive(false);
                pickUpHealthSound.Play();
                inreach = false;
                pickableObject = null;

            } else if (pickableObject.name == "ShieldPack")
            {
                // player.GetComponent<WeaponsSwitch>().shotgun = true;
                // player.GetComponent<WeaponsSwitch>().object01.SetActive(false);
                // player.GetComponent<WeaponsSwitch>().object02.SetActive(true);
                pickableObject.SetActive(false);
                pickUpShieldSound.Play();
                inreach = false;
                pickableObject = null;

            } else if (pickableObject.name == "EndWall")
            {
                AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
                foreach(AudioSource aud in audios)
                    aud.volume = 0;

                winSound.volume = 1;
                winSound.Play();
                menu.SetActive(true);
                off = false;
                on = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                StartCoroutine(WaitEnd());
            }
        }
    }

    IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(1000);
        Time.timeScale = 0;
    }

}
