using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    private void OnTriggerExit(Collider other)
    {
        Player player = FindObjectOfType<Player>();
        if (other.gameObject.tag == "Boss" && player != null)
        {
            IDamageable boss = FindObjectOfType<Boss>();
            Weapon w = player.EquipedWeapon.GetComponent<Weapon>();
            boss.TakeDamage(player.Damage + ((w == null) ? 0 : w.Damage));
        }
    }
}
