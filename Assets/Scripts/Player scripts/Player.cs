using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour , IDamageable
{
    [HideInInspector]public PlayerStats stats;
    [HideInInspector]public static Player player;

    private void Awake()
    {
        if (player == null)
        {
            player = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
    }

    public PlayerInventory Inventory;
    public int Health;
    public int Damage;
    public GameObject EquipedWeapon;


    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void EquipWeapon(GameObject weapon)
    {
       // equip weapons here
    }

    public void LoadStats()
    {
        Inventory = stats.inventory;
        Health = stats.Health;
        Damage = stats.Damage;
        EquipedWeapon = stats.Weapon;
    }

    public void SaveStats()
    {
        stats.inventory = Inventory;
        stats.Health = Health;
        stats.Damage = Damage;
        stats.Weapon = EquipedWeapon;
    }

    public void ChangeHealth(int factor)
    {
        Health += factor;
    }

    public void ChangeDamage(int factor)
    {
        Damage += factor;
    }

    public void ChangeSpeed(int factor)
    {
        PlayerController pc = FindObjectOfType<PlayerController>();

        if(pc.Speed < 15)
        {
            pc.Speed += factor;
        }
        
    }

    public void AddToInventory(GameObject newWeapon)
    {
        Inventory.weapons.Add(newWeapon);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            AddToInventory(collision.gameObject);
        }
        else if (collision.gameObject.layer == 9)
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
