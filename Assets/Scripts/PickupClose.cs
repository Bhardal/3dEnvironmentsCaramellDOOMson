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
    public GameObject HealthFX;
    public GameObject ShieldFX;
    public GameObject FXMenu;
    public bool FinalBossKilled = false;

    public AudioSource pickUpAmmoSound;
    public AudioSource pickUpShotgunSound;
    public AudioSource pickUpHealthSound;
    public AudioSource pickUpShieldSound;
    public AudioSource winSound;

    public int healthPackHeal;
    public int ShieldPackHeal;
    public int ammoBoxAmount;
    private float currentHealth;
    private float maxHealth = 100f;
    private float maxShield = 50f;

    public bool inreach;
    public GameObject pickableObject;

    public bool on;
    public bool off;


    void Start()
    {
        currentHealth = player.GetComponent<PlayerHealth>().health;
        HealthFX.SetActive(false);
        ShieldFX.SetActive(false);

        menu.SetActive(false);
        FXMenu.SetActive(false);
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
            } else if (pickableObject.name == "ShotgunGround" && GameObject.Find("Gun").GetComponent<GunSystem>().canSwitch)
            {
                player.GetComponent<WeaponsSwitch>().shotgun = true;
                player.GetComponent<WeaponsSwitch>().object01.layer = 7; //.SetActive(false);
                player.GetComponent<WeaponsSwitch>().object02.layer = 6; //.SetActive(true);
                SetLayerAllChildren(player.GetComponent<WeaponsSwitch>().object01.transform, 7);
                SetLayerAllChildren(player.GetComponent<WeaponsSwitch>().object02.transform, 6);
                pickableObject.SetActive(false);
                pickUpShotgunSound.Play();
                inreach = false;
                pickableObject = null;

            } else if (pickableObject.name == "HealthPack")
            {
                if (player.GetComponent<PlayerHealth>().health < maxHealth)
                {
                    player.GetComponent<PlayerHealth>().health += healthPackHeal;
                    FXMenu.SetActive(true);
                    HealthFX.SetActive(true);
                    pickableObject.SetActive(false);
                    pickUpHealthSound.Play();
                    inreach = false;
                    pickableObject = null;
                    StartCoroutine(TurnScreenFXOFF());
                }

            } else if (pickableObject.name == "ShieldPack")
            {
                if (player.GetComponent<PlayerHealth>().shield < maxShield)
                {
                    player.GetComponent<PlayerHealth>().shield += ShieldPackHeal;
                    FXMenu.SetActive(true);
                    ShieldFX.SetActive(true);
                    pickableObject.SetActive(false);
                    pickUpShieldSound.Play();
                    inreach = false;
                    pickableObject = null;
                    StartCoroutine(TurnScreenFXOFF());
                }

            } else if (pickableObject.name == "EndWall" && FinalBossKilled)
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

    void SetLayerAllChildren(Transform root, int layer)
    {
        var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
        foreach (var child in children)
        {
//            Debug.Log(child.name);
            child.gameObject.layer = layer;
        }
    }


    IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }

    IEnumerator TurnScreenFXOFF()
    {
        yield return new WaitForSeconds(1.25f);
        HealthFX.SetActive(false);
        ShieldFX.SetActive(false);
        FXMenu.SetActive(false);
    }

}
