using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character , IDamageable
{
    [HideInInspector]public PlayerStats stats;
    [HideInInspector]public bool CardDeck;
    [HideInInspector]ManagerS Manager;
    
    public Weapon EquipedWeapon;
    
    private void Start()
    {
        LoadStats();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void EquipWeapon(Transform weapon)
    {
        EquipedWeapon = weapon.GetComponent<Weapon>();

        if (EquipedWeapon.gameObject.name == "CardDeck")
        {
            CardDeck = true;
        }
        else
        {
            CardDeck = false;
        }


    }

    public override void LoadStats()
    {
        Manager = FindObjectOfType<ManagerS>();
        stats = Manager.PlayerData;
        
        Health = stats.Health;
        MaxHealth = stats.MaxHealth;
        Damage = stats.Damage;
        EquipedWeapon = stats.Weapon;
    }

    public override void SaveStats()
    {
        Manager = FindObjectOfType<ManagerS>();
        
        stats.Health = Health;
        stats.Damage = Damage;
        stats.Weapon = EquipedWeapon;
        stats.MaxHealth = MaxHealth;

        Manager.PlayerData = stats;
    }

    public void ChangeSpeed(float factor)
    {
        PlayerController pc = FindObjectOfType<PlayerController>();

        if(pc.Speed < 15)
        {
            pc.Speed += factor;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag == "HealthRestore")
            {
                Health health = collision.gameObject.GetComponent<Health>();
                ChangeHealth(health.Factor);
            }
            else if (collision.gameObject.tag == "DamageBoost")
            {
                DamageBoost db = collision.gameObject.GetComponent<DamageBoost>();
                ChangeDamage(db.Factor);
            }
            else if (collision.gameObject.tag == "SpeedBoost")
            {
                SpeedBoost sb = collision.gameObject.GetComponent<SpeedBoost>();
                ChangeSpeed(sb.Factor);
            }
            else if(collision.gameObject.tag == "MaxHealth")
            {
                Health health = collision.gameObject.GetComponent<Health>();
                ChangeMaxHealth(health.Factor);
            }
        }
    }

}
