using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Animator AnimationController;
    Boss boss;
    Player player;
    bool Attacking;
    private void Start()
    {
        boss = FindObjectOfType<Boss>();
        player = FindObjectOfType<Player>();
        Attacking = false;
    }

    private void Update()
    {
        StartCoroutine(CheckForPlayerDistance());
    }

    private IEnumerator CheckForPlayerDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            if (Vector3.Distance(this.transform.position, player.gameObject.transform.position) <= 3f)
            {
                Attacking = true;
                StartCoroutine(StartAttack());
            }
            else
            {
                Attacking = false;
            }
        }
    }

    private IEnumerator StartAttack()
    {
        while(Attacking)
        {
            yield return new WaitForSeconds(1);
            boss.transform.rotation = Quaternion.LookRotation(player.transform.position - this.transform.position);
            AnimationController.SetTrigger("BossAttack");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && player != null)
        {
            IDamageable thePlayer = player.GetComponent<IDamageable>();

            thePlayer.TakeDamage(boss.Damage);
        }
    }
}
