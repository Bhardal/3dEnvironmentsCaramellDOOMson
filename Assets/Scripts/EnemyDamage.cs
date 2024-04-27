using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject player;
    private float damageRange;
    public float damageSet = 15f;
    public float minDamage;
    public float maxDamage;

    public bool randomDamage;
    public bool setDamage;

    public AudioClip[] sounds;
    private AudioSource source;


    void Start()
    {
        source = player.GetComponentInChildren<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        damageRange = Random.Range(minDamage, maxDamage);
        if (other.gameObject.tag == "Player" && randomDamage)
        {
            if (player.GetComponent<PlayerHealth>().shield <= 0)
            {
                player.GetComponent<PlayerHealth>().health -= damageRange;
            } else
            {
                player.GetComponent<PlayerHealth>().shield -= damageRange;
                if (player.GetComponent<PlayerHealth>().shield < 0)
                {
                    player.GetComponent<PlayerHealth>().health += player.GetComponent<PlayerHealth>().shield;
                }
            }
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.Play();
        }

        if (other.gameObject.tag == "Player" && setDamage)
        {
            if (player.GetComponent<PlayerHealth>().shield <= 0)
            {
                player.GetComponent<PlayerHealth>().health -= damageSet;
            } else
            {
                player.GetComponent<PlayerHealth>().shield -= damageSet;
                if (player.GetComponent<PlayerHealth>().shield < 0)
                {
                    player.GetComponent<PlayerHealth>().health += player.GetComponent<PlayerHealth>().shield;
                }
            }
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.Play();
        }

    }


    void Update()
    {

    }
}
