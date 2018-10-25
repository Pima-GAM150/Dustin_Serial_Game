using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Player player = FindObjectOfType<Player>();
        if (collision.gameObject.tag == "boss")
        {
            IDamageable boss = collision.gameObject.GetComponent<IDamageable>();
            Weapon w = player.EquipedWeapon.GetComponent<Weapon>();
            int weaponModifier = w.Damage;
            boss.TakeDamage(player.Damage + weaponModifier);
        }
    }

}
