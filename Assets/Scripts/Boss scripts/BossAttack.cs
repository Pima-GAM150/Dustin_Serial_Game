using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Boss boss;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boss = FindObjectOfType<Boss>();
            IDamageable player = collision.gameObject.GetComponent<IDamageable>();

            player.TakeDamage(boss.Damage);
        }
    }
}
