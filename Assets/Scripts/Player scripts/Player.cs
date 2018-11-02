using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character , IDamageable
{
    [HideInInspector]public PlayerStats stats;
    [HideInInspector]public bool CardDeck;
    [HideInInspector]ManagerS Manager;
    
    public Weapon EquipedWeapon;
    string HeldWeapon;
    
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
    public void EquipWeapon(string weapon)
    {
        Weapon[] HeldWeapons = FindObjectsOfType<Weapon>();

        foreach (Weapon w in HeldWeapons)
        {
            if(w.gameObject.name == weapon)
            {
                w.gameObject.SetActive(true);
                EquipedWeapon = w;
                if (w.gameObject.name == "CardDeck")
                {
                    CardDeck = true;
                }
                else
                {
                    CardDeck = false;
                }
            }
            else
            {
                w.gameObject.SetActive(false);
            }
        }
    }

    public override void LoadStats()
    {
        Manager = FindObjectOfType<ManagerS>();
        stats = Manager.PlayerData;
        
        Health = stats.Health;
        MaxHealth = stats.MaxHealth;
        Damage = stats.Damage;
        HeldWeapon = stats.Weapon;
        EquipWeapon(HeldWeapon);
    }

    public override void SaveStats()
    {
        Manager = FindObjectOfType<ManagerS>();

        HeldWeapon = EquipedWeapon.name;
        
        stats.Health = Health;
        stats.Damage = Damage;
        stats.MaxHealth = MaxHealth;
        stats.Weapon = HeldWeapon;

        Manager.PlayerData = stats;
    }

    public void ChangeSpeed(float factor)
    {
        PlayerController pc = FindObjectOfType<PlayerController>();

        if(pc.Speed < 55)
        {
            pc.Speed += factor;
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag == "Health")
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
            else if(collision.gameObject.tag == "SpeedBoost")
            {
                SpeedBoost sb = collision.gameObject.GetComponent<SpeedBoost>();
                ChangeSpeed(sb.Factor);
                Destroy(collision.gameObject);
            }
        }
    }

}
