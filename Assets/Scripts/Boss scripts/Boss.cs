using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character, IDamageable
{
    [HideInInspector]public BossStats stats;
    [HideInInspector] public static Boss boss;

    private void Awake()
    {
        if (boss == null)
        {
            boss = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (boss != this)
        {
            Destroy(gameObject);
        }


    }

    

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void LoadStats()
    {
        Health = stats.Health;
        Damage = stats.Damage;
        MaxHealth = stats.MaxHealth;
    }

    public void SaveStats()
    {
        stats.Health = Health;
        stats.Damage = Damage;
    }

    public void ChangeHealth(float factor)
    {
        Health += factor;
    }

    public void ChangeDamage(float factor)
    {
        Damage += factor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            if(collision.gameObject.tag == "Health")
            {
                Health health = collision.gameObject.GetComponent<Health>();
                ChangeHealth(health.Factor);
            }
            else if (collision.gameObject.tag == "DamageBoost")
            {
                DamageBoost db = collision.gameObject.GetComponent<DamageBoost>();
                ChangeDamage(db.Factor);
            }
        }
    }

}
