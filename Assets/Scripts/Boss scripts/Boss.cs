﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character, IDamageable
{
    [HideInInspector]public BossStats stats;
    [HideInInspector]ManagerS Manager;
    public static Boss BossS;
    

    private void Start()
    {
        BossS = this;
        LoadStats();
    }

    public void TakeDamage(float damage)
    {
        this.Health -= damage;
    }

    public override void LoadStats()
    {
        Manager = FindObjectOfType<ManagerS>();
        stats = Manager.BossData;
        Debug.Log("Loading Boss Stats");
        Health = stats.Health;
        Damage = stats.Damage;
        MaxHealth = stats.MaxHealth;
    }

    public override void SaveStats()
    {
        Manager = FindObjectOfType<ManagerS>();

        stats.Health = Health;
        stats.Damage = Damage;

        Manager.BossData = stats;
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            if(collision.gameObject.tag == "Health")
            {
                Health health = collision.gameObject.GetComponent<Health>();
                ChangeHealth(health.Factor);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Damage")
            {
                DamageBoost db = collision.gameObject.GetComponent<DamageBoost>();
                ChangeDamage(db.Factor);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "MaxHealth")
            {
                Health health = collision.gameObject.GetComponent<Health>();
                ChangeMaxHealth(health.Factor);
                Destroy(collision.gameObject);
            }
        }
    }

}
