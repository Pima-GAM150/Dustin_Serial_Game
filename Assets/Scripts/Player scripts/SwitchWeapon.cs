using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    List<Weapon> weapons;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        weapons = player.Inventory.weapons;
    }
    private void Update()
    {
        if (Input.GetAxis("Fire3") == 1 && weapons.Capacity > 1)
        {
            SwitchEquipedWeapon();
        }
    }

    private void SwitchEquipedWeapon()
    {
        for (int i = 0; i < weapons.Capacity; i++)
        {
            Weapon w = player.Inventory.weapons[i];
            if (player.EquipedWeaopn == w)
            {
                player.EquipedWeaopn = player.Inventory.weapons[i + 1];
                return;
            }
        }
    }
}
