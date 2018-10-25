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

}
