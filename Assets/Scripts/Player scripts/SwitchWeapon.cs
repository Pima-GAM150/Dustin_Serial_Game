using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int SelectedWeapon = 0;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        SwitchEquipedWeapon();
    }
    private void Update()
    {
        int PrevWeapon = SelectedWeapon;

        if (Input.GetButtonDown("Fire3"))
        {
            if (SelectedWeapon >= transform.childCount - 1) 
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }
        }
        if(SelectedWeapon!=PrevWeapon)
        {
            SwitchEquipedWeapon();
        }
    }

    private void SwitchEquipedWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                player.EquipWeapon(weapon);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
