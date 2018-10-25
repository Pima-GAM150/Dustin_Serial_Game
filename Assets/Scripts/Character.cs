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

    public void ChangeHealth(float factor) { Health += factor; }
    public void ChangeDamage(float factor) { Damage += factor; }
}
