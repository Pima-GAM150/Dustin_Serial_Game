﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    public float Speed = 5;
    public float FlightTime = 3;
    Vector3 initialDir;

    private IEnumerator Start()
    {
        initialDir = this.transform.forward;
        while(true)
        {
            yield return new WaitForSeconds(FlightTime);

            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(initialDir*Speed*Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = FindObjectOfType<Player>();
        if (other.gameObject.tag == "Boss" && player != null)
        {
            IDamageable boss = FindObjectOfType<Boss>();
            Weapon w = player.EquipedWeapon.GetComponent<Weapon>();
            boss.TakeDamage(player.Damage + ((w == null) ? 0 : w.Damage));
        }
        Destroy(this.gameObject);
    }
}
