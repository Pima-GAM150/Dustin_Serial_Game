using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character , IDamageable
{
    [HideInInspector]public PlayerStats stats;
    [HideInInspector]public bool CardDeck;
    [HideInInspector]ManagerS Manager;

    public PlayerInventory Inventory;
    public GameObject EquipedWeapon;

    


    private void Start()
    {
        LoadStats();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void EquipWeapon(GameObject weapon)
    {
       // equip weapons here
    }

    public override void LoadStats()
    {
        Manager = FindObjectOfType<ManagerS>();
        stats = Manager.PlayerData;

        Inventory = stats.inventory;
        Health = stats.Health;
        MaxHealth = stats.MaxHealth;
        Damage = stats.Damage;
        EquipedWeapon = stats.Weapon;
    }

    public override void SaveStats()
    {
        Manager = FindObjectOfType<ManagerS>();

        stats.inventory = Inventory;
        stats.Health = Health;
        stats.Damage = Damage;
        stats.Weapon = EquipedWeapon;

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

    public void AddToInventory(GameObject newWeapon)
    {
       
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag == "Health")
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
        }
    }

}
