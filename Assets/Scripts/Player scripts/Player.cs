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


    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void LoadStats()
    {
        Inventory = stats.inventory;
        Health = stats.Health;
        Damage = stats.Damage;
    }

    public void SaveStats()
    {
        stats.inventory = Inventory;
        stats.Health = Health;
        stats.Damage = Damage;
    }

    public void ChangeHealth(int factor)
    {
        Health += factor;
    }

    public void ChangeDamage(int factor)
    {
        Damage += factor;
    }

    public void AddToInventory(Weapon newWeapon)
    {
        Inventory.weapons.Add(newWeapon);
    }

}
