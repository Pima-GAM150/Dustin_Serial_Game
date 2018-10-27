using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator AttackAnimation;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(player.CardDeck)
            {
                AttackAnimation.SetTrigger("CardThrow");
            }
            else
            {
                AttackAnimation.SetTrigger("Melee");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Player player = FindObjectOfType<Player>();
        if (collision.gameObject.tag == "boss")
        {
            IDamageable boss = collision.gameObject.GetComponent<IDamageable>();
            Weapon w = player.EquipedWeapon;
            boss.TakeDamage(player.Damage + w.Damage);
        }
    }

}
