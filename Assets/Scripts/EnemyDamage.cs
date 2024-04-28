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

    private float timebetweenDamage = 7/3;
    private float nextTimeToDamage = 0f;


    void Start()
    {
        source = player.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        damageRange = Random.Range(minDamage, maxDamage);
        if (other.gameObject.tag == "Player" && randomDamage && Time.time >= nextTimeToDamage)
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
            nextTimeToDamage = Time.time+timebetweenDamage;
        }

        if (other.gameObject.tag == "Player" && setDamage && Time.time >= nextTimeToDamage)
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
            nextTimeToDamage = Time.time+timebetweenDamage;
        }

    }

    void OnTriggerStay(Collider other)
    {
        damageRange = Random.Range(minDamage, maxDamage);
        if (other.gameObject.tag == "Player" && randomDamage && Time.time >= nextTimeToDamage)
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
            nextTimeToDamage = Time.time+timebetweenDamage;
        }

        if (other.gameObject.tag == "Player" && setDamage && Time.time >= nextTimeToDamage)
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
            nextTimeToDamage = Time.time+timebetweenDamage;
        }

    }


    void Update()
    {

    }
}
