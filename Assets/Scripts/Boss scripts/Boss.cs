using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
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

    public int Health;
    public int Damage;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void LoadStats()
    {
        Health = stats.Health;
        Damage = stats.Damage;
    }

    public void SaveStats()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IDamageable player = collision.gameObject.GetComponent<IDamageable>();

            player.TakeDamage(Damage);
        }
        else if (collision.gameObject.layer == 9)
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
