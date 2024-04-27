using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RawImage healthBar;
    public RawImage shieldBar;
    public float CurrentHealth;
    public float CurrentShield;
    private float MaxHealth = 100f;
    private float MaxShield = 50f;
    public Texture2D[] HealthBarImages;
    public Texture2D[] ShieldBarImages;
    PlayerHealth player;
    private int healthNumber;
    private int shieldNumber;





    void Start()
    {
        // healthBar = GetComponent<RawImage>();
        // shieldBar = GetComponent<RawImage>();
        player = FindObjectOfType<PlayerHealth>();

    }



    void Update()
    {
        CurrentHealth = player.health;
        CurrentShield = player.shield;
        healthNumber = (int)Math.Round(CurrentHealth / 5);
        if (healthNumber < 0)
        {
            healthNumber = 0;
        } else if (healthNumber > 20)
        {
            healthNumber = 20;
        }
        shieldNumber = (int)Math.Round(CurrentShield / 5);
        if (shieldNumber < 0)
        {
            shieldNumber = 0;
        } else if (shieldNumber > 10)
        {
            shieldNumber = 10;
        }
        healthBar.texture = HealthBarImages[healthNumber];
        shieldBar.texture = ShieldBarImages[shieldNumber];



    }
}
