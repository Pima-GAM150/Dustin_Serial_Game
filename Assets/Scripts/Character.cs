using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public float Damage;

    public virtual void SaveStats() { }
    public virtual void LoadStats() { }

    public void ChangeHealth(float factor) { Health += factor; if (Health > MaxHealth) { Health = MaxHealth; } }
    public void ChangeDamage(float factor) { Damage += factor; }
    public void ChangeMaxHealth(float factor) { MaxHealth += factor; }
}
