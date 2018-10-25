using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character, IDamageable
{
    [HideInInspector]public BossStats stats;
    [HideInInspector]ManagerS Manager;

    private void Start()
    {
        LoadStats();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public override void LoadStats()
    {
        Manager = FindObjectOfType<ManagerS>();
        stats = Manager.BossData;

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
