using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Boss boss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boss = FindObjectOfType<Boss>();
            IDamageable player = other.gameObject.GetComponent<IDamageable>();

            player.TakeDamage(boss.Damage);
        }
    }
}
